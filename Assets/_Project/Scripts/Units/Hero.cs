using System.Collections;
using System.Collections.Generic;
using Descending.Abilities;
using Descending.Attributes;
using Descending.Combat;
using Descending.Core;
using Descending.Equipment;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Units
{
    public enum HeroCombatModes { Melee, Ranged, Unarmed, Number, None }
    
    public class Hero : Unit
    {
        [SerializeField] protected HeroData _heroData = null;
        [SerializeField] private GameObject _portraitModel = null;
        [SerializeField] private HeroCombatModes _combatMode = HeroCombatModes.None;

        [SerializeField] protected HeroUnitEvent onSyncHero = null;
        [SerializeField] protected IntEvent onSyncHeroUnitEffectsGui = null;

        private BodyRenderer _portraitRenderer = null;
        private PortraitMount _portrait = null;

        public GameObject PortraitModel => _portraitModel;
        public BodyRenderer PortraitRenderer => _portraitRenderer;
        public PortraitMount Portrait => _portrait;
        public HeroData HeroData => _heroData;
        public HeroCombatModes CombatMode => _combatMode;

        public void SetupHero(Genders gender, RaceDefinition race, ProfessionDefinition profession, int listIndex)
        {
            _modelParent.ClearTransform();

            _portraitModel = Instantiate(race.PrefabMale, null);
            _portraitRenderer = _portraitModel.GetComponent<BodyRenderer>();
            _portraitRenderer.SetupBody(gender, race, profession);

            _unitAnimator = GetComponent<UnitAnimator>();
            _unitAnimator.Setup(_portraitModel.GetComponent<Animator>());

            _heroData.Setup(gender, race, profession, _portraitRenderer, listIndex);
            _attributes.Setup(race, profession);
            _skills.Setup(_attributes, race, profession);
            _inventory.Setup(_portraitRenderer, _portraitRenderer, gender, race, profession);
            
            _animationEvents = _portraitModel.GetComponent<AnimationEvents>();
            _animationEvents.Setup(_inventory);
            
            _attributes.CalculateAttributes(true, true);
            _abilities.Setup(race, profession, _skills);
            _damageSystem.Setup(this);
            _unitEffects.Setup();

            _combatMode = profession.DefaultCombatMode;
            
            var children = _portraitModel.GetComponentsInChildren<Transform>(includeInactive: true);
            foreach (var child in children)
            {
                child.gameObject.layer = LayerMask.NameToLayer("Portrait Light");
            }
        }

        public void LoadHero(HeroSaveData saveData)
        {
            RaceDefinition race = Database.instance.Races.GetRace(saveData.RaceKey);
            ProfessionDefinition profession = Database.instance.Profession.GetProfession(saveData.ProfessionKey);
            
            _modelParent.ClearTransform();

            _portraitModel = Instantiate(race.PrefabMale, null);
            _portraitRenderer = _portraitModel.GetComponent<BodyRenderer>();
            _portraitRenderer.LoadBody(saveData);

            _unitAnimator = GetComponent<UnitAnimator>();
            _unitAnimator.Setup(_portraitModel.GetComponent<Animator>());

            _heroData.LoadData(saveData, _portraitRenderer);
            _attributes.Setup(race, profession);
            _attributes.LoadData(saveData.AttributesSaveData);
            _skills.LoadData(saveData.SkillsSaveData);
            _inventory.LoadData(_portraitRenderer, _portraitRenderer, saveData);
            _abilities.LoadData(saveData.AbilitySaveData);
            
            _damageSystem.Setup(this);
            _unitEffects.Setup();
            
            var children = _portraitModel.GetComponentsInChildren<Transform>(includeInactive: true);
            foreach (var child in children)
            {
                child.gameObject.layer = LayerMask.NameToLayer("Portrait Light");
            }
        }

        public override string GetFullName()
        {
            return _heroData.Name.FullName;
        }

        public override string GetShortName()
        {
            return _heroData.Name.ShortName;
        }

        public string GetFirstName()
        {
            return _heroData.Name.FirstName;
        }

        public override Item GetEquippedWeapon()
        {
            return _inventory.GetCurrentWeapon();
        }

        public override Item GetMeleeWeapon()
        {
            return _inventory.GetCurrentWeapon();
        }

        public override Item GetRangedWeapon()
        {
            return _inventory.GetCurrentWeapon();
        }

        public override void Damage(GameObject attacker, DamageTypeDefinition damageType, int damage, string vital)
        {
            if (_isAlive == false) return;

            _damageSystem.TakeDamage(attacker, damage);

            if (GetHealth() <= 0)
            {
                Dead();
            }

            SyncData();
        }

        public override void RestoreVital(string vital, int amount)
        {
            if (_isAlive == false) return;

            _damageSystem.RestoreVital(vital, amount);
            SyncData();
        }

        public override void UseResource(string vital, int amount)
        {
            if (_isAlive == false) return;

            _damageSystem.UseResource(vital, amount);
            SyncData();
        }

        protected override void Dead()
        {
            _isAlive = false;
            Destroy(gameObject);
        }

        public void SetPortrait(PortraitMount portraitMount)
        {
            _portrait = portraitMount;
        }

        public void AddExperience(int experience)
        {
            _heroData.AddExperience(experience);
            SyncData();
        }

        public override void SpendActionPoints(int actionPointCost)
        {
            _attributes.ModifyVital("Actions", actionPointCost, true);
            SyncData();
        }

        public void SetWorldPanelAActive(bool active)
        {
            //_worldPanel.gameObject.SetActive(active);
        }

        public void SyncData()
        {
            onSyncHero.Invoke(this);
        }

        public void SetEquippedWeapon(bool ranged)
        {
            if (ranged == false)
            {
                _inventory.TryEquipMelee();
                _combatMode = HeroCombatModes.Melee;
            }
            else
            {
                _inventory.TryEquipRanged();
                _combatMode = HeroCombatModes.Ranged;
            }
        }

        public override void AddUnitEffect(Ability ability)
        {
            _unitEffects.AddEffect(ability);
            
            SyncData();
        }

        public void GameTick()
        {
            foreach (UnitEffect unitEffect in _unitEffects.Effects)
            {
                unitEffect.Process(this);
                unitEffect.TickTime();
            }

            for (int i = _unitEffects.Effects.Count - 1; i >= 0; i--)
            {
                if (_unitEffects.Effects[i].IsActive == false)
                {
                    _unitEffects.Effects.RemoveAt(i);
                }
            }
            
            _attributes.CalculateAttributes(false, false);
            onSyncHeroUnitEffectsGui.Invoke(_heroData.ListIndex);
            
            SyncData();
        }
        
        public void RecoveryTick()
        {
            if (_attributes.GetVital("Actions").Current < _attributes.GetVital("Actions").Maximum)
            {
                RestoreVital("Actions", 1);
            }
            
            if (_attributes.GetVital("Armor").Current < _attributes.GetVital("Armor").Maximum)
            {
                RestoreVital("Armor", 1);
            }
            
            SyncData();
        }

        public override void RecalculateAttributes()
        {
            _attributes.CalculateAttributes(false, false);
        }
    }
}
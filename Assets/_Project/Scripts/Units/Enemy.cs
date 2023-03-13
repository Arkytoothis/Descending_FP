using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Attributes;
using Descending.Combat;
using Descending.Core;
using Descending.Equipment;
using Descending.Gui;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Units
{
    public class Enemy : Unit
    {
        [SerializeField] protected UnitData _unitData = null;
        [SerializeField] private EnemyDefinition _definition = null;
        [SerializeField] private Transform _rightHandMount = null;
        [SerializeField] private Transform _leftHandMount = null;
        [SerializeField] private Transform _projectileTarget = null;
        [SerializeField] private GameObject _selectionIndicator = null;
        [SerializeField] private EnemyWorldPanel _worldPanel = null;
        [SerializeField] private CapsuleCollider _collider = null;
        [SerializeField] private Transform _combatTextTransform = null;
        
        [SerializeField] private BoolEvent onSyncEncounter = null;

        public Transform ProjectileTarget => _projectileTarget;
        public UnitData UnitData => _unitData;
        public EnemyDefinition Definition => _definition;
        public Transform CombatTextTransform => _combatTextTransform;

        public void SetupEnemy(EnemyDefinition definition)
        {
            _definition = definition;
            _isAlive = true;
            
            _attributes.Setup(_definition);
            _inventory.Setup(definition);
            _damageSystem.Setup(this);
            _unitEffects.Setup();
            _worldPanel.Setup(this);
            
            Deselect();
        } 

        public void Activate()
        {
            _modelParent.gameObject.SetActive(true);
            _worldPanel.gameObject.SetActive(true);
            _isActive = true;
        }
        
        public void Deactivate()
        {
            _modelParent.gameObject.SetActive(false);
            _worldPanel.gameObject.SetActive(false);
            _isActive = false;
        }

        public override string GetFullName()
        {
            return _definition.Name;
        }

        public override string GetShortName()
        {
            return _definition.Name;
        }

        public override Item GetEquippedWeapon()
        {
            if(_definition.PrefersRanged)
                return GetRangedWeapon();
            else
            {
                return GetMeleeWeapon();
            }
        }

        public override Item GetMeleeWeapon()
        {
            return _inventory.GetMeleeWeapon();
        }

        public override Item GetRangedWeapon()
        {
            return _inventory.GetRangedWeapon();
        }
        
        public override void Damage(Unit attacker, DamageTypeDefinition damageType, int damage, string vital)
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
            _damageSystem.RestoreVital(vital, amount);
        }

        public override void UseResource(string vital, int amount)
        {
            _damageSystem.UseResource(vital, amount);
        }

        protected override void Dead()
        {
            _isAlive = false;
            HeroManager.Instance.AwardExperience(_definition.ExpValue);
            _unitAnimator.Die();
            _collider.enabled = false;
            _worldPanel.gameObject.SetActive(false);
            //Destroy(gameObject);
        }

        public override void SpendActionPoints(int actionPointCost)
        {
            _attributes.ModifyVital("Actions", actionPointCost, true);
            //_worldPanel.UpdateActionPoints();
        }

        public void SetLeftHandMount(Transform leftHandMount)
        {
            _leftHandMount = leftHandMount;
        }

        public void SetRightHandMount(Transform rightHandMount)
        {
            _rightHandMount = rightHandMount;
        }

        public void Select()
        {
            if (gameObject == null) return;
            
            _selectionIndicator.SetActive(true);
        }

        public void Deselect()
        {
            if (gameObject == null) return;
            
            _selectionIndicator.SetActive(false);
        }

        public void SyncData()
        {
            _worldPanel.Sync();
            onSyncEncounter.Invoke(true);
        }

        public void PerformAttack()
        {
            if(_definition.PrefersRanged == false)
                MeleeAttack();
            else
                RangedAttack();
        }
        
        public void MeleeAttack()
        {
            _unitAnimator.MeleeAttack();
        }

        public void RangedAttack()
        {
            _unitAnimator.RangedAttack();
        }

        public override void RecalculateAttributes()
        {
        }

        public override void DisplayDefaultText(string text)
        {
            TextManager.Instance.SpawnWorldText(_combatTextTransform, text, "default");
        }

        public override void DisplayDamageText(int damage, AttributeDefinition attributeDefinition)
        {
            TextManager.Instance.SpawnWorldText(_combatTextTransform, "-" + damage, "life_damage");
        }

        public override void DisplayHealText(int damage, AttributeDefinition attributeDefinition)
        {
            TextManager.Instance.SpawnWorldText(_combatTextTransform, damage.ToString(), "life_heal");
        }
    }
}
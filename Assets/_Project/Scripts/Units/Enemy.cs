using System;
using System.Collections;
using System.Collections.Generic;
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
        
        [SerializeField] private BoolEvent onSyncEncounter = null;

        private bool _treasureDropped = false;
        private Item _meleeWeapon = null;
        private Item _rangedWeapon = null;

        public Transform ProjectileTarget => _projectileTarget;
        public UnitData UnitData => _unitData;
        public EnemyDefinition Definition => _definition;

        public void SetupEnemy(EnemyDefinition definition)
        {
            _definition = definition;
            _treasureDropped = false;
            _isAlive = true;
            
            _attributes.Setup(_definition);
            
            if(_definition.MeleeWeapon.Item != null)
            {
                _meleeWeapon = ItemGenerator.GenerateItem(_definition.MeleeWeapon);
                EquipWeapon(_meleeWeapon);
            }

            if (_definition.RangedWeapon.Item != null)
            {
                _rangedWeapon = ItemGenerator.GenerateItem(_definition.RangedWeapon);
                EquipWeapon(_rangedWeapon);
            }

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
            if (_meleeWeapon != null) return GetMeleeWeapon();
            else return GetRangedWeapon();
        }

        public override Item GetMeleeWeapon()
        {
            return _meleeWeapon;
        }

        public override Item GetRangedWeapon()
        {
            return _rangedWeapon;
        }

        private void EquipWeapon(Item item)
        {
            if (item == null || item.Key == "" || item.GetWeaponData() == null) return;

            if (item.ItemDefinition.Hands == Hands.Right)
            {
                _rightHandMount.ClearTransform();
                GameObject clone = item.SpawnItemModel(_rightHandMount, 0);
                //_animationController.SetOverride(item.GetWeaponData().AnimatorOverride);
                
            }
            else if (item.ItemDefinition.Hands == Hands.Left)
            {
                _leftHandMount.ClearTransform();
                GameObject clone = item.SpawnItemModel(_leftHandMount, 0);
                //_animationController.SetOverride(item.GetWeaponData().AnimatorOverride);
            }
            
            SyncData();
        }
        
        public override void Damage(GameObject attacker, DamageTypeDefinition damageType, int damage, string vital)
        {
            if (_isAlive == false) return;
            
            //CombatTextHandler.Instance.DisplayCombatText(new CombatText(_combatTextTransform.position, damage.ToString(), "default"));
            _damageSystem.TakeDamage(attacker, damage);
            //_attributes.GetVital("Life").Damage(damage, false);
            
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
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Abilities;
using Descending.Attributes;
using Descending.Combat;
using Descending.Equipment;
using UnityEngine;

namespace Descending.Units
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] protected Transform _modelParent = null;
        [SerializeField] protected Transform _projectileSpawn = null;
        [SerializeField] protected Transform _attackEffectSpawn = null;
        [SerializeField] protected UnitAnimator _unitAnimator = null;
        [SerializeField] protected AttributesController _attributes = null;
        [SerializeField] protected SkillsController _skills = null;
        [SerializeField] protected InventoryController _inventory = null;
        [SerializeField] protected AbilityController _abilities = null;
        [SerializeField] protected UnitEffects _unitEffects = null;
        [SerializeField] protected AnimationEvents _animationEvents = null;
        [SerializeField] protected DamageSystem _damageSystem;
        
        public abstract void SpendActionPoints(int actionPointCost);
        
        protected bool _isActive = false;
        protected bool _isAlive = false;
        protected bool _isSelected = false;
        
        public AttributesController Attributes => _attributes;
        public SkillsController Skills => _skills;
        public InventoryController Inventory => _inventory;
        public AbilityController Abilities => _abilities;
        public DamageSystem DamageSystem => _damageSystem;
        public UnitAnimator UnitAnimator => _unitAnimator;
        public UnitEffects UnitEffects => _unitEffects;
        public AnimationEvents AnimationEvents => _animationEvents;
        public Transform ProjectileSpawn => _projectileSpawn;
        public Transform AttackEffectSpawn => _attackEffectSpawn;

        public bool IsActive => _isActive;
        public bool IsAlive => _isAlive;
        public bool IsSelected => _isSelected;

        public abstract string GetFullName();
        public abstract string GetShortName();
        public abstract Item GetEquippedWeapon();
        public abstract Item GetMeleeWeapon();
        public abstract Item GetRangedWeapon();
        public abstract void Damage(GameObject attacker, DamageTypeDefinition damageType, int damage, string vital);
        public abstract void RestoreVital(string vital, int damage);
        public abstract void UseResource(string vital, int damage);
        public abstract void RecalculateAttributes();
        
        protected abstract void Dead();
        
        private void Awake()
        {
            _isAlive = true;
        }

        private void Start()
        {
        }

        public float GetHealth()
        {
            return _attributes.GetVital("Life").Current;
        }

        public virtual void AddUnitEffect(Ability ability)
        {
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using System.Text;
using Descending.Equipment;
using Descending.Units;
using UnityEngine;

namespace Descending.Abilities
{
    public enum WeaponAttackTypes { Melee, Ranged, Number, None }
    
    [System.Serializable]
    public class WeaponAttackEffect : AbilityEffect
    {
        [SerializeField] private WeaponAttackTypes _attackType = WeaponAttackTypes.None;
        [SerializeField] private int _bonusAttacks = 0;
        [SerializeField] private int _minDamageModifier = 0;
        [SerializeField] private int _maxDamageModifier = 0;
        [SerializeField] private float _damageMultiplier = 1f;
        [SerializeField] private float _attackDelay = 1f;
        
        public override string GetTooltipText()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Weapon Attack").AppendLine();

            if (_bonusAttacks > 0)
            {
                sb.Append("Bonus Attacks +").Append(_bonusAttacks).AppendLine();
            }

            if (_minDamageModifier > 0)
            {
                sb.Append("Min Dmg +").Append(_minDamageModifier);
            }
            else if (_minDamageModifier < 0)
            {
                sb.Append("Min Dmg ").Append(_minDamageModifier);
            }

            if (_maxDamageModifier > 0)
            {
                sb.Append("Max Dmg +").Append(_maxDamageModifier);
            }
            else if (_maxDamageModifier < 0)
            {
                sb.Append("Max Dmg ").Append(_maxDamageModifier);
            }

            sb.AppendLine();
            
            return sb.ToString();
        }
        
        public override void Process(Ability ability, Unit user, List<Unit> targets)
        {
            Item weapon = null;
            if (_attackType == WeaponAttackTypes.Melee)
            {
                weapon = user.GetMeleeWeapon();
            }
            else if(_attackType == WeaponAttackTypes.Ranged)
            {
                weapon = user.GetRangedWeapon();
            }

            if (weapon == null) return;  

            WeaponData weaponData = weapon.GetWeaponData();
                
            if (weaponData == null) return;   
            
            if (_affects == AbilityEffectAffects.User)
            {
            }
            else if (_affects == AbilityEffectAffects.Target)
            {
                user.StartCoroutine(DelayedAttack(user, targets, weaponData));
            }
        }

        private IEnumerator DelayedAttack(Unit user, List<Unit> targets, WeaponData weaponData)
        {
            for (int i = 0; i < _bonusAttacks + 1; i++)
            {
                foreach (Unit unit in targets)
                {
                    for (int j = 0; j < weaponData.DamageEffects.Count; j++)
                    {
                        int damage = (int)(Random.Range(weaponData.DamageEffects[j].MinimumValue + _minDamageModifier, weaponData.DamageEffects[j].MaximumValue + _maxDamageModifier + 1) * _damageMultiplier);
                        unit.Damage(user, weaponData.DamageEffects[j].DamageType, damage, weaponData.DamageEffects[j].Attribute.Key);
                    }
                }
                
                yield return new WaitForSeconds(_attackDelay);
            }
        }
    }
}
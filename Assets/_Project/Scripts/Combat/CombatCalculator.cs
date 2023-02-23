using System.Collections;
using System.Collections.Generic;
using Descending.Abilities;
using Descending.Equipment;
using Descending.Units;
using UnityEngine;

namespace Descending.Combat
{
    public enum AttackTypes { Melee, Ranged, Ability, Number, None }
    
    public static class CombatCalculator
    {
        public static void ProcessAttack(Unit attacker, Unit defender, DamageEffect damageEffect)
        {
            if (TryDefense(defender))
            {
                Miss(attacker, defender);
            }
            else
            {
                if (damageEffect == null)
                {
                    Hit(attacker, defender);
                }
                else
                {
                    Hit(damageEffect, attacker, defender);
                }
            }
        }

        private static bool TryDefense(Unit defender)
        {
            bool defended = false;
            int block = defender.Attributes.GetStatistic("Block").TotalCurrent();
            int dodge = defender.Attributes.GetStatistic("Dodge").TotalCurrent();
            int roll = Random.Range(0, 100);

            if (block >= dodge)
            {
                if (roll <= block)
                {
                    defended = true;
                    //CombatTextHandler.Instance.DisplayCombatText(new CombatText(defender.CombatTextTransform.position, "Block!", "default"));
                }
            }
            else
            {
                if (roll <= dodge)
                {
                    defended = true;
                    //CombatTextHandler.Instance.DisplayCombatText(new CombatText(defender.CombatTextTransform.position, "Dodge!", "default"));
                }
            }

            return defended;
        }

        private static void Hit(Unit attacker, Unit defender)
        {
            Item meleeWeapon = attacker.GetMeleeWeapon();
            Item rangedWeapon = attacker.GetRangedWeapon();
            //WeaponData weaponData = null;
            
            if (meleeWeapon != null)
            {
                RollDamage(meleeWeapon, attacker, defender);
            }
            else if (rangedWeapon != null)
            {
                RollDamage(rangedWeapon, attacker, defender);
            }
        }
        
        private static void Hit(DamageEffect damageEffect, Unit attacker, Unit defender)
        {
            //RollDamage(meleeWeapon, attacker, defender);
            RollDamage(damageEffect, attacker, defender);
        }

        private static void Miss(Unit attacker, Unit defender)
        {
        }

        private static void RollDamage(Item weapon, Unit attacker, Unit defender)
        {
            if (weapon == null) return;
            
            WeaponData weaponData = weapon.GetWeaponData();
            
            if (weaponData != null)
            {
                if (weaponData.Projectile == null)
                {
                    for (int i = 0; i < weaponData.DamageEffects.Count; i++)
                    {
                        int minDamage = weaponData.DamageEffects[i].MinimumValue + attacker.Attributes.GetStatistic("Might Modifier").TotalCurrent();
                        int maxDamage = weaponData.DamageEffects[i].MaximumValue + attacker.Attributes.GetStatistic("Might Modifier").TotalCurrent();
                        int damage = Random.Range(minDamage, maxDamage + 1);

                        defender.Damage(attacker.gameObject, weaponData.DamageEffects[i].DamageType, damage, weaponData.DamageEffects[i].Attribute.Key);
                    }
                }
            }
        }
        
        private static void RollDamage(DamageEffect damageEffect, Unit attacker, Unit defender)
        {
            int minDamage = damageEffect.MinimumValue + attacker.Attributes.GetStatistic("Might Modifier").TotalCurrent();
            int maxDamage = damageEffect.MaximumValue + attacker.Attributes.GetStatistic("Might Modifier").TotalCurrent();
            int damage = Random.Range(minDamage, maxDamage + 1);
            defender.Damage(attacker.gameObject, damageEffect.DamageType, damage, damageEffect.Attribute.Key);
        }
    }
}
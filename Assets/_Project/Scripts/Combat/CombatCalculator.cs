using System.Collections;
using System.Collections.Generic;
using Descending.Abilities;
using Descending.Equipment;
using Descending.Units;
using UnityEngine;

namespace Descending.Combat
{
    
    public static class CombatCalculator
    {
        public static void ProcessAttack(Unit attacker, Unit defender)
        {
            if (TryDefense(defender))
            {
                Miss(attacker, defender);
            }
            else
            {
                Hit(attacker, defender);
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
            
            if (meleeWeapon != null)
            {
                RollDamage(meleeWeapon, attacker, defender);
            }
            else if (rangedWeapon != null)
            {
                RollDamage(rangedWeapon, attacker, defender);
            }
        }

        private static void Miss(Unit attacker, Unit defender)
        {
            Debug.Log("Miss!");
        }

        private static void RollDamage(Item weapon, Unit attacker, Unit defender)
        {
            WeaponData weaponData = weapon.GetWeaponData();
            
            for (int i = 0; i < weaponData.DamageEffects.Count; i++)
            {
                int minDamage = weaponData.DamageEffects[i].MinimumValue;// + attacker.Attributes.GetStatistic("Might Modifier").TotalCurrent();
                int maxDamage = weaponData.DamageEffects[i].MaximumValue;// + attacker.Attributes.GetStatistic("Might Modifier").TotalCurrent();
                int damage = Random.Range(minDamage, maxDamage + 1);
                //Debug.Log(defender.GetShortName() + " takes " + damage + " damage");
                defender.Damage(attacker.gameObject, weaponData.DamageEffects[i].DamageType, damage, weaponData.DamageEffects[i].Attribute.Key);
            }
        }
    }
}
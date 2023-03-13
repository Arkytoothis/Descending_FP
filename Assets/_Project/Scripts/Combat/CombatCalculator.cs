using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Equipment;
using Descending.Units;
using UnityEngine;

namespace Descending.Combat
{
    public static class CombatCalculator
    {
        public static void ProcessAttack(Unit attacker, Unit defender)
        {
            int attackRoll = Random.Range(0, 100);
            bool hit = false;
            
            if (attacker.GetEquippedWeapon().GetWeaponData().DamageClass == DamageClasses.Might)
            {
                if (attackRoll <= attacker.Attributes.GetStatistic("Attack").Current)
                {
                    Debug.Log("Attack Roll: " + attackRoll + " vs " + attacker.Attributes.GetStatistic("Attack").Current);
                    hit = true;
                }
            }
            else if (attacker.GetEquippedWeapon().GetWeaponData().DamageClass == DamageClasses.Finesse)
            {
                if (attackRoll <= attacker.Attributes.GetStatistic("Accuracy").Current)
                {
                    Debug.Log("Attack Roll: " + attackRoll + " vs " + attacker.Attributes.GetStatistic("Accuracy").Current);
                    hit = true;
                }
            }
            else if (attacker.GetEquippedWeapon().GetWeaponData().DamageClass == DamageClasses.Magic)
            {
                if (attackRoll <= attacker.Attributes.GetStatistic("Focus").Current)
                {
                    Debug.Log("Attack Roll: " + attackRoll + " vs " + attacker.Attributes.GetStatistic("Focus").Current);
                    hit = true;
                }
            }

            if (hit == true)
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
            else
            {
                Miss(attacker, defender);
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
                }
            }
            else
            {
                if (roll <= dodge)
                {
                    defended = true;
                }
            }

            return defended;
        }

        private static void Hit(Unit attacker, Unit defender)
        {
            Item weapon = attacker.GetEquippedWeapon();

            if (weapon.GetWeaponData().HasProjectile == false && weapon.GetWeaponData().ProjectileEffect != null)
            {
                RollDamage(weapon, attacker, defender);
            }
            else
            {
                RollDamage(weapon.GetWeaponData().ProjectileEffect.ProjectileDefinition, attacker, defender);
            }
        }

        private static void Miss(Unit attacker, Unit defender)
        {
            defender.DisplayDefaultText("Miss!");
        }

        private static void RollDamage(Item weapon, Unit attacker, Unit defender)
        {
            WeaponData weaponData = weapon.GetWeaponData();
            
            for (int i = 0; i < weaponData.DamageEffects.Count; i++)
            {
                int minDamage = weaponData.DamageEffects[i].MinimumValue;// + attacker.Attributes.GetStatistic("Might Modifier").TotalCurrent();
                int maxDamage = weaponData.DamageEffects[i].MaximumValue;// + attacker.Attributes.GetStatistic("Might Modifier").TotalCurrent();
                int damage = Random.Range(minDamage, maxDamage + 1);
                defender.Damage(attacker, weaponData.DamageEffects[i].DamageType, damage, weaponData.DamageEffects[i].Attribute.Key);
            }
        }

        private static void RollDamage(ProjectileDefinition projectile, Unit attacker, Unit defender)
        {
            for (int i = 0; i < projectile.DamageEffects.Count; i++)
            {
                int minDamage = projectile.DamageEffects[i].MinimumValue;// + attacker.Attributes.GetStatistic("Might Modifier").TotalCurrent();
                int maxDamage = projectile.DamageEffects[i].MaximumValue;// + attacker.Attributes.GetStatistic("Might Modifier").TotalCurrent();
                int damage = Random.Range(minDamage, maxDamage + 1);
                defender.Damage(attacker, projectile.DamageEffects[i].DamageType, damage, projectile.DamageEffects[i].Attribute.Key);
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using Descending.Combat;
using Descending.Core;
using UnityEngine;

namespace Descending.Equipment.Enchantments
{
    public class WeaponDamageEffect : EnchantmentEffect
    {
        [SerializeField] private DamageTypeDefinition _damageType = null;
        [SerializeField] private int _minDamage = 0;
        [SerializeField] private int _maxDamage = 0;

        public DamageTypeDefinition DamageType { get => _damageType; }
        public int MinDamage { get => _minDamage; }
        public int MaxDamage { get => _maxDamage; }

        public override string GetTooltipText()
        {
            string text = "";

            text = _minDamage + "-" + _maxDamage + " " + _damageType + " damage";

            return text;
        }
    }
}
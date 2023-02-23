using System.Collections;
using System.Collections.Generic;
using Descending.Combat;
using Descending.Core;
using UnityEngine;

namespace Descending.Equipment.Enchantments
{
    public class ResistanceModifierEffect : EnchantmentEffect
    {
        [SerializeField] private DamageTypeDefinition _resistance = null;
        [SerializeField] private int _modifier = 0;

        public DamageTypeDefinition Resistance { get => _resistance; }
        public int Modifer { get => _modifier; }

        public override string GetTooltipText()
        {
            string text = "";

            if (_modifier < 0)
            {
                text = _modifier + "% " + _resistance;
            }
            else if (_modifier >= 0)
            {
                text = "+" + _modifier + "% " + _resistance;
            }

            text += " Resistance";

            return text;
        }
    }
}
using Descending.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Equipment.Enchantments
{
    public class SkillModifierEffect : EnchantmentEffect
    {
        [SerializeField] private string _skill = "";
        [SerializeField] private int _modifier = 0;

        public string Skill { get => _skill; }
        public int Modifer { get => _modifier; }

        public override string GetTooltipText()
        {
            string text = "";

            if (_modifier < 0)
            {
                text = _modifier + " " + _skill;
            }
            else if (_modifier >= 0)
            {
                text = "+" + _modifier + " " + _skill;
            }

            return text;
        }
    }
}
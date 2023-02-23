using Descending.Core;
using System.Collections;
using System.Collections.Generic;
using Descending.Attributes;
using UnityEngine;

namespace Descending.Equipment.Enchantments
{
    [System.Serializable]
    public class ModifyAttributeEnchantmentEffect : EnchantmentEffect
    {
        [SerializeField] private AttributeDefinition _attributeDefinition = null;
        [SerializeField] private int _modifier = 0;

        public AttributeDefinition AttributeDefinition => _attributeDefinition;
        public int Modifier => _modifier;

        public override string GetTooltipText()
        {
            string text = "";

            if (_modifier < 0)
            {
                text = _modifier + " " + _attributeDefinition.Name;
            }
            else if (_modifier >= 0)
            {
                text = "+" + _modifier + " " + _attributeDefinition.Name;
            }

            return text;
        }
    }
}
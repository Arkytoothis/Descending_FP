using System.Collections;
using System.Collections.Generic;
using System.Text;
using Descending.Abilities;
using Descending.Attributes;
using UnityEngine;

namespace Descending.Units
{
    [System.Serializable]
    public class ModifyAttributeUnitEffect : UnitEffect
    {
        [SerializeField] private AttributeDefinition _attributeDefinition = null;
        [SerializeField] private int _modifier = 0;

        public AttributeDefinition AttributeDefinition => _attributeDefinition;
        public int Modifier => _modifier;

        public ModifyAttributeUnitEffect(AbilityEffect abilityEffect)
        {
            if (abilityEffect is ModifyAttributeAbilityEffect unitEffect)
            {
                ModifyAttributeAbilityEffect modifyAttributeAbilityEffect = (ModifyAttributeAbilityEffect)abilityEffect;
                _icon =  modifyAttributeAbilityEffect.Icon;
                _attributeDefinition = unitEffect.Attribute;
                _duration = Random.Range(unitEffect.MinimumDuration, unitEffect.MaximumDuration + 1);
                _modifier = Random.Range(unitEffect.MinimumModifier, unitEffect.MaximumModifier + 1);
            }
        }

        public override string GetTooltipHeading()
        {
            if (_modifier < 0)
            {
                return "Reduce Attribute";
            }
            else
            {
                return "Increase Attribute";
            }
        }

        public override string GetTooltipText()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(_attributeDefinition.Name);

            if (_modifier < 0)
            {
                sb.Append(" ").Append(_modifier);
            }
            else
            {
                sb.Append(" +").Append(_modifier);
            }

            return sb.ToString();
        }
    }
}
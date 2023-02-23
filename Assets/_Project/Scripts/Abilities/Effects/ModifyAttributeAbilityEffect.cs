using System.Collections.Generic;
using Descending.Core;
using System.Text;
using Descending.Attributes;
using Descending.Units;
using UnityEngine;

namespace Descending.Abilities
{
    [System.Serializable]
    public class ModifyAttributeAbilityEffect : AbilityEffect
    {
        [SerializeField] private Sprite _icon = null;
        [SerializeField] private AttributeDefinition _attribute = null;
        [SerializeField] private int _minimumDuration = 0;
        [SerializeField] private int _maximumDuration = 0;
        [SerializeField] private int _minimumModifier = 0;
        [SerializeField] private int _maximumModifier = 0;

        public Sprite Icon => _icon;
        public AttributeDefinition Attribute => _attribute;
        public int MinimumDuration => _minimumDuration;
        public int MaximumDuration => _maximumDuration;
        public int MinimumModifier => _minimumModifier;
        public int MaximumModifier => _maximumModifier;

        public override string GetTooltipText()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Increases ").Append(_attribute.Name).Append(" by ").Append(_minimumModifier);

            if (_maximumModifier > _minimumModifier)
                sb.Append(" - ").Append(_maximumModifier).Append("\n");
            else
                sb.Append("\n");

            sb.Append(" for ").Append(_minimumDuration).Append("-").Append(_maximumDuration).Append(" turns");
            
            return sb.ToString();
        }

        public override void Process(Unit user, List<Unit> targets)
        {
            if (_affects == AbilityEffectAffects.User)
            {
            }
            else if (_affects == AbilityEffectAffects.Target)
            {
                foreach (Unit target in targets)
                {
                    //Debug.Log("Buffing " + _attribute.Name + " " + target.name);
                    target.AddUnitEffect(this);
                }
            }
        }
    }
}
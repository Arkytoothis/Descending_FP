using System.Collections.Generic;
using System.Text;
using Descending.Attributes;
using Descending.Core;
using Descending.Units;
using UnityEngine;

namespace Descending.Abilities
{
    [System.Serializable]
    public class RestoreEffect : AbilityEffect
    {
        [SerializeField] private AttributeDefinition _attribute = null;
        [SerializeField] private int _minimumValue = 0;
        [SerializeField] private int _maximumValue = 0;

        public override string GetTooltipText()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Restores ").Append(_minimumValue).Append(" - ").Append(_maximumValue).Append(" ").Append(_attribute.Name).Append("\n");

            return sb.ToString();
        }

        public override void Process(Ability ability, Unit user, List<Unit> targets)
        {
            if (_affects == AbilityEffectAffects.User)
            {
                int amount = Random.Range(_minimumValue, _maximumValue + 1);
                user.RestoreVital(_attribute.Key, amount);
            }
            else if (_affects == AbilityEffectAffects.Target)
            {
                foreach (Unit entity in targets)
                {
                    int amount = Random.Range(_minimumValue, _maximumValue + 1);
                    entity.RestoreVital(_attribute.Key, amount);
                }
            }
        }
    }
}
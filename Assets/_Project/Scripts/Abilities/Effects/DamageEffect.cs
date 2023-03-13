using System.Collections.Generic;
using System.Text;
using Descending.Attributes;
using Descending.Combat;
using Descending.Core;
using Descending.Units;
using UnityEngine;

namespace Descending.Abilities
{
    [System.Serializable]
    public class DamageEffect : AbilityEffect
    {
        [SerializeField] private DamageTypeDefinition _damageType = null;
        [SerializeField] private AttributeDefinition _attribute = null;
        [SerializeField] private int _minimumValue = 0;
        [SerializeField] private int _maximumValue = 0;

        public DamageTypeDefinition DamageType => _damageType;
        public AttributeDefinition Attribute => _attribute;
        public int MinimumValue => _minimumValue;
        public int MaximumValue => _maximumValue;

        public override string GetTooltipText()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Causes ").Append(_minimumValue).Append(" - ").Append(_maximumValue).Append(" ").Append(_damageType.Name).Append(" damage\n");

            return sb.ToString();
        }

        public override void Process(Ability ability, Unit user, List<Unit> targets)
        {
            if (_affects == AbilityEffectAffects.User)
            {
            }
            else if (_affects == AbilityEffectAffects.Target)
            {
                foreach (Unit target in targets)
                {
                    CombatCalculator.ProcessAttack(user, target);
                    //int amount = Random.Range(_minimumValue, _maximumValue + 1);
                    //unit.Damage(user.gameObject, amount);
                }
            }
        }
    }
}
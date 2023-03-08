using Descending.Core;
using System.Collections.Generic;
using System.Text;
using Descending.Attributes;
using Descending.Units;
using UnityEngine;

namespace Descending.Abilities
{
    [System.Serializable]
    public class RestoreOverTimeEffect : AbilityEffect
    {
        [SerializeField] private AttributeDefinition _attribute = null;
        [SerializeField] private int _minimumValue = 0;
        [SerializeField] private int _maximumValue = 0;
        [SerializeField] private int _minimumDuration = 0;
        [SerializeField] private int _maximumDuration = 0;

        public AttributeDefinition Attribute => _attribute;
        public int MinimumValue => _minimumValue;
        public int MaximumValue => _maximumValue;
        public int MinimumDuration => _minimumDuration;
        public int MaximumDuration => _maximumDuration;

        public override string GetTooltipText()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Restores ").Append(_minimumValue).Append(" - ").Append(_maximumValue).Append(" ").Append(_attribute.Name);
            sb.Append(" for ").Append(_minimumDuration).Append(" - ").Append(_maximumDuration).Append(" rounds\n");

            return sb.ToString();
        }

        public override void Process(Ability ability, Unit user, List<Unit> targets)
        {
            foreach (Unit target in targets)
            {
                //Debug.Log("Buffing " + _attribute.Name + " " + target.name);
                target.AddUnitEffect(ability);
            }
            
            // if (character.GetType() == typeof(PlayerCharacter))
            // {
            //     PlayerCharacter pc = (PlayerCharacter)character;
            //
            //     if (pc != null)
            //     {
            //         int amount = Random.Range(_minimumValue, _maximumValue + 1);
            //         pc.RestoreDamage(DerivedAttribute.Life, amount, false);
            //     }
            // }
            // else if (character.GetType() == typeof(Enemy))
            // {
            //     Enemy enemy = (Enemy)character;
            //
            //     if (enemy != null)
            //     {
            //         int amount = Random.Range(_minimumValue, _maximumValue + 1);
            //         enemy.RestoreDamage(DerivedAttribute.Life, amount, false);
            //     }
            // }
        }

        public int RollRestoreAmount()
        {
            return Random.Range(_minimumValue, _maximumValue + 1);
        }
    }
}
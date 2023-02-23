using System.Text;
using Descending.Combat;
using Descending.Core;
using UnityEngine;

namespace Descending.Abilities
{
    [System.Serializable]
    public class DamageOverTimeEffect : AbilityEffect
    {
        [SerializeField] private DamageTypeDefinition _damageType = null;
        [SerializeField] private int _minimumValue = 0;
        [SerializeField] private int _maximumValue = 0;
        [SerializeField] private int _minimumDuration = 0;
        [SerializeField] private int _maximumDuration = 0;

        public DamageTypeDefinition DamageType { get => _damageType; }
        public int MinimumValue { get => _minimumValue; }
        public int MaximumValue { get => _maximumValue; }
        public int MinimumDuration { get => _minimumDuration; }
        public int MaximumDuration { get => _maximumDuration; }

        public override string GetTooltipText()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Causes ").Append(_minimumValue).Append(" - ").Append(_maximumValue).Append(" ").Append(_damageType).Append(" damage");
            sb.Append(" for ").Append(_minimumDuration).Append(" - ").Append(_maximumDuration).Append(" rounds\n");

            return sb.ToString();
        }
    }
}
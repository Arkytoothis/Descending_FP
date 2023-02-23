using Descending.Core;
using System.Text;
using UnityEngine;

namespace Descending.Abilities
{
    [System.Serializable]
    public class StunEffect : AbilityEffect
    {
        [SerializeField] private int _minimumValue = 0;
        [SerializeField] private int _maximumValue = 0;

        public int MinimumValue { get => _minimumValue; }
        public int MaximumValue { get => _maximumValue; }

        public override string GetTooltipText()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Stuns target (loses ").Append(_minimumValue).Append(" - ").Append(_maximumValue).Append(" actions)\n");

            return sb.ToString();
        }
    }
}
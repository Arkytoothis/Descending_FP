using Descending.Core;
using System.Text;
using UnityEngine;

namespace Descending.Abilities
{
    [System.Serializable]
    public class ModifySkillEffect : AbilityEffect
    {
        //[SerializeField] private Skill _skill = Skill.None;
        [SerializeField] private int _minimumValue = 0;
        [SerializeField] private int _maximumValue = 0;

        //public Skill Skill { get => _skill; }
        public int MinimumValue { get => _minimumValue; }
        public int MaximumValue { get => _maximumValue; }

        public override string GetTooltipText()
        {
            StringBuilder sb = new StringBuilder();

            //sb.Append("Increases ").Append(_skill).Append(" by ").Append(_minimumValue);

            if (_maximumValue > _minimumValue)
                sb.Append(" - ").Append(_maximumValue).Append("\n");
            else
                sb.Append("\n");

            return sb.ToString();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Descending.Core;

namespace Descending.Attributes
{
    [System.Serializable]
    public class StartingSkill
    {
        [SerializeField] private SkillDefinition _skill = null;
        [SerializeField] private int _minimumValue = 0;
        [SerializeField] private int _maximumValue = 0;

        public SkillDefinition Skill => _skill;
        public int MinimumValue => _minimumValue;
        public int MaximumValue => _maximumValue;
    }
}
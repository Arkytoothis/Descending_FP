using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Abilities
{
    [System.Serializable]
    public class AbilityTreeEntry
    {
        [SerializeField] private AbilityDefinition _ability = null;
        [SerializeField] private int _pointsRequired = 0;

        public AbilityDefinition Ability => _ability;
        public int PointsRequired => _pointsRequired;

        public AbilityTreeEntry(AbilityDefinition ability, int pointsRequired)
        {
            _ability = ability;
            _pointsRequired = pointsRequired;
        }
    }
}
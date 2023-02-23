using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Descending.Core;

namespace Descending.Attributes
{
    [System.Serializable]
    public class StartingStatistic
    {
        [SerializeField] private AttributeDefinition _derived = null;
        [SerializeField] private int _minimumValue = 0;
        [SerializeField] private int _maximumValue = 0;

        public AttributeDefinition Derived => _derived;
        public int MinimumValue => _minimumValue;
        public int MaximumValue => _maximumValue;
    }
}
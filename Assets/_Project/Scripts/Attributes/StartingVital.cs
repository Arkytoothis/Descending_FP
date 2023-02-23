using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Descending.Core;

namespace Descending.Attributes
{
    [System.Serializable]
    public class StartingVital
    {
        [SerializeField] private AttributeDefinition _vital = null;
        [SerializeField] private int _minimumValue = 0;
        [SerializeField] private int _maximumValue = 0;

        public AttributeDefinition Vital => _vital;
        public int MinimumValue => _minimumValue;
        public int MaximumValue => _maximumValue;
    }
}
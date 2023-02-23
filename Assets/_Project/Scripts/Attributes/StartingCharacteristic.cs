using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Descending.Core;

namespace Descending.Attributes
{
    [System.Serializable]
    public class StartingCharacteristic
    {
        [SerializeField] private AttributeDefinition _attribute = null;
        [SerializeField] private int _minimumValue = 0;
        [SerializeField] private int _maximumValue = 0;

        public AttributeDefinition Attribute => _attribute;
        public int MinimumValue => _minimumValue;
        public int MaximumValue => _maximumValue;
    }
}
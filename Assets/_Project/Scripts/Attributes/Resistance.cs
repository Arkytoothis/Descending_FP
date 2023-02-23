using System.Collections;
using System.Collections.Generic;
using Descending.Combat;
using Descending.Core;
using UnityEngine;

namespace Descending.Attributes
{
    [System.Serializable]
    public class Resistance
    {
        [SerializeField] private string _damageType;
        [SerializeField] private int _currentValue = 0;
        [SerializeField] private int _maximumValue = 0;
        
        public string DamageType => _damageType;
        public int CurrentValue => _currentValue;
        public int MaximumValue => _maximumValue;

        
        public Resistance(DamageTypeDefinition damageType, int maximum)
        {
            _damageType = damageType.Key;
            _currentValue = maximum;
            _maximumValue = maximum;
        }

        public void SetResistance(Resistance resistance)
        {
            _damageType = resistance._damageType;
            _currentValue = resistance._maximumValue;
            _maximumValue = resistance._maximumValue;
        }
    }
}
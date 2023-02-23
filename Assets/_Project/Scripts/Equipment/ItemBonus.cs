using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Equipment
{
    public enum BonusType
    {
        Base_Attribute, Derived_Attribute, Skill, Resistance,
        Number, None
    }

    [System.Serializable]
    public class ItemBonus
    {
        [SerializeField] private BonusType _bonusType = BonusType.None;
        [SerializeField] private int _attribute = -1;
        [SerializeField] private int _value = 0;

        public BonusType BonusType { get => _bonusType; }
        public int Attribute { get => _attribute; }
        public int Value { get => _value; }
    }
}
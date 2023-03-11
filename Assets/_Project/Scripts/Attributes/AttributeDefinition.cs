using Descending.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Attributes
{
    public enum AttributeTypes { Characteristic, Vital, Statistic, Resistance, Number, None }
    
    [CreateAssetMenu(fileName = "Attribute Definition", menuName = "Descending/Definition/Attribute Definition")]
    public class AttributeDefinition : ScriptableObject
    {
        [SerializeField] private AttributeTypes _attributeType = AttributeTypes.None;
        [SerializeField] private string _name = "";
        [SerializeField] private string _key = "";
        [SerializeField] private Color _vitalBarColor = Color.white;
        [SerializeField] private Color _damageColor = Color.white;
        [SerializeField] private Color _healColor = Color.white;

        public AttributeTypes AttributeType => _attributeType;
        public string Name => _name;
        public string Key => _key;
        public Color VitalBarColor => _vitalBarColor;
        public Color DamageColor => _damageColor;
        public Color HealColor => _healColor;
    }
}
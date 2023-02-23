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
        [SerializeField] private Sprite _largeIcon = null;
        [SerializeField] private Sprite _smallIcon = null;
        [SerializeField] private Color _color = Color.white;
        [SerializeField] private Color _darkColor = Color.white;

        public AttributeTypes AttributeType => _attributeType;
        public string Name => _name;
        public string Key => _key;
        public Color Color => _color;
        public Color DarkColor => _darkColor;
        public Sprite LargeIcon => _largeIcon;
        public Sprite SmallIcon => _smallIcon;

        //public CharacterAttribute ConvertToAttribute()
        //{
        //    return new CharacterAttribute(_type, _attribute.ToString(), (int)_attribute, 0, 0, 0, 0, 0);
        //}
    }
}
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using UnityEngine;

namespace Descending.Attributes
{
    [CreateAssetMenu(fileName = "Attributes Database", menuName = "Descending/Database/Attributes Database")]
    public class AttributeDatabase : ScriptableObject
	{
        [SerializeField] private AttributeDefinitionDictionary _attributes = null;
        [SerializeField] private AttributeDefinitionDictionary _vitals = null;
        [SerializeField] private AttributeDefinitionDictionary _statistics = null;

        public AttributeDefinitionDictionary Attributes => _attributes;
        public AttributeDefinitionDictionary Vitals => _vitals;
        public AttributeDefinitionDictionary Statistics => _statistics;

        public AttributeDefinition GetAttribute(string key)
        {
            return _attributes[key];
        }

        public AttributeDefinition GetVital(string key)
        {
            return _vitals[key];
        }
        
        public AttributeDefinition GetStatistic(string key)
        {
            return _statistics[key];
        }
    }
}
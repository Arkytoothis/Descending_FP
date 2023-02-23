using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using UnityEngine;

namespace Descending.Features
{
    [CreateAssetMenu(fileName = "Feature Database", menuName = "Descending/Database/Feature Database")]
    public class FeatureDatabase : ScriptableObject
    {
        [SerializeField] private FeatureDefinitionDictionary _features = null;

        public FeatureDefinitionDictionary Features => _features;

        public FeatureDefinition GetFeature(string key)
        {
            return _features[key];
        }
    }
}
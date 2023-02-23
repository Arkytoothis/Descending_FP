using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Features
{
    [CreateAssetMenu(fileName = "Feature Definition", menuName = "Descending/Definition/Feature Definition")]
    public class FeatureDefinition : ScriptableObject
    {
        public string Name = "";
        public string Key = "";
        public GameObject Prefab = null;
    }
}
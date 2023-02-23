using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Descending.Core;
using UnityEngine;

namespace Descending.Abilities
{
    [CreateAssetMenu(fileName = "Ability Database", menuName = "Descending/Database/Ability Database")]
    public class AbilityDatabase : ScriptableObject
    {
        [SerializeField] private AbilityDefinitionDictionary _abilities = null;
        public AbilityDefinitionDictionary Abilities { get => _abilities; }

        public AbilityDefinition GetAbility(string key)
        {
            if (_abilities.ContainsKey(key) == false)
            {
                Debug.Log("Ability Key: " + key + " does not exist");
                return null;
            }
            
            return _abilities[key];
        }
    }
}
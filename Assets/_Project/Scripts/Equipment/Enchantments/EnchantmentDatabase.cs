using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Descending.Core;
using UnityEngine;

namespace Descending.Equipment.Enchantments
{
    [CreateAssetMenu(fileName = "Enchantment Database", menuName = "Descending/Database/Enchantment Database")]
    public class EnchantmentDatabase : ScriptableObject
    {
        [SerializeField] private EnchantsDictionary _enchantments = null;
        public EnchantsDictionary Enchantments { get => _enchantments; }

        public EnchantmentDefinition GetEnchant(string key)
        {
            //Debug.Log(key);
            
            if (_enchantments.ContainsKey(key))
            {
                return _enchantments[key];
            }
            else
            {
                return null;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using Descending.Equipment.Enchantments;
using UnityEngine;

namespace Descending.Equipment
{
    [System.Serializable]
    public class ItemShort
    {
        [SerializeField] private ItemDefinition _item = null;
        [SerializeField] private MaterialDefinition _material = null;
        [SerializeField] private EnchantmentDefinition _quality = null;
        [SerializeField] private EnchantmentDefinition _prefix = null;
        [SerializeField] private EnchantmentDefinition _suffix = null;

        public ItemDefinition Item => _item;
        public MaterialDefinition Material => _material;
        public EnchantmentDefinition Quality => _quality;
        public EnchantmentDefinition Prefix => _prefix;
        public EnchantmentDefinition Suffix => _suffix;

        public ItemShort(ItemDefinition itemDefinition, EnchantmentDefinition quality, MaterialDefinition material = null, EnchantmentDefinition prefix = null, EnchantmentDefinition suffix = null)
        {
            _item = itemDefinition;
            _material = material;
            _quality = quality;
            _prefix = prefix;
            _suffix = suffix;
        }
    }
}
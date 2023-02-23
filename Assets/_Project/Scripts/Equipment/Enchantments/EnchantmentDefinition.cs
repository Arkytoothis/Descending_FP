using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using UnityEngine;

namespace Descending.Equipment.Enchantments
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "Enchantment Definition", menuName = "Descending/Definition/Enchantment Definition")]
    public class EnchantmentDefinition : ScriptableObject
    {
        [SerializeField] private string _name = "";
        [SerializeField] private string _key = "";
        [SerializeField] private RarityDefinition _rarity = null;
        [SerializeField] private EnchantmentType _enchantmentType = EnchantmentType.None;
        [SerializeField] private EnchantmentUsability _usability = EnchantmentUsability.None;
        [SerializeField] private int _goldValue = 0;
        [SerializeField] private int _gemValue = 0;
        [SerializeField] private int _itemPower = 0;
        [SerializeField] private float _encumbranceModifier = 0f;

        [SerializeReference] private List<EnchantmentEffect> _effects = null;

        public string Name => _name;
        public string Key => _key;
        public RarityDefinition Rarity => _rarity;
        public EnchantmentType EnchantmentType => _enchantmentType;
        public EnchantmentUsability Usability => _usability;
        public List<EnchantmentEffect> Effects => _effects;
        public int GoldValue => _goldValue;
        public int GemValue => _gemValue;
        public int ItemPower => _itemPower;
        public float EncumbranceModifier => _encumbranceModifier;
    }
}
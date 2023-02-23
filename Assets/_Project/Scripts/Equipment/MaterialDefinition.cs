using System.Collections;
using System.Collections.Generic;
using System.Text;
using Descending.Core;
using UnityEngine;

namespace Descending.Equipment
{
    [CreateAssetMenu(fileName = "Material Definition", menuName = "Descending/Definition/Material Definition")]
    public class MaterialDefinition : ScriptableObject
	{
        [SerializeField] private string _key = "";
        [SerializeField] private string _name = "";
        [SerializeField] private ItemMaterialType _materialType = ItemMaterialType.None;
        [SerializeField] private RarityDefinition _rarity = null;
        [SerializeField] private Color _color = Color.white;
        [SerializeField] private float _mightModifier = 0f;
        [SerializeField] private float _finesseModifier = 0f;
        [SerializeField] private float _spellModifier = 0f;
        [SerializeField] private int _itemPower = 0;
        [SerializeField] private float _encumbranceModifier = 0;
        [SerializeField] private int _goldValue = 0;
        [SerializeField] private int _gemValue = 0;

        public string Key => _key;
        public string Name => _name;
        public ItemMaterialType MaterialType => _materialType;
        public RarityDefinition Rarity => _rarity;
        public Color Color => _color;
        public float MightModifier => _mightModifier;
        public float FinesseModifier => _finesseModifier;
        public float SpellModifier => _spellModifier;
        public int ItemPower => _itemPower;
        public float EncumbranceModifier => _encumbranceModifier;
        public int GoldValue => _goldValue;
        public int GemValue => _gemValue;


        public string GetTooltipText()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(_name + "\n");

            if (_mightModifier != 0) sb.Append("Might " + _mightModifier + "%  ");
            if (_finesseModifier != 0) sb.Append("Finesse " + _finesseModifier + "%  ");
            if (_spellModifier != 0) sb.Append("Spell " + _spellModifier + "%");

            if(_mightModifier != 0 || _finesseModifier != 0 || _spellModifier != 0)
                sb.Append("\n");

            sb.Append("Power " + _itemPower);
            sb.Append("\tEnc " + _encumbranceModifier + "\n");

            return sb.ToString();
        }
    }
}
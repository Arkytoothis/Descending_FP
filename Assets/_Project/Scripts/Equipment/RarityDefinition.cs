using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Descending.Core;

namespace Descending.Equipment
{
    [CreateAssetMenu(fileName = "Rarity Definition", menuName = "Descending/Definition/Rarity Definition")]
    public class RarityDefinition : ScriptableObject
    {
        [SerializeField] private string _name = "";
        [SerializeField] private string _key = "";
        [SerializeField] private int _order = 0;
        [SerializeField] private Color _color = Color.white;
        [SerializeField] private int _minimumPower = 0;
        [SerializeField] private int _maximumPower = 0;

        public string Name => _name;
        public string Key => _key;
        public int Order => _order;
        public Color Color => _color;
        public int MinimumPower => _minimumPower;
        public int MaximumPower => _maximumPower;
    }
}
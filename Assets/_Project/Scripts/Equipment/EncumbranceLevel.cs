using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Equipment
{
    [CreateAssetMenu(fileName = "Encumbrance Level", menuName = "Descending/Definition/Encumbrance Level")]
    public class EncumbranceLevel : ScriptableObject
    {
        [SerializeField] private string _name = "";
        [SerializeField] private Color _textColor = Color.white;
        [SerializeField] private float _initiativeModifier = 0f;
        [SerializeField] private float _attackModifier = 0f;
        [SerializeField] private float _defenseModifier = 0f;

        public string Name { get => _name; }
        public Color TextColor { get => _textColor; }
        public float InitiativeModifier { get => _initiativeModifier; }
        public float AttackModifier { get => _attackModifier; }
        public float DefenseModifier { get => _defenseModifier; }
    }
}
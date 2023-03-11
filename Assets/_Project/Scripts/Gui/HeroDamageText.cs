using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Gui
{
    [System.Serializable]
    public class HeroDamageText
    {
        [SerializeField] private int _listIndex = -1;
        [SerializeField] private int _damage = 0;
        [SerializeField] private Color _color = Color.white;

        public int ListIndex => _listIndex;
        public int Damage => _damage;
        public Color Color => _color;

        public HeroDamageText(int listIndex, int damage, Color color)
        {
            _listIndex = listIndex;
            _damage = damage;
            _color = color;
        }
    }
}
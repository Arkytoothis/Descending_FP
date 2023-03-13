using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Gui
{
    [System.Serializable]
    public class HeroDamageText
    {
        [SerializeField] private int _listIndex = -1;
        [SerializeField] private string _text = "";
        [SerializeField] private Color _color = Color.white;

        public int ListIndex => _listIndex;
        public string Text => _text;
        public Color Color => _color;

        public HeroDamageText(int listIndex, int damage, Color color)
        {
            _listIndex = listIndex;
            _text = damage.ToString();
            _color = color;
        }

        public HeroDamageText(int listIndex, string text, Color color)
        {
            _listIndex = listIndex;
            _text = text;
            _color = color;
        }
    }
}
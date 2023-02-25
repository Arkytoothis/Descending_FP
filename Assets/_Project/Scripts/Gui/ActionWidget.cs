using System.Collections;
using System.Collections.Generic;
using Descending.Abilities;
using Descending.Core;
using Descending.Equipment;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Descending.Gui
{
    public class ActionWidget : MonoBehaviour
    {
        [SerializeField] private Image _icon = null;
        [SerializeField] private Image _cooldownImage = null;
        [SerializeField] private TMP_Text _hotKeyLabel = null;
        [SerializeField] private TMP_Text _cooldownLabel = null;

        private int _index = -1;
        private Ability _ability = null;
        private Item _item = null;
        
        public void Setup(int index, string hotKey)
        {
            _index = index;
            _hotKeyLabel.SetText(hotKey);
            Clear();
        }

        public void SetAbility(Ability ability)
        {
            _ability = ability;
            _icon.sprite = _ability.Definition.Icon;
            _item = null;
        }

        public void SetItem(Item item)
        {
            _item = item;
            _icon.sprite = _item.ItemDefinition.Icon;
            _ability = null;
        }
        
        public void Clear()
        {
            _index = -1;
            _icon.sprite = Database.instance.BlankSprite;
        }
    }
}

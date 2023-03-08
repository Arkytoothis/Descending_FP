using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Equipment;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Descending.Gui
{
    public class EquippedWeaponWidget : MonoBehaviour
    {
        [SerializeField] private TMP_Text _item1NameLabel = null;
        [SerializeField] private Image _item1NameIcon = null;
        [SerializeField] private TMP_Text _item2NameLabel = null;
        [SerializeField] private Image _item2NameIcon = null;
        [SerializeField] private Image _border = null;

        public void Setup()
        {
            
        }

        public void SetItems(Item item1, Item item2)
        {
            if(item1 != null)
            {
                _item1NameLabel.text = item1.ItemDefinition.Name;
                _item1NameIcon.sprite = item1.ItemDefinition.Icon;
            }
            else
            {
                _item1NameLabel.text = "";
                _item1NameIcon.sprite = Database.instance.BlankSprite;
            }
            
            if(item2 != null)
            {
                _item2NameLabel.text = item2.ItemDefinition.Name;
                _item2NameIcon.sprite = item2.ItemDefinition.Icon;
            }
            else
            {
                _item2NameLabel.text = "";
                _item2NameIcon.sprite = Database.instance.BlankSprite;
            }
        }

        public void Select()
        {
            _border.enabled = true;
        }

        public void Deselect()
        {
            _border.enabled = false;
        }
    }
}

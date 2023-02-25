using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Equipment;
using Descending.Units;
using UnityEngine;
using UnityEngine.UI;

namespace Descending.Gui
{
    public class HeroEquipmentPanel : MonoBehaviour
    {
        [SerializeField] private RawImage _portraitImage = null;

        [SerializeField] private EquippedItemWidget[] _equippedItemWidgets = null;
        [SerializeField] private AccessoryWidget[] _accessoryWidgets = null;

        public void Setup()
        {
            for (int i = 0; i < (int)EquipmentSlots.Number; i++)
            {
                _equippedItemWidgets[i].Setup(i);
            }
            
            for (int i = 0; i < _accessoryWidgets.Length; i++)
            {
                _accessoryWidgets[i].Setup(i);
            }
        }
        
        public void DisplayHero(Hero hero)
        {
            _portraitImage.texture = hero.Portrait.RtFar;

            for (int i = 0; i < (int)EquipmentSlots.Number; i++)
            {
                _equippedItemWidgets[i].SetItem(hero.Inventory.Equipment[i]);
            }
            
            for (int i = 0; i < InventoryController.MAX_ACCESSORY_SLOTS; i++)
            {
                _accessoryWidgets[i].SetItem(hero.Inventory.Accessories[i]);
            }
        }
    }
}
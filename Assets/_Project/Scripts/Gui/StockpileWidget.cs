using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Equipment;
using Descending.Units;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Descending.Gui
{
    public class StockpileWidget : DragableItemWidget, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
    {
        [SerializeField] private Image _iconImage = null;
        [SerializeField] private TMP_Text _stackSizeLabel = null;

        [SerializeField] private ItemEvent onDisplayItemTooltip = null;

        public void Setup(int index)
        {
            _item = null;
            _index = index;
            _stackSizeLabel.SetText(_index.ToString());
        }

        public override void SetItem(Item item)
        {
            _item = item;

            if (_item != null)
            {
                _iconImage.sprite = item.Icon;

                if (_item.UsesLeft > 0)
                {
                    _stackSizeLabel.SetText(_item.UsesLeft + "/" + _item.MaxUses);
                }
                else
                {
                    _stackSizeLabel.SetText(_item.StackSize.ToString());
                }
            }
            else
            {
                Clear();
            }
        }

        public override void Clear()
        {
            _item = null;
            _iconImage.sprite = Database.instance.BlankSprite;
            _stackSizeLabel.SetText("");
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            onDisplayItemTooltip.Invoke(_item);
            eventData.pointerPress = gameObject;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            onDisplayItemTooltip.Invoke(null);
        }

        public void OnDrag(PointerEventData eventData)
        {
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (_item == null || _item.ItemDefinition.Key == "") return;
            
            //DragCursor.Instance.BeginDrag(eventData, this);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            // if (DragCursor.Instance.IsDragging == true)
            // {
            // }
        }

        public void OnDrop(PointerEventData eventData)
        {
            // if (DragCursor.Instance.IsDragging == true)
            // {
            //     if (_item != null &&_item.ItemDefinition.Key != "")
            //     {
            //         Item tempItem = new Item(_item);
            //         
            //         StockpileManager.Instance.SetItem(DragCursor.Instance.DragItem, _index);
            //         SetItem(DragCursor.Instance.DragItem);
            //
            //         if (DragCursor.Instance.StartDragWidget.GetType() == typeof(StockpileWidget))
            //         {
            //             StockpileManager.Instance.SetItem(tempItem, DragCursor.Instance.StartDragWidget.Index);
            //         }
            //         else if (DragCursor.Instance.StartDragWidget.GetType() == typeof(EquippedItemWidget))
            //         {
            //             HeroManager_Combat.Instance.SelectedHero.Inventory.EquipItem(tempItem, DragCursor.Instance.StartDragWidget.Index);
            //         }
            //         else if (DragCursor.Instance.StartDragWidget.GetType() == typeof(AccessoryWidget))
            //         {
            //             HeroManager_Combat.Instance.SelectedHero.Inventory.EquipAccessory(tempItem, DragCursor.Instance.StartDragWidget.Index);
            //         }
            //
            //         DragCursor.Instance.StartDragWidget.SetItem(tempItem);
            //     }
            //     else
            //     {
            //         StockpileManager.Instance.SetItem(DragCursor.Instance.DragItem, _index);
            //         SetItem(DragCursor.Instance.DragItem);
            //
            //         if (DragCursor.Instance.StartDragWidget.GetType() == typeof(StockpileWidget))
            //         {
            //             StockpileManager.Instance.ClearItem(DragCursor.Instance.StartDragWidget.Index);
            //         }
            //         else if (DragCursor.Instance.StartDragWidget.GetType() == typeof(EquippedItemWidget))
            //         {
            //             HeroManager_Combat.Instance.SelectedHero.Inventory.UnequipItem(DragCursor.Instance.StartDragWidget.Index, false);
            //         }
            //         else if (DragCursor.Instance.StartDragWidget.GetType() == typeof(AccessoryWidget))
            //         {
            //             HeroManager_Combat.Instance.SelectedHero.Inventory.ClearAccessory(DragCursor.Instance.StartDragWidget.Index);
            //         }
            //     }
            //
            //     DragCursor.Instance.StartDragWidget.Clear();
            //     DragCursor.Instance.EndDrag(eventData);
            //     StockpileManager.Instance.SyncStockpile();
            //     HeroManager_Combat.Instance.SyncHeroes();
            //     HeroManager_Combat.Instance.RefreshSelectedHero();
            // }
        }
    }
}
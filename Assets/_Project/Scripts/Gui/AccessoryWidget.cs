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
    public class AccessoryWidget : DragableItemWidget, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
    {
        [SerializeField] private Image _iconImage = null;
        [SerializeField] private TMP_Text _stackSizeLabel = null;

        [SerializeField] private ItemEvent onDisplayItemTooltip = null;
        [SerializeField] private BoolEvent onSyncSelectedHero = null;
        
        public void Setup(int index)
        {
            _item = null;
            _index = index;
            _stackSizeLabel.SetText(_index.ToString());
        }
        
        public override void SetItem(Item item)
        {
            _item = item;

            if (_item != null && _item.IsEmpty() == false)
            {
                UsableData usableData = _item.GetUsableData();
                
                _iconImage.sprite = item.Icon;
                _stackSizeLabel.SetText(_item.UsesLeft + "/" + usableData.MaxUses);
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

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_item == null || _item.IsEmpty()) return;
            
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                HeroManager.Instance.SelectedHero.Inventory.UnequipAccessory(_index);
                Clear();
                StockpileManager.Instance.SyncStockpile();
                HeroManager.Instance.SelectAndSyncSelectedHero();
                
                onSyncSelectedHero.Invoke(true);
            }
        }
        
        public void OnDrag(PointerEventData eventData)
        {
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (_item == null || _item.IsEmpty()) return;
            
            DragCursor.Instance.BeginDrag(eventData, this);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (DragCursor.Instance.IsDragging == true)
            {
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (DragCursor.Instance.IsDragging == true)
            {
                if (DragCursor.Instance.DragItem.ItemDefinition.Category != ItemCategory.Accessories) return;
                
                Hero hero = HeroManager.Instance.SelectedHero;
                
                if (_item != null && _item.IsEmpty() == false)
                {
                    SwapItem(hero);
                }
                else
                {
                    SetItem(hero);
                }
                
                DragCursor.Instance.EndDrag(eventData);
                
                //hero.ActionController.SetupActions();
                HeroManager.Instance.SelectAndSyncSelectedHero();
            }
        }

        private void SetItem(Hero hero)
        {
            hero.Inventory.EquipAccessory(DragCursor.Instance.DragItem, _index);
            SetItem(DragCursor.Instance.DragItem);
            
            if (DragCursor.Instance.StartDragWidget.GetType() == typeof(StockpileWidget))
            {
                StockpileManager.Instance.ClearItem(DragCursor.Instance.StartDragWidget.Index);
            }
            
            DragCursor.Instance.StartDragWidget.Clear();
        }

        private void SwapItem(Hero hero)
        {
            Item tempItem = new Item(_item);
            hero.Inventory.EquipAccessory(DragCursor.Instance.DragItem, _index);
            SetItem(DragCursor.Instance.DragItem);
            
            if (DragCursor.Instance.StartDragWidget.GetType() == typeof(StockpileWidget))
            {
                StockpileManager.Instance.ClearItem(DragCursor.Instance.StartDragWidget.Index);
            }
            
            DragCursor.Instance.StartDragWidget.SetItem(tempItem);
        }
    }
}
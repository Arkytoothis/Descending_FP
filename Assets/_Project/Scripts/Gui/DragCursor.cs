using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Equipment;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Descending.Gui
{
    public class DragCursor : MonoBehaviour
    {
        public static DragCursor Instance { get; private set; }
        
        [SerializeField] private Image _iconImage = null;

        private Item _dragItem = null;
        private DragableItemWidget _startDragWidget = null;
        private bool _isDragging = false;
    
        public bool IsDragging => _isDragging;
        public Item DragItem => _dragItem;
        public DragableItemWidget StartDragWidget => _startDragWidget;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("Multiple Drag Cursors " + transform + " - " + Instance);
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
        }


        private void Update()
        {
            if (_isDragging == true)
            {
                _iconImage.rectTransform.position = Input.mousePosition;
            }
            
            if (Input.GetMouseButtonUp(0))
            {
                if (_isDragging == true)
                {
                    Clear();
                }
            }
        }

        private void Clear()
        {
            _iconImage.sprite = Database.instance.BlankSprite;
            _startDragWidget = null;
            _dragItem = null;
        }

        public void BeginDrag(PointerEventData eventData, DragableItemWidget startWidget)
        {
            _isDragging = true;
            _startDragWidget = startWidget;
            _dragItem = eventData.pointerDrag.GetComponent<DragableItemWidget>().Item;
            _iconImage.sprite = _dragItem.ItemDefinition.Icon;
            
        }

        public void EndDrag(PointerEventData eventData)
        {
            _isDragging = false;
            Clear();
        }
    }
}
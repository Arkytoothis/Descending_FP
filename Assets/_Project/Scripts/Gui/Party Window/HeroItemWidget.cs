using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Equipment;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Descending.Gui
{
    public class HeroItemWidget : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image _iconImage = null;
        [SerializeField] private TMP_Text _stackSizeLabel = null;

        //[SerializeField] private ItemEvent onDisplayItemTooltip = null;
        
        private Item _item = null;
        
        public void SetItem(Item item)
        {
            _item = item;

            if (_item != null)
            {
                _iconImage.sprite = item.Icon;
                _stackSizeLabel.SetText("1");
            }
            else
            {
                Clear();
            }
        }

        private void Clear()
        {
            _iconImage.sprite = Database.instance.BlankSprite;
            _stackSizeLabel.SetText("");
        }


        public void OnPointerEnter(PointerEventData eventData)
        {
            //onDisplayItemTooltip.Invoke(_item);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            //onDisplayItemTooltip.Invoke(null);
        }
    }
}
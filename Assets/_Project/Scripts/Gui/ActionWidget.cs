using System.Collections;
using System.Collections.Generic;
using Descending.Abilities;
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
    public class ActionWidget : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image _icon = null;
        [SerializeField] private TMP_Text _hotKeyLabel = null;
        [SerializeField] private TMP_Text _usesLabel = null;

        [SerializeField] private AbilityEvent onTargetAbility = null;
        [SerializeField] private ItemEvent onTargetItem = null;
        [SerializeField] private AbilityEvent onDisplayAbilityTooltip = null;
        [SerializeField] private ItemEvent onDisplayItemTooltip = null;
        
        private int _index = -1;
        private Ability _ability = null;
        private Item _item = null;
        
        public void Setup(int index, string hotKey)
        {
            _index = index;
            _hotKeyLabel.SetText(hotKey);
            _usesLabel.SetText("");
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
            SetUsesLabel();
            _ability = null;
        }
        
        public void Clear()
        {
            _index = -1;
            _icon.sprite = Database.instance.BlankSprite;
            _usesLabel.SetText("");
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_ability != null)
            {
                onTargetAbility.Invoke(_ability);
            }
            else if (_item != null)
            {
                UsableData usableData = _item.GetUsableData();

                if (usableData == null || usableData.TargetType != TargetTypes.Self)
                {
                    onTargetItem.Invoke(_item);
                }
                else
                {
                    _item.Use(HeroManager.Instance.SelectedHero, new List<Unit> { HeroManager.Instance.SelectedHero });
                }
                
                SetUsesLabel();
            }
        }

        private void SetUsesLabel()
        {
            if (_item.MaxUses > 0)
            {
                _usesLabel.SetText(_item.UsesLeft.ToString());
            }
            else
            {
                _usesLabel.SetText("");
            }
            
            CheckIfUsed();
        }

        private void CheckIfUsed()
        {
            if (_item.UsesLeft <= 0)
            {
                Clear();
                HeroManager.Instance.SelectedHero.Inventory.ClearAccessory(_item.AccessorySlot);
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_ability != null)
            {
                onDisplayAbilityTooltip.Invoke(_ability);
            }
            else if (_item != null)
            {
                onDisplayItemTooltip.Invoke(_item);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            onDisplayAbilityTooltip.Invoke(null);
        }
    }
}

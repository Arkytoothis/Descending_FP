using System.Collections;
using System.Collections.Generic;
using Descending.Abilities;
using Descending.Core;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Descending.Gui
{
    public class AbilityWidget : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image _iconImage = null;
        [SerializeField] private TMP_Text _stackSizeLabel = null;

        [SerializeField] private AbilityEvent onDisplayAbilityTooltip = null;
        
        private Ability _ability = null;
        
        public void SetAbility(Ability ability)
        {
            _ability = ability;

            if (_ability != null)
            {
                _iconImage.sprite = _ability.Definition.Icon;
                _stackSizeLabel.SetText("");
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
            onDisplayAbilityTooltip.Invoke(_ability);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            onDisplayAbilityTooltip.Invoke(null);
        }
    }
}
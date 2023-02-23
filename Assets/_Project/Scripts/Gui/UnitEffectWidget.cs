using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Descending.Gui
{
    public class UnitEffectWidget : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image _iconImage = null;
        [SerializeField] private TMP_Text _durationLabel = null;

        //[SerializeField] private TooltipTextEvent onDisplayTooltipText = null;

        private UnitEffect _unitEffect = null;
        
        public void Setup(UnitEffect unitEffect)
        {
            _unitEffect = unitEffect;
            _iconImage.sprite = unitEffect.Icon;
            _durationLabel.SetText(unitEffect.Duration.ToString());
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            string heading = _unitEffect.GetTooltipHeading();
            string text = _unitEffect.GetTooltipText();
            //onDisplayTooltipText.Invoke(new TooltipText(heading, text));
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            //onDisplayTooltipText.Invoke(null);
        }
    }
}
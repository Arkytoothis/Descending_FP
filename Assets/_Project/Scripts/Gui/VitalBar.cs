using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Descending.Gui
{
    public class VitalBar : MonoBehaviour
    {
        [SerializeField] private TMP_Text _valueLabel = null;
        [SerializeField] private Image _foregroundImage = null;

        public void UpdateData(int current, int maximum)
        {
            float fillAmount = (float)current / maximum;
            _valueLabel.SetText(current + " / " + maximum);
            _foregroundImage.fillAmount = fillAmount;
        }

        public void Clear()
        {
            _valueLabel.SetText("0");
            _foregroundImage.fillAmount = 0;
        }
    }
}

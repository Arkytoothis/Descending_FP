using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Attribute = Descending.Attributes.Attribute;

namespace Descending.Gui
{
    public class VitalWidget : MonoBehaviour
    {
        [SerializeField] private TMP_Text _currentLabel = null;
        [SerializeField] private TMP_Text _maximumLabel = null;
        [SerializeField] private TMP_Text _modifierLabel = null;

        public void SetAttribute(Attribute attribute)
        {
            _currentLabel.SetText(attribute.TotalCurrent().ToString());
            _maximumLabel.SetText(attribute.TotalMaximum().ToString());

            if (attribute.Modifier < 0)
            {
                _modifierLabel.SetText(attribute.Modifier.ToString());
                _modifierLabel.color = Color.red;
                _currentLabel.color = Color.red;
                _maximumLabel.color = Color.red;
            }
            else if (attribute.Modifier > 0)
            {
                _modifierLabel.SetText("+" + attribute.Modifier);
                _modifierLabel.color = Color.green;
                _currentLabel.color = Color.green;
                _maximumLabel.color = Color.green;
            }
            else
            {
                _modifierLabel.SetText("");
                _modifierLabel.color = Color.white;
                _currentLabel.color = Color.white;
                _maximumLabel.color = Color.white;
            }
        }
    }
}
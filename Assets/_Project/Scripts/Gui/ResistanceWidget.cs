using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Attribute = Descending.Attributes.Attribute;

namespace Descending.Gui
{
    public class ResistanceWidget : MonoBehaviour
    {
        [SerializeField] private TMP_Text _currentLabel = null;
        [SerializeField] private TMP_Text _maximumLabel = null;

        public void SetResistance(int current, int maximum)
        {
            _currentLabel.SetText(current + "%");
            _maximumLabel.SetText(maximum + "%");
        }
    }
}
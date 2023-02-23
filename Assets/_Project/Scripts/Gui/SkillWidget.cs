using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Attribute = Descending.Attributes.Attribute;

namespace Descending.Gui
{
    public class SkillWidget : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textLabel = null;
        [SerializeField] private TMP_Text _currentLabel = null;
        [SerializeField] private TMP_Text _maximumLabel = null;

        public void SetSkill(string text, int current, int maximum)
        {
            _textLabel.SetText(text);
            _currentLabel.SetText(current.ToString());
            _maximumLabel.SetText(maximum.ToString());
        }
    }
}
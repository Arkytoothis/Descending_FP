using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Attribute = Descending.Attributes.Attribute;

namespace Descending.Gui
{
    public class StatisticWidget : MonoBehaviour
    {
        [SerializeField] private TMP_Text _valueLabel = null;
        [SerializeField] private TMP_Text _modifierLabel = null;

        public void SetAttribute(Attribute attribute)
        {
            if (attribute.Current != attribute.Maximum)
            {
                _valueLabel.SetText(attribute.TotalCurrent() + "/" + attribute.TotalMaximum());
            }
            else
            {
                _valueLabel.SetText(attribute.TotalCurrent().ToString());
            }

            if (attribute.Modifier < 0)
            {
                _modifierLabel.SetText(attribute.Modifier.ToString());
                _modifierLabel.color = Color.red;
                _valueLabel.color = Color.red;
            }
            else if (attribute.Modifier > 0)
            {
                _modifierLabel.SetText("+" + attribute.Modifier);
                _modifierLabel.color = Color.green;
                _valueLabel.color = Color.green;
            }
            else
            {
                _modifierLabel.SetText("");
                _modifierLabel.color = Color.white;
                _valueLabel.color = Color.white;
            }
        }
        
        public void SetAttributePercent(Attribute attribute)
        {
            if (attribute.Current != attribute.Maximum)
            {
                _valueLabel.SetText(attribute.TotalCurrent() + "%/" + attribute.TotalMaximum() + "%");
            }
            else
            {
                _valueLabel.SetText(attribute.TotalCurrent() + "%");
            }
            
            if (attribute.Modifier < 0)
            {
                _modifierLabel.SetText(attribute.Modifier.ToString());
                _modifierLabel.color = Color.red;
                _valueLabel.color = Color.red;
            }
            else if (attribute.Modifier > 0)
            {
                _modifierLabel.SetText("+" + attribute.Modifier);
                _modifierLabel.color = Color.green;
                _valueLabel.color = Color.green;
            }
            else
            {
                _modifierLabel.SetText("");
                _modifierLabel.color = Color.white;
                _valueLabel.color = Color.white;
            }
        }
        
        public void SetAttributeModifier(Attribute attribute)
        {
            if (attribute.Current != attribute.Maximum)
            {
                if (attribute.TotalCurrent() >= 0)
                {
                    _valueLabel.SetText("+" + attribute.TotalCurrent() + "/" + "+" + attribute.TotalMaximum());
                }
                else
                {
                    _valueLabel.SetText(attribute.TotalCurrent() + "/" + attribute.TotalMaximum());
                }
            }
            else
            {
                if (attribute.TotalCurrent() >= 0)
                {
                    _valueLabel.SetText("+" + attribute.TotalCurrent());
                }
                else
                {
                    _valueLabel.SetText(attribute.TotalCurrent().ToString());
                }
            }

            if (attribute.Modifier < 0)
            {
                _modifierLabel.SetText(attribute.Modifier.ToString());
                _modifierLabel.color = Color.red;
                _valueLabel.color = Color.red;
            }
            else if (attribute.Modifier > 0)
            {
                _modifierLabel.SetText("+" + attribute.Modifier);
                _modifierLabel.color = Color.green;
                _valueLabel.color = Color.green;
            }
            else
            {
                _modifierLabel.SetText("");
                _modifierLabel.color = Color.white;
                _valueLabel.color = Color.white;
            }
        }
    }
}
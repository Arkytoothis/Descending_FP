using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Units;
using UnityEngine;

namespace Descending.Gui
{
    public class HeroListPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _heroWidgetPrefab = null;
        [SerializeField] private Transform _heroWidgetsParent = null;

        private PartyWindow _partyWindow = null;
        private List<HeroListWidget> _heroWidgets = null;

        private void Awake()
        {
            _heroWidgets = new List<HeroListWidget>();
        }

        public void Setup(PartyWindow partyWindow)
        {
            _partyWindow = partyWindow;
            _heroWidgetsParent.ClearTransform();
            _heroWidgets.Clear();
            
            for (int i = 0; i < HeroManager.Instance.Heroes.Count; i++)
            {
                GameObject clone = Instantiate(_heroWidgetPrefab, _heroWidgetsParent);
                HeroListWidget widget = clone.GetComponent<HeroListWidget>();
                widget.Setup(_partyWindow, HeroManager.Instance.Heroes[i]);
                
                _heroWidgets.Add(widget);
            }
        }
    }
}
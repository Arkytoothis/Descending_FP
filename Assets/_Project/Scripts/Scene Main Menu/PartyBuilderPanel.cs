using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Gui;
using Descending.Units;
using UnityEngine;

namespace Descending.Scene_MainMenu
{
    public class PartyBuilderPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _heroWidgetPrefab = null;
        [SerializeField] private Transform _heroWidgetsParent = null;
        [SerializeField] private List<StartingHeroWidget> _heroWidgets = null;
        
        private GuiManager_MainMenu _guiManager = null;
        private PartyBuilder _partyBuilder = null;
        
        public void Setup(GuiManager_MainMenu guiManager, PartyBuilder partyBuilder)
        {
            _guiManager = guiManager;
            _partyBuilder = partyBuilder;
            _heroWidgets = new List<StartingHeroWidget>();
        }

        public void Menu_ButtonClick()
        {
            _guiManager.SetMenuMode();
        }

        public void GenerateParty_ButtonClick()
        {
            _partyBuilder.BuildParty();
            LoadHeroes();
        }

        public void LoadHeroes()
        {
            _heroWidgetsParent.ClearTransform();
            _heroWidgets.Clear();
            
            foreach (Hero hero in _partyBuilder.Heroes)
            {
                GameObject clone = Instantiate(_heroWidgetPrefab, _heroWidgetsParent);
                StartingHeroWidget widget = clone.GetComponent<StartingHeroWidget>();
                widget.DisplayHero(hero);
                _heroWidgets.Add(widget);
            }
        }
    }
}
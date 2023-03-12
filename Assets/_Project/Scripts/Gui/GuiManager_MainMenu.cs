using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Scene_MainMenu;
using Descending.Units;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Descending.Gui
{
    public class GuiManager_MainMenu : MonoBehaviour
    {
        [SerializeField] private Transform _guiParent = null;
        [SerializeField] private GameObject _menuPanelPrefab = null;
        [SerializeField] private GameObject _partyBuilderPanelPrefab = null;
        [SerializeField] private GameObject _tooltipPrefab = null;

        private MainMenuManager _mainMenuManager = null;
        private PartyBuilder _partyBuilder = null;
        private Tooltip _tooltip = null;
        private MainMenuPanel _mainMenuPanel = null;
        private PartyBuilderPanel _partyBuilderPanel = null;
        
        public void Setup(MainMenuManager manager, PartyBuilder partyBuilder)
        {
            _mainMenuManager = manager;
            _partyBuilder = partyBuilder;
            
            SetupMenuPanel();
            SetupPartyBuilderPanel();
            SetupTooltip();
            SetMenuMode();
        }

        private void SetupTooltip()
        {
            GameObject clone = Instantiate(_tooltipPrefab, _guiParent);
            _tooltip = clone.GetComponent<Tooltip>();
            _tooltip.Setup();
        }

        private void SetupMenuPanel()
        {
            GameObject clone = Instantiate(_menuPanelPrefab, _guiParent);
            _mainMenuPanel = clone.GetComponent<MainMenuPanel>();
            _mainMenuPanel.Setup(this);
        }

        private void SetupPartyBuilderPanel()
        {
            GameObject clone = Instantiate(_partyBuilderPanelPrefab, _guiParent);
            _partyBuilderPanel = clone.GetComponent<PartyBuilderPanel>();
            _partyBuilderPanel.Setup(this, _partyBuilder);
        }

        

        public void SetMenuMode()
        {
            _mainMenuPanel.gameObject.SetActive(true);
            _partyBuilderPanel.gameObject.SetActive(false);
            _mainMenuManager.OpenMainMenu();
        }

        public void SetPartyBuilderMode()
        {
            _mainMenuPanel.gameObject.SetActive(false);
            _partyBuilderPanel.gameObject.SetActive(true);
            _mainMenuManager.OpenPartyBuilder();
        }

        public void DisplayHeroes()
        {
            _partyBuilderPanel.LoadHeroes();
        }
    }
}

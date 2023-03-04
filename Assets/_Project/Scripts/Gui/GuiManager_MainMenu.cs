using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Scene_MainMenu;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Descending.Gui
{
    public class GuiManager_MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _tooltipPrefab = null;

        private MainMenuManager _mainMenuManager = null;
        private Tooltip _tooltip = null;
        
        public void Setup(MainMenuManager manager)
        {
            _mainMenuManager = manager;
            SetupTooltip();
        }

        private void SetupTooltip()
        {
            GameObject clone = Instantiate(_tooltipPrefab, transform);
            _tooltip = clone.GetComponent<Tooltip>();
            _tooltip.Setup();
        }

        public void NewGame_ButtonClick()
        {
            SceneManager.LoadScene((int)GameScenes.Overworld);
        }

        public void Exit_ButtonClick()
        {
            Utilities.Exit();
        }
    }
}

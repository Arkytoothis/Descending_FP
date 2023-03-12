using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Gui;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Descending.Scene_MainMenu
{
    public class MainMenuPanel : MonoBehaviour
    {
        private GuiManager_MainMenu _guiManager = null;
        
        public void Setup(GuiManager_MainMenu guiManager)
        {
            _guiManager = guiManager;
        }
        
        public void ContinueGame_ButtonClick()
        {
            SceneManager.LoadScene((int)GameScenes.Overworld);
        }

        public void NewGame_ButtonClick()
        {
            _guiManager.SetPartyBuilderMode();
        }

        public void Exit_ButtonClick()
        {
            Utilities.Exit();
        }
    }
}
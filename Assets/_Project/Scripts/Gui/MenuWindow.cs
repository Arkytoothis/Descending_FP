using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Descending.Gui
{
    public class MenuWindow : GameWindow
    {
        public override void Setup(WindowManager manager)
        {
            _manager = manager;
            Close();
        }

        public override void Open()
        {
            gameObject.SetActive(true);
            _isOpen = true;
        }

        public override void Close()
        {
            gameObject.SetActive(false);
            _isOpen = false;
        }

        public void ResumeButton_OnClick()
        {
            Debug.Log("Resuming");
            _manager.CloseAll();
        }

        public void SaveButton_OnClick()
        {
            Debug.Log("Saving");
            _manager.CloseAll();
        }

        public void LoadButton_OnClick()
        {
            Debug.Log("Loading");
            _manager.CloseAll();
        }

        public void OptionsButton_OnClick()
        {
            Debug.Log("Options");
            _manager.CloseAll();
        }

        public void ExitToMenuButton_OnClick()
        {
            Debug.Log("Exiting To Menu");
            _manager.CloseAll();
            SceneManager.LoadScene((int)GameScenes.Main_Menu);
        }

        public void ExitButton_OnClick()
        {
            Debug.Log("Exiting");
            _manager.CloseAll();
            
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
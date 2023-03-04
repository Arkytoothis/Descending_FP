using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Gui;
using UnityEngine;

namespace Descending.Scene_MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private Database _database = null;
        [SerializeField] private GameObject _guiPrefab = null;
        [SerializeField] private Transform _guiParent = null;

        private GuiManager_MainMenu _guiManager;
        
        private void Awake()
        {
            _database.Setup();
        }

        private void Start()
        {
            SetupGui();
        }

        private void SetupGui()
        {
            GameObject clone = Instantiate(_guiPrefab, _guiParent);
            _guiManager = clone.GetComponent<GuiManager_MainMenu>();
            _guiManager.Setup(this);
        }
    }
}

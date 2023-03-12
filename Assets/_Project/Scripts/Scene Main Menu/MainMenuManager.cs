using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Descending.Core;
using Descending.Equipment;
using Descending.Gui;
using UnityEngine;

namespace Descending.Scene_MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private Database _database = null;
        [SerializeField] private GameObject _guiPrefab = null;
        [SerializeField] private Transform _guiParent = null;
        [SerializeField] private PartyBuilder _partyBuilder = null;
        
        [SerializeField] private CinemachineVirtualCamera _menuCamera = null;
        [SerializeField] private CinemachineVirtualCamera _partyBuilderCamera = null;

        private GuiManager_MainMenu _guiManager;

        private void Awake()
        {
            _database.Setup();
            ItemGenerator.Setup();
        }

        private void Start()
        {
            SetupGui();
            _partyBuilder.Setup();
            _guiManager.DisplayHeroes();
            OpenMainMenu();
        }

        private void SetupGui()
        {
            GameObject clone = Instantiate(_guiPrefab, _guiParent);
            _guiManager = clone.GetComponent<GuiManager_MainMenu>();
            _guiManager.Setup(this, _partyBuilder);
        }

        public void OpenMainMenu()
        {
            _menuCamera.enabled = true;
            _partyBuilderCamera.enabled = false;
        }

        public void OpenPartyBuilder()
        {
            _menuCamera.enabled = false;
            _partyBuilderCamera.enabled = true;
        }
    }
}

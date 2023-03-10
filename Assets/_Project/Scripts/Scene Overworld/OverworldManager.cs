using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Encounters;
using Descending.Equipment;
using Descending.Gui;
using Descending.Player;
using Descending.Treasure;
using Descending.Units;
using UnityEngine;

namespace Descending.Scene_Overworld
{
    public class OverworldManager : MonoBehaviour
    {
        [SerializeField] private bool _loadState = true;
        [SerializeField] private Database _database = null;
        //[SerializeField] private MapMagicObject _mapMagicObject = null;
        //[SerializeField] private FeatureManager _featureManager = null;
        [SerializeField] private PlayerManager _playerManager = null;
        [SerializeField] private HeroManager _heroManager = null;
        [SerializeField] private ResourcesManager _resourcesManager = null;
        [SerializeField] private StockpileManager _stockpileManager = null;
        [SerializeField] private EncounterManager _encounterManager = null;
        [SerializeField] private TreasureManager _treasureManager = null;
        [SerializeField] private GameTickManager _gameTickManager = null;
        
        [SerializeField] private PortraitRoom _portraitRoom = null;
        [SerializeField] private GameObject _guiPrefab = null;
        [SerializeField] private Transform _guiParent = null;

        private GuiManager_Overworld _guiManager = null;
        
        private void Awake()
        {
            _database.Setup();    
            ItemGenerator.Setup();
        }

        private void Start()
        {
            SetupGui();
            
            if (_loadState)
            {
                Load();
            }
            else
            {
                Setup();
            }
        }

        private void SetupGui()
        {
            GameObject clone = Instantiate(_guiPrefab, _guiParent);
            _guiManager = clone.GetComponent<GuiManager_Overworld>();
            _guiManager.Setup();
        }
        
        private void Setup()
        {
            _playerManager.Setup(GameScenes.Overworld);
            _heroManager.Setup();
            _portraitRoom.Setup(_heroManager.Heroes);
            _heroManager.SyncHeroes();
            
            _resourcesManager.Setup();
            _stockpileManager.Setup();
            _encounterManager.Setup();
            _treasureManager.Setup();
            
            HeroManager.Instance.SelectDefaultHero();
            
            _gameTickManager.Setup();
        }

        private void Load()
        {
            _playerManager.Setup(GameScenes.Overworld);
            _heroManager.LoadState();
            _portraitRoom.Setup(_heroManager.Heroes);
            _heroManager.SyncHeroes();
            
            _resourcesManager.LoadState();
            _stockpileManager.LoadState();
            _encounterManager.LoadState(Database.instance.OverworldEncounterDataFilePath);
            _treasureManager.Setup();
            
            HeroManager.Instance.SelectDefaultHero();
            
            _gameTickManager.Setup();
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Encounters;
using Descending.Equipment;
using Descending.Gui;
using Descending.Units;
using UnityEngine;

namespace Descending.Scene_Overworld
{
    public class OverworldManager : MonoBehaviour
    {
        [SerializeField] private Database _database = null;
        //[SerializeField] private MapMagicObject _mapMagicObject = null;
        //[SerializeField] private FeatureManager _featureManager = null;
        [SerializeField] private HeroManager _heroManager = null;
        [SerializeField] private ResourcesManager _resourcesManager = null;
        [SerializeField] private StockpileManager _stockpileManager = null;
        [SerializeField] private EncounterManager _encounterManager = null;
        
        [SerializeField] private PortraitRoom _portraitRoom = null;
        //[SerializeField] private GameObject _playerObject = null;
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
            
            _heroManager.Setup();
            _portraitRoom.Setup(_heroManager.Heroes);
            _heroManager.SyncHeroes();
            _resourcesManager.Setup();
            _stockpileManager.Setup();
            _encounterManager.Setup();
            
            HeroManager.Instance.SelectDefaultHero();
        }

        private void SetupGui()
        {
            GameObject clone = Instantiate(_guiPrefab, _guiParent);
            _guiManager = clone.GetComponent<GuiManager_Overworld>();
            _guiManager.Setup();
        }
        
        // private void BuildWorld()
        // {
        //     int seed = Random.Range(1, 999999);
        //     _mapMagicObject.graph.random = new Noise(seed, permutationCount: 32768);
        // }
        //
        // public void OnEnable ()
        // {
        //     TerrainTile.OnTileApplied -= DoSomething;
        //     TerrainTile.OnTileApplied += DoSomething;
        // }
        //
        // public void OnDisable ()
        // {
        //     TerrainTile.OnTileApplied -= DoSomething;
        // }
        //
        // private void DoSomething  (TerrainTile tile, TileData data, StopToken stop)
        // {
        //     if (data.isDraft)
        //     {
        //         Debug.Log("Just applied draft tile");
        //     }
        //     else
        //     {
        //         Debug.Log($"Applied main tile at {tile.coord.x}, {tile.coord.z}");
        //         _featureManager.ProcessFeatureSpawners(_playerObject);
        //     }
        // }

    }
}
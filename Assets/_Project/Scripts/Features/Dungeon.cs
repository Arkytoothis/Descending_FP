using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Units;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Features
{
    public class Dungeon : WorldFeature
    {
        [SerializeField] private DungeonData _dungeonData = null;
        [SerializeField] private GameScenes _sceneToLoad = GameScenes.None;
        //[SerializeField] private DungeonPanel _dungeonPanel = null;
        
        //[SerializeField] private DungeonEvent onOpenDungeonWindow = null;

        public DungeonData DungeonData => _dungeonData;
        public GameScenes SceneToLoad => _sceneToLoad;

        private void Start()
        {
            //FeatureManager.Instance.RegisterFeature(this);
        }

        public override void Approach()
        {
            //Debug.Log("Approaching Dungeon");
            //HeroManager_Overworld.Instance.SavePartyPosition();
            //_dungeonPanel.ShowInteractButton();
        }

        public override void Leave()
        {
            //Debug.Log("Leaving Dungeon");
            //_dungeonPanel.HideInteractButton();
        }

        public override void Setup()
        {
            _dungeonData.GenerateData(0);
        }

        public override void Interact()
        {
            //Debug.Log("Interacting with Village");
            //onOpenDungeonWindow.Invoke(this);
        }
    }
}
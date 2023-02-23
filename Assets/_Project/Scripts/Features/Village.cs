using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.Serialization;

namespace Descending.Features
{
    public class Village : WorldFeature
    {
        [SerializeField] private MarketData _marketData = null;
        //[SerializeField] private VillagePanel _villagePanel = null;
        
        //[SerializeField] private VillageEvent onOpenVillageWindow = null;

        public MarketData MarketData => _marketData;

        private void Start()
        {
            //FeatureManager.Instance.RegisterFeature(this);
        }

        public override void Setup()
        {
            _marketData.GenerateShopItems();
        }

        public override void Approach()
        {
            //Debug.Log("Approaching Village");
            //HeroManager_Overworld.Instance.SavePartyPosition();
           // _villagePanel.ShowInteractButton();
        }

        public override void Leave()
        {
            //Debug.Log("Leaving Village");
            //_villagePanel.HideInteractButton();
        }

        public override void Interact()
        {
            //Debug.Log("Interacting with Village");
            //onOpenVillageWindow.Invoke(this);
        }
    }
}
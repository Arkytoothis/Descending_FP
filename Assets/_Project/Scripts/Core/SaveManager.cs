using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using UnityEngine;

namespace Descending.Core
{
    public class SaveManager : MonoBehaviour
    {
        public static SaveManager Instance { get; private set; }
        
        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("Multiple UnitManagers " + transform + " - " + Instance);
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
        }

        public void SaveState()
        {
            HeroManager.Instance.SaveState();
            ResourcesManager.Instance.SaveState();
            StockpileManager.Instance.SaveState();
        }

        public void LoadState()
        {
            HeroManager.Instance.LoadState();
            ResourcesManager.Instance.LoadState();
            StockpileManager.Instance.LoadState();
        }
    }
}

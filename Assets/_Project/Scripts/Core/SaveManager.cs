using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Descending.Core;
using Descending.Units;
using Sirenix.Serialization;
using UnityEngine;

namespace Descending.Core
{
    public abstract class SaveManager : MonoBehaviour
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

        public abstract void SaveState();
        public abstract void LoadState();
    }
}

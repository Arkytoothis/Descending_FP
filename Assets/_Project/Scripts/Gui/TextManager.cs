using System;
using System.Collections;
using System.Collections.Generic;
using Guirao.UltimateTextDamage;
using UnityEngine;

namespace Descending.Gui
{
    public class TextManager : MonoBehaviour
    {
        public static TextManager Instance { get; private set; }
        
        [SerializeField] private UltimateTextDamageManager _worldTextManager = null;
        
        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("Multiple TextManagers " + transform + " - " + Instance);
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
        }

        public void SpawnWorldText(Transform target, string text, string key)
        {
            _worldTextManager.Add(text, target, key);
        }
    }
}
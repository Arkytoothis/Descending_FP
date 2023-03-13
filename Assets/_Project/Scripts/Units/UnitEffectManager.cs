using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Units
{
    public class UnitEffectManager : MonoBehaviour
    {
        public static UnitEffectManager Instance { get; private set; }

        //[SerializeField] private List<Unit> _registeredUnits = null;
        
        //[SerializeField] private BoolEvent onSyncUnitEffectsGui = null;
        
        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("Multiple UnitEffectManagers " + transform + " - " + Instance);
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
            //_registeredUnits = new List<Unit>();
        }

        public void Setup()
        {
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace Descending.Core
{
    public class ScreenShake : MonoBehaviour
    {
        public static ScreenShake Instance { get; private set; }
        
        private CinemachineImpulseSource _impulseSource = null;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("Multiple UnitActionSystems " + transform + " - " + Instance);
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
            _impulseSource = GetComponent<CinemachineImpulseSource>();
        }

        private void Update()
        {
        }

        public void Shake(float intensity = 1f)
        {
            _impulseSource.GenerateImpulse(intensity);
        }
    }
}
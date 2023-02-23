using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Features
{
    public class FeatureSpawner : MonoBehaviour
    {
        [SerializeField] private GameObjectEvent onRegisterSpawner = null;
        
        private void Awake()
        {
            // if (transform.position.y < 1f)//36.64f)
            // {
            //     Destroy(gameObject);
            // }
            // else
            // {
            //     onRegisterSpawner.Invoke(gameObject);
            // }
            onRegisterSpawner.Invoke(gameObject);
        }

        public void Setup()
        {
        }
    }
}

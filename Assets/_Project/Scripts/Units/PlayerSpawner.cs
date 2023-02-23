using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Units
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private GameObjectEvent onRegisterSpawner = null;

        private void Awake()
        {
            onRegisterSpawner.Invoke(gameObject);
        }
    }
}
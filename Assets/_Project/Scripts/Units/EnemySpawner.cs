using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Units
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyDefinition _definition = null;
        
        private void Start()
        {
            EnemyManager.Instance.RegisterEnemySpawner(gameObject);
        }

        public void Spawn(Transform parent)
        {
            //Debug.Log("Spawning " + _definition.Name);
            GameObject clone = Instantiate(_definition.Prefab, parent);
            clone.name = _definition.Name;
            clone.transform.position = transform.position;
            clone.transform.rotation = transform.rotation;

            Enemy unit = clone.GetComponent<Enemy>();
            unit.SetupEnemy(_definition);
        }
    }
}
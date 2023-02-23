using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Units
{
    public class EnemyManager : MonoBehaviour
    {
        public static EnemyManager Instance { get; private set; }
        
        [SerializeField] private List<EnemyUnit> _enemyUnits = null;
        [SerializeField] private Transform _enemiesParent = null;
        [SerializeField] private List<EnemySpawner> _enemySpawners = null;
        
        public List<EnemyUnit> EnemyUnits => _enemyUnits;
        
        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("Multiple EnemyManagers " + transform + " - " + Instance);
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
            _enemyUnits = new List<EnemyUnit>();
        }

        public void Setup()
        {
            
        }

        public void RegisterEnemySpawner(GameObject spawnerObject)
        {
            EnemySpawner spawner = spawnerObject.GetComponent<EnemySpawner>();
            _enemySpawners.Add(spawner);
            spawner.Spawn(_enemiesParent);
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Descending.Encounters
{
    public class EncounterSpawner : MonoBehaviour
    {
        [SerializeField] private List<EnemySpawnData> _minions = null;
        [SerializeField] private List<EnemySpawnData> _elites = null;
        [SerializeField] private List<EnemySpawnData> _leaders = null;
        [SerializeField] private List<EnemySpawnData> _bosses = null;
        [SerializeField] private Transform _minionsParent = null;
        [SerializeField] private Transform _elitesParent = null;
        [SerializeField] private Transform _leadersParent = null;
        [SerializeField] private Transform _bossesParent = null;

        private void Start()
        {
            EncounterManager.Instance.RegisterEncounterSpawner(this);
        }

        public void Setup()
        {
            SpawnEnemies();
        }
        
        public void SpawnEnemies()
        {
            foreach (EnemySpawnData minionData in _minions)
            {
                int numToSpawn = Random.Range(minionData.MinNumToSpawn, minionData.MaxNumToSpawn);
                
                for (int i = 0; i < numToSpawn; i++)
                {
                    GameObject clone = Instantiate(minionData.EnemyDefinition.Prefab, _minionsParent);
                    Enemy enemy = clone.GetComponent<Enemy>();
                    enemy.SetupEnemy(minionData.EnemyDefinition);
                }
            }
        }
    }
}

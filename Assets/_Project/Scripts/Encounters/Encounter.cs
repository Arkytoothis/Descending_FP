using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using ScriptableObjectArchitecture;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Descending.Encounters
{
    public class Encounter : MonoBehaviour
    {
        [SerializeField] private SpawnerEntry _minionsEntry = null;
        [SerializeField] private SpawnerEntry _elitesEntry = null;
        [SerializeField] private SpawnerEntry _leadersEntry = null;
        [SerializeField] private SpawnerEntry _bossesEntry = null;
        [SerializeField] private int _threatLevel = 0;

        [SerializeField] private List<Enemy> _enemies = null;
        
        [SerializeField] private EncounterEvent onEncounterTriggered = null;

        public List<Enemy> Enemies => _enemies;

        private void Start()
        {
            EncounterManager.Instance.RegisterEncounter(this);
        }

        public void Setup(Transform playerStart)
        {
            CalculateThreatLevel(playerStart);
            SpawnEnemies();
        }
        
        public void SpawnEnemies()
        {
            ProcessSpawnEntry(_minionsEntry);
            ProcessSpawnEntry(_elitesEntry);
            ProcessSpawnEntry(_leadersEntry);
            ProcessSpawnEntry(_bossesEntry);
            
            for (int i = 0; i < _minionsEntry.Enemies.Count; i++)
            {
                _enemies.Add(_minionsEntry.Enemies[i]);
            }
            
            for (int i = 0; i < _elitesEntry.Enemies.Count; i++)
            {
                _enemies.Add(_elitesEntry.Enemies[i]);
            }
            
            for (int i = 0; i < _leadersEntry.Enemies.Count; i++)
            {
                _enemies.Add(_leadersEntry.Enemies[i]);
            }
            
            for (int i = 0; i < _bossesEntry.Enemies.Count; i++)
            {
                _enemies.Add(_bossesEntry.Enemies[i]);
            }
        }

        public void CalculateThreatLevel(Transform playerStart)
        {
            _threatLevel = Mathf.FloorToInt(Vector3.Distance(transform.position, playerStart.position));
        }

        private void ProcessSpawnEntry(SpawnerEntry spawnerEntry)
        {
            foreach (EnemySpawnData spawnData in spawnerEntry.SpawnData)
            {
                int numToSpawn = Random.Range(spawnData.MinNumToSpawn, spawnData.MaxNumToSpawn + 1);

                for (int i = 0; i < numToSpawn; i++)
                {
                    GameObject clone = Instantiate(spawnData.EnemyDefinition.Prefab, spawnerEntry.Parent);
                    Enemy enemy = clone.GetComponent<Enemy>();
                    enemy.SetupEnemy(spawnData.EnemyDefinition);
                    spawnerEntry.Enemies.Add(enemy);
                }
            }

            for (int i = 0; i < spawnerEntry.Enemies.Count; i++)
            {
                spawnerEntry.Enemies[i].transform.position = spawnerEntry.SpawnPositions[i].position;
            }
        }

        public void Trigger()
        {
            Debug.Log("Encounter Triggered");
            onEncounterTriggered.Invoke(this);
        }
    }
}

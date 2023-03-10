using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Player;
using Descending.Units;
using DG.Tweening;
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
        [SerializeField] private List<Transform> _meleeSpawnPositions = null;
        [SerializeField] private List<Transform> _rangedSpawnPositions = null;
        [SerializeField] private List<Transform> _flankingSpawnPositions = null;
        [SerializeField] private List<Transform> _leaderSpawnPositions = null;
        [SerializeField] private List<Transform> _bossSpawnPositions = null;
        [SerializeField] private int _threatLevel = 0;
        [SerializeField] private bool _isActive = false;
        [SerializeField] private GameScenes _scene = GameScenes.None;
        
        private List<Enemy> _enemies = null;
        private List<InitiativeData> _initiativeDataList = null;
        
        public List<InitiativeData> InitiativeDataList => _initiativeDataList;
        public List<Enemy> Enemies => _enemies;
        public bool IsActive => _isActive;

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
            if (_isActive == false) return;
            
            _scene = PlayerManager.Instance.CurrentScene;
            _enemies = new List<Enemy>();
            
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
                if (spawnerEntry.Enemies[i].Definition.SpawnType == EnemySpawnTypes.Melee)
                {
                    if(_meleeSpawnPositions.Count > 0)
                    {
                        spawnerEntry.Enemies[i].transform.position = _meleeSpawnPositions[0].position;
                        _meleeSpawnPositions.RemoveAt(0);
                    }
                }
                else if (spawnerEntry.Enemies[i].Definition.SpawnType == EnemySpawnTypes.Ranged)
                {
                    if(_rangedSpawnPositions.Count > 0)
                    {
                        spawnerEntry.Enemies[i].transform.position = _rangedSpawnPositions[0].position;
                        _rangedSpawnPositions.RemoveAt(0);
                    }
                }
                else if (spawnerEntry.Enemies[i].Definition.SpawnType == EnemySpawnTypes.Flanking)
                {
                    if(_flankingSpawnPositions.Count > 0)
                    {
                        spawnerEntry.Enemies[i].transform.position = _flankingSpawnPositions[0].position;
                        _flankingSpawnPositions.RemoveAt(0);
                    }
                }
                else if (spawnerEntry.Enemies[i].Definition.SpawnType == EnemySpawnTypes.Leader)
                {
                    if(_leaderSpawnPositions.Count > 0)
                    {
                        spawnerEntry.Enemies[i].transform.position = _leaderSpawnPositions[0].position;
                        _leaderSpawnPositions.RemoveAt(0);
                    }
                }
                else if (spawnerEntry.Enemies[i].Definition.SpawnType == EnemySpawnTypes.Boss)
                {
                    if(_bossSpawnPositions.Count > 0)
                    {
                        spawnerEntry.Enemies[i].transform.position = _bossSpawnPositions[0].position;
                        _bossSpawnPositions.RemoveAt(0);
                    }
                }
            }
        }

        public void Trigger()
        {
        }

        public void End()
        {
            _isActive = false;
        }

        public void RollInitiative()
        {
            if (_initiativeDataList == null)
            {
                _initiativeDataList = new List<InitiativeData>();
            }
            else
            {
                _initiativeDataList.Clear();
            }

            for (int i = 0; i < _enemies.Count; i++)
            {
                int initiativeRoll = Random.Range(1, 101);
                _initiativeDataList.Add(new InitiativeData(initiativeRoll, _enemies[i]));
            }

            for (int i = 0; i < HeroManager.Instance.Heroes.Count; i++)
            {
                int initiativeRoll = Random.Range(1, 101);
                _initiativeDataList.Add(new InitiativeData(initiativeRoll, HeroManager.Instance.Heroes[i]));
            }

            _initiativeDataList.Sort((x, y) => x.InitiativeRoll.CompareTo(y.InitiativeRoll));
        }

        public void LookAtPlayer(Transform player)
        {
            foreach (Enemy enemy in _enemies)
            {
                enemy.transform.DOLookAt(player.position, 0.5f, AxisConstraint.Y);
            }
        }

        public void SelectEnemy(Enemy enemyToSelect)
        {
            foreach (Enemy enemy in _enemies)
            {
                if(enemy == null || enemy.gameObject == null) continue;
                
                if (enemy == enemyToSelect)
                    enemy.Select();
                else
                    enemy.Deselect();
            }
        }

        public void DeselectEnemies()
        {
            foreach (Enemy enemy in _enemies)
            {
                if(enemy == null || enemy.gameObject == null) continue;
                
                enemy.Deselect();
            }
        }

        public void RefreshEnemyActions()
        {
            foreach (Enemy enemy in _enemies)
            {
                enemy.Attributes.RefreshActions();
            }
        }

        public void Load(EncounterSaveData saveData)
        {
            _isActive = saveData.IsActive;
            transform.position = saveData.WorldPosition;
            _scene = PlayerManager.Instance.CurrentScene;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using UnityEngine;
using UnityEngine.Serialization;

namespace Descending.Encounters
{
    [System.Serializable]
    public class SpawnerEntry
    {
        [SerializeField] private List<EnemySpawnData> _spawnData = null;
        [SerializeField] private Transform _parent = null;
        [SerializeField] private List<Enemy> _enemies = null;

        public List<EnemySpawnData> SpawnData => _spawnData;
        public Transform Parent => _parent;
        public List<Enemy> Enemies => _enemies;

        public SpawnerEntry()
        {
        }
    }
}

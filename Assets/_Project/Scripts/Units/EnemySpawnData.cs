using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Units
{
    [System.Serializable]
    public class EnemySpawnData
    {
        [SerializeField] private EnemyDefinition _enemyDefinition = null;
        [SerializeField] private int _spawnChance = 100;
        [SerializeField] private int _minNumToSpawn = 0;
        [SerializeField] private int _maxNumToSpawn = 0;

        public EnemyDefinition EnemyDefinition => _enemyDefinition;
        public int SpawnChance => _spawnChance;
        public int MinNumToSpawn => _minNumToSpawn;
        public int MaxNumToSpawn => _maxNumToSpawn;
        
    }
}

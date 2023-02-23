using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Descending.Features
{
    [System.Serializable]
    public class DungeonData : MonoBehaviour
    {
        [SerializeField] private int _threatLevel = 0;
        [SerializeField] private int _levels = 0;
        [SerializeField] private EncounterDifficulties _difficulty = EncounterDifficulties.None;
        [SerializeField] private EnemyGroups _group = EnemyGroups.None;
        [SerializeField] private DungeonTypes _dungeonType = DungeonTypes.None;

        public int ThreatLevel => _threatLevel;
        public int Levels => _levels;
        public EncounterDifficulties Difficulty => _difficulty;
        public EnemyGroups Group => _group;
        public DungeonTypes DungeonType => _dungeonType;

        public void GenerateData(int threatLevel)
        {
            //Debug.Log("Generating Dungeon Data");
            _threatLevel = threatLevel;
            _levels = Random.Range(1, 4);
            _difficulty = EncounterDifficulties.Easy;
        }
    }
}
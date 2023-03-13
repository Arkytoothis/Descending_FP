using System.Collections;
using System.Collections.Generic;
using Descending.Attributes;
using Descending.Core;
using Descending.Equipment;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Descending.Units
{
    public enum EnemySpawnTypes { Melee, Ranged, Flanking, Leader, Boss, Number, None }
    
    [CreateAssetMenu(fileName = "Enemy Definition", menuName = "Descending/Definition/Enemy Definition")]
    public class EnemyDefinition : ScriptableObject
    {
        public string Name = "Unnamed Enemy";
        public string Key = "";
        public int ExpValue = 0;

        public GameObject Prefab = null;
        public Sprite Icon = null;
        public EnemyGroups Group = EnemyGroups.None;
        public ParticleSystem HitEffect = null;
        public EnemySpawnTypes SpawnType = EnemySpawnTypes.None;

        public StartingCharacteristicDictionary StartingCharacteristics = null;
        public StartingVitalDictionary StartingVitals = null;
        public StartingStatisticDictionary StartingStatistics = null;
        public StartingSkillDictionary StartingSkills = null;
        public List<Resistance> Resistances = null;

        public bool PrefersRanged = true;
        public ItemShort MeleeWeapon;
        public ItemShort RangedWeapon;

        [Button("Generate Characteristics")]
        private void GenerateCharacteristics()
        {
            foreach (var attributeKvp in Database.instance.Attributes.Attributes)
            {
                StartingCharacteristics.Add(attributeKvp.Key, new StartingCharacteristic(attributeKvp.Value, 10, 10));
            }
        }
    }
}
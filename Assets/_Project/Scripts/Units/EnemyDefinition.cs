using System.Collections;
using System.Collections.Generic;
using Descending.Attributes;
using Descending.Core;
using Descending.Equipment;
using Descending.Treasure;
using UnityEngine;

namespace Descending.Units
{
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

        public StartingVitalDictionary StartingVitals = null;
        public StartingStatisticDictionary StartingStatistic = null;
        public StartingSkillDictionary StartingSkills = null;
        public List<Resistance> Resistances = null;

        public ItemShort MeleeWeapon;
        public ItemShort RangedWeapon;
        
        public List<DropData> CoinData;
        public List<DropData> GemData;
        
        // [SoundGroup] public List<string> AttackSounds;
        // [SoundGroup] public List<string> HitSounds;
        // [SoundGroup] public List<string> WoundSounds;

        //public List<ItemShort> Equipment = null;

        // public string GetAttackSound()
        // {
        //     return AttackSounds[Random.Range(0, AttackSounds.Count)];
        // }
        //
        // public string GetHitSound()
        // {
        //     return HitSounds[Random.Range(0, HitSounds.Count)];
        // }
        //
        // public string GetWoundSound()
        // {
        //     return WoundSounds[Random.Range(0, WoundSounds.Count)];
        // }
    }
}
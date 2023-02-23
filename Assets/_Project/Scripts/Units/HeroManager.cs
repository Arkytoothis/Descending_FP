using System.Collections;
using System.Collections.Generic;
using Descending.Attributes;
using Descending.Core;
using UnityEngine;

namespace Descending.Units
{
    public class HeroManager : MonoBehaviour
    {
        public static HeroManager Instance { get; private set; }
        
        [SerializeField] private GameObject _heroPrefab = null;
        [SerializeField] private Transform _heroesParent = null;
        [SerializeField] private List<HeroUnit> _heroes = null;

        public List<HeroUnit> Heroes => _heroes;
        
        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("Multiple EnemyManagers " + transform + " - " + Instance);
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
            _heroes = new List<HeroUnit>();
        }
        
        public void Setup()
        {
            SpawnHero(Database.instance.Races.GetRandomRace(), Database.instance.Profession.GetProfession("Soldier"), Utilities.GetRandomGender(), _heroes.Count);
            SpawnHero(Database.instance.Races.GetRandomRace(), Database.instance.Profession.GetProfession("Scout"), Utilities.GetRandomGender(), _heroes.Count);
            SpawnHero(Database.instance.Races.GetRandomRace(), Database.instance.Profession.GetProfession("Acolyte"), Utilities.GetRandomGender(), _heroes.Count);
            SpawnHero(Database.instance.Races.GetRandomRace(), Database.instance.Profession.GetProfession("Apprentice"), Utilities.GetRandomGender(), _heroes.Count);
        }

        private void SpawnHero(RaceDefinition race, ProfessionDefinition profession, Genders gender, int listIndex)
        {
            //Debug.Log("Spawning Hero at " + mapPosition.ToString());
            GameObject clone = Instantiate(_heroPrefab, _heroesParent);
            HeroUnit heroUnit = clone.GetComponent<HeroUnit>();
            heroUnit.SetupHero(Genders.Male, race, profession, listIndex);
            clone.name = "Hero: " + heroUnit.GetFullName();
            _heroes.Add(heroUnit);
        }

        public void SyncHeroes()
        {
            foreach (var heroUnit in _heroes)
            {
                heroUnit.SyncData();
            }
        }
    }
}

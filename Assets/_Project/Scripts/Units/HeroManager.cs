using System.Collections;
using System.Collections.Generic;
using Descending.Attributes;
using Descending.Core;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Units
{
    public class HeroManager : MonoBehaviour
    {
        public static HeroManager Instance { get; private set; }
        
        [SerializeField] private GameObject _heroPrefab = null;
        [SerializeField] private Transform _heroesParent = null;
        [SerializeField] private List<Hero> _heroes = null;
        [SerializeField] private PortraitRoom _portraitRoom = null;
        [SerializeField] private Transform _projectileSpawn = null;
        
        [SerializeField] private HeroUnitEvent onSyncSelectedHeroActions = null;

        private Hero _selectedHero = null;
        
        public List<Hero> Heroes => _heroes;
        public Hero SelectedHero => _selectedHero;
        public Transform ProjectileSpawn => _projectileSpawn;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("Multiple EnemyManagers " + transform + " - " + Instance);
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
            _heroes = new List<Hero>();
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
            Hero hero = clone.GetComponent<Hero>();
            hero.SetupHero(Genders.Male, race, profession, listIndex);
            clone.name = "Hero: " + hero.GetFullName();
            _heroes.Add(hero);
        }

        public void SyncHero(int index)
        {
            _heroes[index].SyncData();
        }

        public void SyncHeroes()
        {
            foreach (var heroUnit in _heroes)
            {
                heroUnit.SyncData();
            }
        }

        public void SelectHero(Hero hero)
        {
            _selectedHero = hero;
            onSyncSelectedHeroActions.Invoke(_selectedHero);
        }

        public void SelectDefaultHero()
        {
            _selectedHero = _heroes[0];
            onSyncSelectedHeroActions.Invoke(_selectedHero);
        }
        
        public void SelectAndSyncSelectedHero()
        {
            SelectHero(_selectedHero);
            _selectedHero.SyncData();
            _portraitRoom.RefreshCameras();
            onSyncSelectedHeroActions.Invoke(_selectedHero);
        }

        public void AwardExperience(int amount)
        {
            foreach (Hero hero in _heroes)
            {
                hero.AddExperience(amount);
            }
        }
    }
}

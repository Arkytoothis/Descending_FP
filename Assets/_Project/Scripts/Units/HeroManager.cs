using System.Collections;
using System.Collections.Generic;
using System.IO;
using Descending.Attributes;
using Descending.Core;
using Descending.Party;
using Descending.Player;
using ScriptableObjectArchitecture;
using Sirenix.Serialization;
using UnityEngine;

namespace Descending.Units
{
    public class HeroManager : MonoBehaviour
    {
        public static HeroManager Instance { get; private set; }
        
        [SerializeField] private PlayerController _playerController = null;
        [SerializeField] private GameObject _heroPrefab = null;
        [SerializeField] private Transform _heroesParent = null;
        [SerializeField] private List<Hero> _heroes = null;
        [SerializeField] private PortraitRoom _portraitRoom = null;
        
        [SerializeField] private HeroUnitEvent onSyncSelectedHeroActions = null;

        private Hero _selectedHero = null;
        
        public List<Hero> Heroes => _heroes;
        public Hero SelectedHero => _selectedHero;

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
            SpawnHero(Database.instance.Races.GetRace("Half Orc"), Database.instance.Profession.GetProfession("Soldier"), Utilities.GetRandomGender(), _heroes.Count);
            SpawnHero(Database.instance.Races.GetRace("Mountain Dwarf"), Database.instance.Profession.GetProfession("Mercenary"), Utilities.GetRandomGender(), _heroes.Count);
            SpawnHero(Database.instance.Races.GetRace("Halfling"), Database.instance.Profession.GetProfession("Thief"), Utilities.GetRandomGender(), _heroes.Count);
            SpawnHero(Database.instance.Races.GetRace("Wild Elf"), Database.instance.Profession.GetProfession("Scout"), Utilities.GetRandomGender(), _heroes.Count);
            SpawnHero(Database.instance.Races.GetRace("Imperial"), Database.instance.Profession.GetProfession("Acolyte"), Utilities.GetRandomGender(), _heroes.Count);
            SpawnHero(Database.instance.Races.GetRace("Valarian"), Database.instance.Profession.GetProfession("Apprentice"), Utilities.GetRandomGender(), _heroes.Count);
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

        public void RefreshHeroActions()
        {
            foreach (Hero hero in _heroes)
            {
                hero.Attributes.RefreshActions();
            }
        }

        public void SetSelectHeroWeaponMode(bool ranged)
        {
            _selectedHero.SetEquippedWeapon(ranged);
        }
        
        
        public void SaveState()
        {
            PartySaveData saveData = new PartySaveData(_heroes);
            byte[] saveDataBytes = SerializationUtility.SerializeValue(saveData, DataFormat.JSON);
            File.WriteAllBytes(Database.instance.PartyDataFilePath, saveDataBytes);
        }

        public void LoadState()
        {
            if (!File.Exists(Database.instance.PartyDataFilePath)) return; // No state to load
	
            byte[] bytes = File.ReadAllBytes(Database.instance.PartyDataFilePath);
            PartySaveData saveData = SerializationUtility.DeserializeValue<PartySaveData>(bytes, DataFormat.JSON);

            //_partyController.transform.position = saveData.WorldPosition;
            _heroesParent.ClearTransform();
            _heroes.Clear();

            for (int i = 0; i < saveData.Heroes.Length; i++)
            {
                LoadHero(saveData.Heroes[i]);
            }
            
            //_playerController.transform.position = saveData.WorldPosition;
        }
        
        protected void LoadHero(HeroSaveData saveData)
        {
            //Debug.Log("Spawning Hero at " + mapPosition.ToString());
            GameObject clone = Instantiate(_heroPrefab, _heroesParent);
            
            Hero hero = clone.GetComponent<Hero>();
            hero.LoadHero(saveData);
            clone.name = "Hero: " + hero.GetFullName();
            
            _heroes.Add(hero);
        }
    }
}

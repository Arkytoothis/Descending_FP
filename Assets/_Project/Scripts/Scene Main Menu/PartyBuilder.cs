using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Descending.Attributes;
using Descending.Core;
using Descending.Units;
using UnityEngine;

namespace Descending.Scene_MainMenu
{
    public class PartyBuilder : MonoBehaviour
    {
        [SerializeField] private GameObject _heroPrefab = null;
        //[SerializeField] private CinemachineVirtualCamera _heroCamera = null;
        [SerializeField] private List<Hero> _heroes = null;
        [SerializeField] private List<Transform> _heroMounts = null;

        public List<Hero> Heroes => _heroes;

        public void Setup()
        {
            BuildParty();
        }

        public void BuildParty()
        {
            _heroes.Clear();
            
            SpawnHero(Database.instance.Races.GetRace("Half Orc"), Database.instance.Profession.GetProfession("Soldier"), Utilities.GetRandomGender(), 0);
            SpawnHero(Database.instance.Races.GetRace("Halfling"), Database.instance.Profession.GetProfession("Thief"), Utilities.GetRandomGender(), 1);
            SpawnHero(Database.instance.Races.GetRace("Imperial"), Database.instance.Profession.GetProfession("Acolyte"), Utilities.GetRandomGender(), 2);
            SpawnHero(Database.instance.Races.GetRace("Valarian"), Database.instance.Profession.GetProfession("Apprentice"), Utilities.GetRandomGender(), 3);
        }

        private void SpawnHero(RaceDefinition race, ProfessionDefinition profession, Genders gender, int listIndex)
        {
            _heroMounts[listIndex].ClearTransform();
            GameObject clone = Instantiate(_heroPrefab, _heroMounts[listIndex]);
            Hero hero = clone.GetComponent<Hero>();
            hero.SetupHero(gender, race, profession, listIndex);
            hero.MountPortraitModel();
            clone.name = "Hero: " + hero.GetFullName();
            _heroes.Add(hero);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using UnityEngine;

namespace Descending.Attributes
{
    [CreateAssetMenu(fileName = "Race Database", menuName = "Descending/Database/Race Database")]
    public class RaceDatabase : ScriptableObject
	{
        [SerializeField] private RaceDictionary _races = null;

        public RaceDictionary Races { get => _races; }
        
        public RaceDefinition GetRace(string key)
        {
            return _races[key];
        }

        public RaceDefinition GetRandomRace()
        {
            return Utilities.RandomValues(_races);
        }

        public string GetRandomRaceKey()
        {
            return Utilities.RandomKey(_races);
        }

        public void AddRace(RaceDefinition race)
        {
            if (_races.ContainsKey(race.Key) == false)
            {
                _races.Add(race.Key, race);
            }
        }

        public void RemoveRace(RaceDefinition race)
        {
            if (_races.ContainsKey(race.Key) == true)
            {
                _races.Remove(race.Key);
            }
        }
    }
}
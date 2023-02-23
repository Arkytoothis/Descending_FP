using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using UnityEngine;

namespace Descending.Attributes
{
    [CreateAssetMenu(fileName = "Profession Database", menuName = "Descending/Database/Profession Database")]
    public class ProfessionDatabase : ScriptableObject
	{
        [SerializeField] private ProfessionDictionary _professions = null;

        public ProfessionDictionary Professions { get => _professions; }
        
        public ProfessionDefinition GetProfession(string key)
        {
            return _professions[key];
        }

        public ProfessionDefinition GetRandomProfession()
        {
            return Utilities.RandomValues(_professions);
        }

        public string GetRandomProfessionKey()
        {
            return Utilities.RandomKey(_professions);
        }

        public void AddProfession(ProfessionDefinition profession)
        {
            if (_professions.ContainsKey(profession.Key) == false)
            {
                _professions.Add(profession.Key, profession);
            }
        }

        public void RemoveProfession(ProfessionDefinition profession)
        {
            if (_professions.ContainsKey(profession.Key) == true)
            {
                _professions.Remove(profession.Key);
            }
        }
    }
}
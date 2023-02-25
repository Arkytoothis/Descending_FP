using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using UnityEngine;

namespace Descending.Encounters
{
    [System.Serializable]
    public class InitiativeData
    {
        [SerializeField] private int _initiativeRoll = 0;
        [SerializeField] private Hero _hero = null;
        [SerializeField] private Enemy _enemy = null;

        public int InitiativeRoll => _initiativeRoll;
        public Hero Hero => _hero;
        public Enemy Enemy => _enemy;

        public InitiativeData(int initiativeRoll, Hero hero)
        {
            _initiativeRoll = initiativeRoll;
            _hero = hero;
            _enemy = null;
        }
        
        public InitiativeData(int initiativeRoll, Enemy enemy)
        {
            _initiativeRoll = initiativeRoll;
            _enemy = enemy;
            _hero = null;
        }
    }
}

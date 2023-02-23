using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using UnityEngine;

namespace Descending.Abilities
{
    [System.Serializable]
    public class UseAbilityData
    {
        [SerializeField] private Unit _user = null;
        [SerializeField] private List<Unit> _targets = null;
        [SerializeField] private Ability _ability = null;
        
        public Ability Ability => _ability;
        public Unit User => _user;
        public List<Unit> Targets => _targets;
        
        public UseAbilityData(Unit user, List<Unit> targets, Ability ability)
        {
            _user = user;
            _targets = targets;
            _ability = ability;
        }
        
        public void SetTargets(List<Unit> targets)
        {
            _targets = new List<Unit>();
            for (int i = 0; i < targets.Count; i++)
            {
                _targets.Add(targets[i]);
            }
        }
    }
}
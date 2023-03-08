using System.Collections;
using System.Collections.Generic;
using Descending.Abilities;
using UnityEngine;

namespace Descending.Units
{
    public class UnitEffects : MonoBehaviour
    {
        [SerializeReference] private List<UnitEffect> _effects = null;
        
        public List<UnitEffect> Effects => _effects;

        public void Setup()
        {
            _effects = new List<UnitEffect>();
        }

        public void AddEffect(Ability ability)
        {
            UnitEffect unitEffect = new UnitEffect(ability, ability.Definition.Icon, ability.Definition.RollDuration());
            _effects.Add(unitEffect);
            //Debug.Log(unitEffect.GetType() + " added to UnitEffects");
        }
    }
}
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

        public void AddEffect(AbilityEffect abilityEffect)
        {
            ModifyAttributeUnitEffect unitEffect = new ModifyAttributeUnitEffect(abilityEffect);
            //Debug.Log(unitEffect.GetType() + " added to UnitEffects");
            _effects.Add(unitEffect);
        }

        public void NextTurn()
        {
            foreach (UnitEffect unitEffect in _effects)
            {
                unitEffect.NextTurn();
            }

            for (int i = _effects.Count - 1; i >= 0; i--)
            {
                if (_effects[i].Duration <= 0)
                {
                    _effects.RemoveAt(i);
                }
            }
            
            //HeroManager_Combat.Instance.RecalculateHeroAttributes();
        }
    }
}
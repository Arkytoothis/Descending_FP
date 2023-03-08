using System.Collections;
using System.Collections.Generic;
using Descending.Abilities;
using UnityEngine;

namespace Descending.Units
{
    [System.Serializable]
    public class UnitEffect
    {
        [SerializeField] private Sprite _icon = null;
        [SerializeField] private int _duration = 0;
        [SerializeField] private Ability _ability = null;
        [SerializeField] private bool _isActive = false;
        
        public Sprite Icon => _icon;
        public int Duration => _duration;
        public Ability Ability => _ability;
        public bool IsActive => _isActive;

        public UnitEffect(Ability ability, Sprite icon, int duration)
        {
            _ability = ability;
            _icon = icon;
            _duration = duration;
            _isActive = true;
        }

        public void TickTime()
        {
            _duration -= 1;

            if (_duration <= 0)
            {
                _isActive = false;
            }
        }

        public void Process(Unit target)
        {
            foreach (AbilityEffect abilityEffect in _ability.Definition.Effects.Data)
            {
                if (abilityEffect.GetType() == typeof(RestoreOverTimeEffect))
                {
                    RestoreOverTimeEffect restoreOverTimeEffect = (RestoreOverTimeEffect)abilityEffect;
                    
                    target.RestoreVital(restoreOverTimeEffect.Attribute.Key, restoreOverTimeEffect.RollRestoreAmount());
                }
            }
        }
    }
}
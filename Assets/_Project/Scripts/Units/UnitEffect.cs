using System.Collections;
using System.Collections.Generic;
using Descending.Abilities;
using UnityEngine;

namespace Descending.Units
{
    [System.Serializable]
    public abstract class UnitEffect
    {
        [SerializeField] protected Sprite _icon = null;
        [SerializeField] protected int _duration = 0;
        
        public Sprite Icon => _icon;
        public int Duration => _duration;

        public void NextTurn()
        {
            _duration--;

            if (_duration <= 0)
            {
                
            }
        }

        public abstract string GetTooltipHeading();
        public abstract string GetTooltipText();
    }
}
using Sirenix.OdinInspector;
using System.Collections.Generic;
using Descending.Core;
using Descending.Units;
using UnityEngine;

namespace Descending.Abilities
{
    [System.Serializable]
    public abstract class AbilityEffect
    {
        [SerializeField] protected AbilityEffectAffects _affects = AbilityEffectAffects.None;

        public AbilityEffectAffects Affects { get => _affects; set => _affects = value; }

        public virtual string GetTooltipText() { return ""; }
        public virtual void Process(Ability abiltiy, Unit user, List<Unit> targets) { }
    }
}
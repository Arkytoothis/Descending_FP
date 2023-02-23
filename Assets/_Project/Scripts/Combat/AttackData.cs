using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using UnityEngine;

namespace Descending.Combat
{
    [System.Serializable]
    public class AttackData
    {
        public DamageClasses DamageClass;
        public DamageTypeDefinition DamageType;
        public int MinDamage;
        public int MaxDamage;

        public AttackData(DamageClasses damageClass, DamageTypeDefinition damageType, int minDamage, int maxDamage)
        {
            DamageClass = damageClass;
            DamageType = damageType;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
        }
    }
}
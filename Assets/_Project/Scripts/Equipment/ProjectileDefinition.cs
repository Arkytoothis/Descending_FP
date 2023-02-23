using System.Collections;
using System.Collections.Generic;
using Descending.Abilities;
using Descending.Combat;
using Descending.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace Descending.Equipment
{
    [CreateAssetMenu(fileName = "Projectile Definition", menuName = "Descending/Definition/Projectile Definition")]
    public class ProjectileDefinition : ScriptableObject
    {
        public GameObject Prefab = null;
        public DamageTypeDefinition DamageType = null;
        public DamageClasses DamageClass = DamageClasses.None;
        public float Speed = 30f;

        public List<DamageEffect> DamageEffects;
    }
}
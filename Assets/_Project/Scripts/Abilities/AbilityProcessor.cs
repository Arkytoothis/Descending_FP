using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using UnityEngine;

namespace Descending.Abilities
{
    public static class AbilityProcessor
    {
        public static void ProcessAbility(Unit hero, List<Unit> targets, Ability ability, Transform spawnPoint)
        {
            //Debug.Log(user.GetName() + " uses " + ability.Definition.Details.Name + " on " + targets[0].GetName());
            // if (ability.Definition.Details.Projectile != null)
            // {
            //     GameObject clone = GameObject.Instantiate(ability.Definition.Details.Projectile.Prefab, spawnPoint.position, spawnPoint.rotation);
            //     //Projectile projectile = clone.GetComponent<Projectile>();
            //
            //     //bool targetHit = true;
            //     //projectile.Setup(hero, targets[0].transform, GameEntityTypes.Hero, GameEntityTypes.Enemy, ability, targetHit);
            //     //clone.GetComponent<Rigidbody>().velocity = (targets[0].ProjectileTarget.position - spawnPoint.position).normalized * ability.Definition.Details.Projectile.Speed;
            // }
            // else
            // {
            //     ability.Use(hero, targets);
            // }
        }
    }
}
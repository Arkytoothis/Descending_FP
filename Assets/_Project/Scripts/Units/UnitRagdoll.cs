using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEngine;

namespace Descending.Units
{
    public class UnitRagdoll : MonoBehaviour
    {
        [SerializeField] private Transform _ragdollRootBone = null;

        public void Setup(GameObject source, Transform unitRootBone)
        {
            // MatchAllChildTransforms(unitRootBone, _ragdollRootBone);
            // Projectile projectile = source.GetComponent<Projectile>();
            //
            // if (projectile != null)
            // {
            //     ApplyForce(_ragdollRootBone, projectile.Force, projectile.SourceUnit.transform.position, 3f);
            //     return;
            // }
            //
            // ThrowableProjectile throwableProjectile = source.GetComponent<ThrowableProjectile>();
            //
            // if (throwableProjectile != null)
            // {
            //     ApplyForce(_ragdollRootBone, throwableProjectile.Force, throwableProjectile.transform.position, 1f);
            //     return;
            // }
            //
            // ApplyForce(_ragdollRootBone, 300f, source.transform.position, 1f);
        }

        private void MatchAllChildTransforms(Transform root, Transform clone)
        {
            foreach (Transform child in root)
            {
                Transform cloneChild = clone.Find(child.name);

                if (cloneChild != null)
                {
                    cloneChild.position = child.position;
                    cloneChild.rotation = child.rotation;
                    
                    MatchAllChildTransforms(child, cloneChild);
                }
            }
        }

        private void ApplyForce(Transform root, float force, Vector3 position, float upwardsModifier)
        {
            foreach (Transform child in root)
            {
                if(child.TryGetComponent<Rigidbody>(out Rigidbody childRigidBody))
                {
                    childRigidBody.AddExplosionForce(force, position, 1000f, upwardsModifier);
                }
                
                ApplyForce(child, force, position, upwardsModifier);
            }
        }
    }
}


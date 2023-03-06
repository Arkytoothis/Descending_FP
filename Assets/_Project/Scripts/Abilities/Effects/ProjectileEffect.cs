using System.Collections;
using System.Collections.Generic;
using System.Text;
using Descending.Equipment;
using Descending.Player;
using Descending.Units;
using UnityEngine;

namespace Descending.Abilities
{
    [System.Serializable]
    public class ProjectileEffect : AbilityEffect
    {
        [SerializeField] private ProjectileDefinition _projectileDefinition = null;
        [SerializeField] private float _spawnProjectileDelay = 0.5f;
        [SerializeField] private float _delayBetweenProjectiles = 0.25f;
        [SerializeField] private int _numProjectiles = 1;

        public ProjectileDefinition ProjectileDefinition => _projectileDefinition;
        public float SpawnProjectileDelay => _spawnProjectileDelay;
        public float DelayBetweenProjectiles => _delayBetweenProjectiles;
        public int NumProjectiles => _numProjectiles;

        public override string GetTooltipText()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Projectile causes ").Append(_projectileDefinition.DamageType.Name).Append(" damage\n");

            return sb.ToString();
        }

        public override void Process(Unit user, List<Unit> targets)
        {
            //_projectileSpawnPoint = user.ProjectileSpawnPoint;
            user.StartCoroutine(DelayedSpawnProjectile(user, targets[0]));
        }
        
        private IEnumerator DelayedSpawnProjectile(Unit user, Unit target)
        {
            yield return new WaitForSeconds(_spawnProjectileDelay);
            
            Transform projectileTransform = PlayerManager.Instance.GetProjectileSpawn((Hero)user);
            
            for (int i = 0; i < _numProjectiles; i++)
            {
                yield return new WaitForSeconds(_delayBetweenProjectiles);

                GameObject clone = GameObject.Instantiate(_projectileDefinition.Prefab, projectileTransform.position, projectileTransform.rotation);
                
                if (target != null)
                {
                    Vector3 projectileTargetPosition = target.transform.position;
                    projectileTargetPosition.y = projectileTransform.position.y;
                
                    Projectile projectile = clone.GetComponent<Projectile>();
                    projectile.Setup(user, target, _projectileDefinition);
                }
            }
        }
    }
}
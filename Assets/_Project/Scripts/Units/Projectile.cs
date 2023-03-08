using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Abilities;
using Descending.Equipment;
using Descending.Player;
using UnityEngine;

namespace Descending.Units
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private ProjectileDefinition _definition;
        [SerializeField] private List<GameObject> _trailEffects = null;
        [SerializeField] private float _hitDistance = 0.1f;

        private Unit _sourceUnit;
        private Unit _targetUnit;

        public ProjectileDefinition Definition => _definition;

        public void Setup(Unit sourceUnit, Unit targetUnit, ProjectileDefinition projectileDefinition)
        {
            _sourceUnit = sourceUnit;
            _targetUnit = targetUnit;
            
            if(sourceUnit.GetType() == typeof(Hero))
                transform.LookAt(((Enemy)_targetUnit).ProjectileTarget);
            if(sourceUnit.GetType() == typeof(Enemy))
                transform.LookAt(PlayerManager.Instance.GetProjectileSpawn((Hero)targetUnit));
            
            GetComponent<Rigidbody>().AddForce(transform.forward * projectileDefinition.Speed);
            
            Destroy(gameObject, 2f);
        }

        private void Update()
        {
            if (_targetUnit == null || _targetUnit.gameObject == null || _targetUnit.IsAlive == false)
            {
                Destroy();
                return;
            }
            
            if(_targetUnit.GetType() == typeof(Enemy))
            {
                if (Vector3.Distance(transform.position, ((Enemy)_targetUnit).ProjectileTarget.position) < _hitDistance)
                {
                    HitTarget();
                }
            }
            else if(_targetUnit.GetType() == typeof(Hero))
            {
                if (Vector3.Distance(transform.position, PlayerManager.Instance.GetProjectileSpawn((Hero)_targetUnit).position) < _hitDistance)
                {
                    HitTarget();
                }
            }
        }

        private void HitTarget()
        {
            foreach (DamageEffect hitEffect in _definition.DamageEffects)
            {
                hitEffect.Process(null, _sourceUnit, new List<Unit>{ _targetUnit });
            }

            Destroy();
        }

        private void Destroy()
        {
            foreach (GameObject trailEffect in _trailEffects)
            {
                trailEffect.transform.SetParent(null);
                Destroy(trailEffect, 1f);
            }
            
            Destroy(gameObject);
        }
    }
}
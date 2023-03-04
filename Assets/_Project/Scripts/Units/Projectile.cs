using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Abilities;
using Descending.Equipment;
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
        
        public void Setup(Unit sourceUnit, Unit targetUnit, ProjectileDefinition projectileDefinition)
        {
            _sourceUnit = sourceUnit;
            _targetUnit = targetUnit;
            
            transform.LookAt(((Enemy)_targetUnit).ProjectileTarget);
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
            
            if (Vector3.Distance(transform.position, ((Enemy)_targetUnit).ProjectileTarget.position) < _hitDistance)
            {
                HitTarget();
            }
        }

        private void HitTarget()
        {
            //Debug.Log(_targetUnit.GetFullName() + " hit");
            foreach (DamageEffect hitEffect in _definition.DamageEffects)
            {
                hitEffect.Process(_sourceUnit, new List<Unit>{ _targetUnit });
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
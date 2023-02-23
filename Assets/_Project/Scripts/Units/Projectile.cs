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
        [SerializeField] private AnimationCurve _arcCurve;
        [SerializeField] private TrailRenderer _trailRenderer = null;
        [SerializeField] private GameObject _hitEffectPrefab = null;
        [SerializeField] private float _force = 300f;
        [SerializeField] private float _minimumDistance = 0.2f;

        private Unit _sourceUnit;
        private Unit _targetUnit;
        private float _moveSpeed = 100f;
        private Vector3 _targetPosition;
        private Vector3 _positionXZ;
        private float _totalDistance;
        private Rigidbody _rigidbody;
        private bool _destroyed = false;
        
        public Unit SourceUnit => _sourceUnit;
        public Unit TargetUnit => _targetUnit;
        public float Force => _force;

        public void Setup(Unit sourceUnit, Unit targetUnit, Item weapon)
        {
            _destroyed = false;
            _sourceUnit = sourceUnit;
            _targetUnit = targetUnit;

            if (weapon.GetWeaponData().Projectile != null)
            {
                _moveSpeed = weapon.GetWeaponData().Projectile.Speed;
            }
            
            //_targetPosition = _targetUnit.HitTransform.position;
            _positionXZ = new Vector3(transform.position.x, 0, transform.position.z);
            _totalDistance = Vector3.Distance(_positionXZ, _targetPosition);
        }
        
        public void Setup(Unit sourceUnit, Unit targetUnit, ProjectileDefinition projectileDefinition)
        {
            _destroyed = false;
            _sourceUnit = sourceUnit;
            _targetUnit = targetUnit;
            _moveSpeed = projectileDefinition.Speed;
            //_targetPosition = _targetUnit.HitTransform.position;
            _positionXZ = new Vector3(transform.position.x, 0, transform.position.z);
            _totalDistance = Vector3.Distance(_positionXZ, _targetPosition);
        }

        private void Update()
        {
            if (gameObject == null) return;
            
            if (_targetUnit == null && _destroyed == false)
            {
                _destroyed = true;
                //transform.DOScale(0f, 0.5f);
                Destroy(gameObject);
                return;
            }

            Vector3 moveDirection = (_targetPosition - _positionXZ).normalized;
            _positionXZ += moveDirection * _moveSpeed * Time.deltaTime;
            float distanceBeforeMoving = Vector3.Distance(_positionXZ, _targetPosition);
            float distanceNormalized = 1 - distanceBeforeMoving / _totalDistance;
            float positionY = _arcCurve.Evaluate(distanceNormalized);
            if (positionY > 1f) positionY = 1f;
            if (positionY < 0f) positionY = 1f;
            
            transform.position = new Vector3(_positionXZ.x, positionY, _positionXZ.z);
            transform.forward = _targetPosition - transform.position;
            float distanceAfterMoving = Vector3.Distance(_positionXZ, _targetPosition);
            
            if (distanceAfterMoving < _minimumDistance && _destroyed == false)
            {
                foreach (DamageEffect hitEffect in _definition.DamageEffects)
                {
                    hitEffect.Process(_sourceUnit, new List<Unit>{ _targetUnit });
                }

                if (_trailRenderer != null)
                {
                    _trailRenderer.transform.SetParent(null);
                }
                
                transform.position = _targetPosition;
                
                Destroy(gameObject);
                Instantiate(_hitEffectPrefab, _targetPosition, Quaternion.identity);
            }
        }
        
        // private void Update()
        // {
        //     Vector3 moveDirection = (_targetPosition - _positionXZ).normalized;
        //     _positionXZ += moveDirection * _moveSpeed * Time.deltaTime;
        //     float currentDistance = Vector3.Distance(_positionXZ, _targetPosition);
        //     float distanceNormalized = 1 - currentDistance / _totalDistance;
        //     float positionY = _arcCurve.Evaluate(distanceNormalized);
        //     transform.position = new Vector3(_positionXZ.x, positionY, _positionXZ.z);
        //     float distanceAfterMoving = Vector3.Distance(_positionXZ, _targetPosition);
        //     
        //     if (currentDistance < distanceAfterMoving) 
        //     {
        //         int damage = Random.Range(_minimumDamage, _maximumDamage + 1);
        //         _targetUnit.Damage(gameObject, damage);
        //         
        //         transform.position = _positionXZ;
        //         _trailRenderer.transform.SetParent(null);
        //         
        //         Destroy(gameObject);
        //         Instantiate(_hitEffectPrefab, _targetPosition, Quaternion.identity);
        //     }
        // }
    }
}
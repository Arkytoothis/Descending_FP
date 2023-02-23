using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Attributes;
using Descending.Combat;
using Descending.Core;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Descending.Units
{

    public class ThrowableProjectile : MonoBehaviour
    {
        public static event EventHandler OnAnyThrowComplete;
        
        [SerializeField] private GameObject _hitEffect;
        [SerializeField] private TrailRenderer _trailRenderer;
        [SerializeField] private AnimationCurve _arcCurve;
        [SerializeField] private float _force = 600f;
        [SerializeField] private float _moveSpeed = 15f;
        [SerializeField] private float _minimumDistance = 0.1f;
        [SerializeField] private float _damageRadius = 4f;
        [SerializeField] private int _minimumDamage = 0;
        [SerializeField] private int _maximumDamage = 0;
        [SerializeField] private AttributeDefinition _attribute = null;

        private Action onThrowComplete;
        private Vector3 _targetPosition;
        private Vector3 _positionXZ;
        private float _totalDistance;
        private DamageTypeDefinition _damageType;
        private Unit _sourceUnit;

        public Unit SourceUnit => _sourceUnit;
        public float Force => _force;
        public DamageTypeDefinition DamageType => _damageType;
        public AttributeDefinition Attribute => _attribute;

        // public void Setup(Unit sourceUnit, MapPosition targetMapPosition, Action onThrowComplete, DamageTypeDefinition damageType, AttributeDefinition attribute)
        // {
        //     _sourceUnit = sourceUnit;
        //     this.onThrowComplete = onThrowComplete;
        //     _targetPosition = MapManager.Instance.GetWorldPosition(targetMapPosition);
        //     _positionXZ = new Vector3(transform.position.x, 0, transform.position.z);
        //     _totalDistance = Vector3.Distance(_positionXZ, _targetPosition);
        //     _damageType = damageType;
        //     _attribute = attribute;
        // }

        private void Update()
        {
            Vector3 moveDirection = (_targetPosition - _positionXZ).normalized;
            _positionXZ += moveDirection * _moveSpeed * Time.deltaTime;
            float currentDistance = Vector3.Distance(_positionXZ, _targetPosition);
            float distanceNormalized = 1 - currentDistance / _totalDistance;
            float positionY = _arcCurve.Evaluate(distanceNormalized);
            transform.position = new Vector3(_positionXZ.x, positionY, _positionXZ.z);
            
            if (Vector3.Distance(_positionXZ, _targetPosition) < _minimumDistance)
            {
                Collider[] colliders = Physics.OverlapSphere(_targetPosition, _damageRadius);

                foreach (Collider collidersHit in colliders)
                {
                    if (collidersHit.TryGetComponent<Unit>(out Unit targetUnit))
                    {
                        int damage = Random.Range(_minimumDamage, _maximumDamage + 1);
                        targetUnit.Damage(gameObject, _damageType, damage, _attribute.Key);
                    }
                    
                    // if (collidersHit.TryGetComponent<Crate>(out Crate crate))
                    // {
                    //     int damage = Random.Range(_minimumDamage, _maximumDamage + 1);
                    //     crate.Damage(damage);
                    // }
                }
                
                OnAnyThrowComplete?.Invoke(this, EventArgs.Empty);
                _trailRenderer.transform.SetParent(null);
                GameObject clone = Instantiate(_hitEffect, _targetPosition + Vector3.up * 1f, Quaternion.identity);
                Destroy(gameObject);
                onThrowComplete();
            }
        }
    }
}

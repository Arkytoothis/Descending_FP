using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Units
{
    public class RagdollSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _ragdollPrefab = null;
        [SerializeField] private DamageSystem _damageSystem = null;
        [SerializeField] private Transform _unitRootBone = null;

        private void Awake()
        {
            _damageSystem = GetComponent<DamageSystem>();
        }

        public void Activate(DamageSystem damageSystem)
        {
            GameObject clone = Instantiate(_ragdollPrefab, transform.position, transform.rotation);
            UnitRagdoll ragdoll = clone.GetComponent<UnitRagdoll>();
            ragdoll.Setup(damageSystem.Attacker, _unitRootBone);
        }
    }
}
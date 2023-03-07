using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Equipment;
using UnityEngine;

namespace Descending.Units
{
    public class UnitAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator = null;
        
        private Unit _unit;
        
        private void Awake()
        {
            _unit = GetComponent<Unit>();
        }

        public void Setup(Animator animator)
        {
            _animator = animator;
        }
        
        public void MeleeAttack()
        {
            _animator.SetTrigger("MeleeAttack");
        }

        public void RangedAttack()
        {
            _animator.SetTrigger("RangedAttack");
        }

        public void Cast()
        {
            _animator.SetTrigger("Cast");
        }

        public void Die()
        {
            _animator.SetTrigger("Die");
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using Descending.Equipment;
using UnityEngine;

namespace Descending.Units
{
    public class AnimationEvents : MonoBehaviour
    {
        private InventoryController _inventory = null;

        public void Setup(InventoryController inventory)
        {
            _inventory = inventory;
        }
        
        public void Shoot()
        {
        }

        public void FootR()
        {
            //_inventory.PlayStepSound();
        }

        public void FootL()
        {
            //_inventory.PlayStepSound();
        }

        public void Land()
        {
        }

        public void WeaponSwitch()
        {
        }

        public void Hit()
        {
        }

        public void Strike()
        {
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Gui;
using UnityEngine;

namespace Descending.Units
{
    public class DamageSystem : MonoBehaviour
    {
        [SerializeField] private EnemyWorldPanel _worldPanel = null;

        private Unit _unit = null;
        private GameObject _attacker = null;

        public GameObject Attacker => _attacker;

        public void Setup(Hero hero)
        {
            _unit = hero;
        }
        
        public void Setup(Enemy enemy)
        {
            _unit = enemy;
        }
        
        public void TakeDamage(GameObject attacker, int amount)
        {
            _attacker = attacker;
            int damageLeft = amount;
            
            if (_unit.Attributes.GetVital("Armor").Current > 0) 
            {
                int armorDamage = Math.Min(damageLeft, _unit.Attributes.GetVital("Armor").Current);
                _unit.Attributes.GetVital("Armor").Damage(armorDamage, true);
                damageLeft -= armorDamage;
                
                if (damageLeft > 0)
                {
                    _unit.Attributes.GetVital("Life").Damage(damageLeft, false);
                }
            } 
            
            if(_worldPanel != null)
                _worldPanel.Sync();
        }

        public void UseResource(string vital, int amount)
        {
            _unit.Attributes.GetVital(vital).Damage(amount, true);
            
            if(_worldPanel != null)
                _worldPanel.Sync();
        }

        public void RestoreVital(string vital, int amount)
        {
            _unit.Attributes.GetVital(vital).Restore(amount);

            if(_worldPanel != null)
                _worldPanel.Sync();
        }

        public float GetVitalNormalized(string vitalKey)
        {
            return (float)_unit.Attributes.GetVital(vitalKey).TotalCurrent() / _unit.Attributes.GetVital(vitalKey).TotalMaximum();
        }
    }
}
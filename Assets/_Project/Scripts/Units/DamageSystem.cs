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
        
        public void TakeDamage(GameObject attacker, int amount, string vital)
        {
            _attacker = attacker;
            int damageLeft = amount;
            
            if (_unit.Attributes.GetVital("Armor").Current > 0) 
            {
                int armorDamage = Math.Min(damageLeft, _unit.Attributes.GetVital("Armor").Current);
                _unit.Attributes.GetVital("Armor").Damage(armorDamage, true);
                damageLeft -= armorDamage;
            } 

            if (damageLeft > 0)
            {
                _unit.Attributes.GetVital(vital).Damage(damageLeft, false);
            }

            _worldPanel.Sync();
            //HeroManager.Instance.SyncHero(_unit.da);
            //Debug.Log(name + " takes " + amount + " damage, " + _health + " health remaining");
        }

        public void UseResource(string vital, int amount)
        {
            _unit.Attributes.GetVital(vital).Damage(amount, true);
            _worldPanel.Sync();
            //HeroManager_Combat.Instance.SyncHeroes();
        }

        public void RestoreVital(string vital, int amount)
        {
            _unit.Attributes.GetVital(vital).Restore(amount);
            _worldPanel.Sync();
            //HeroManager_Combat.Instance.SyncHeroes();
        }

        public float GetVitalNormalized(string vitalKey)
        {
            return (float)_unit.Attributes.GetVital(vitalKey).TotalCurrent() / _unit.Attributes.GetVital(vitalKey).TotalMaximum();
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Attributes;
using Descending.Core;
using Descending.Gui;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Units
{
    public enum DamageTextTypes { Hero, Enemy }
    
    public class DamageSystem : MonoBehaviour
    {
        [SerializeField] private EnemyWorldPanel _worldPanel = null;

        private Unit _unit = null;
        private Unit _attacker = null;
        private int _listIndex = -1;

        public Unit Attacker => _attacker;

        public void Setup(Hero hero)
        {
            _unit = hero;
            _listIndex = hero.HeroData.ListIndex;
        }
        
        public void Setup(Enemy enemy)
        {
            _unit = enemy;
            _listIndex = 0;
        }
        
        public void TakeDamage(Unit attacker, int amount)
        {
            _attacker = attacker;
            int damageLeft = amount;
            
            if (_unit.Attributes.GetVital("Armor").Current > 0) 
            {
                int armorDamage = Math.Min(damageLeft, _unit.Attributes.GetVital("Armor").Current);
                _unit.Attributes.GetVital("Armor").Damage(armorDamage, true);
                _unit.DisplayDamageText(armorDamage, Database.instance.Attributes.GetVital("Armor"));
                damageLeft -= armorDamage;
            } 
                
            if (damageLeft > 0)
            {
                _unit.Attributes.GetVital("Life").Damage(damageLeft, false);
                _unit.DisplayDamageText(damageLeft, Database.instance.Attributes.GetVital("Life"));
            }
            
            if(_worldPanel != null)
                _worldPanel.Sync();
        }

        public void UseResource(string vital, int amount)
        {
            _unit.Attributes.GetVital(vital).Damage(amount, true);
            _unit.DisplayDamageText(amount, Database.instance.Attributes.GetVital(vital));
            
            if(_worldPanel != null)
                _worldPanel.Sync();
        }

        public void RestoreVital(string vital, int amount)
        {
            _unit.Attributes.GetVital(vital).Restore(amount);
            _unit.DisplayHealText(amount, Database.instance.Attributes.GetVital(vital));

            if(_worldPanel != null)
                _worldPanel.Sync();
        }

        public float GetVitalNormalized(string vitalKey)
        {
            return (float)_unit.Attributes.GetVital(vitalKey).TotalCurrent() / _unit.Attributes.GetVital(vitalKey).TotalMaximum();
        }
    }
}
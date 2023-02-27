using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using UnityEngine;
using UnityEngine.UI;

namespace Descending.Gui
{
    public class EnemyWorldPanel : MonoBehaviour
    {
        [SerializeField] private Image _armorImage = null;
        [SerializeField] private Image _lifeImage = null;
        
        private Enemy _enemy = null;
        
        public void Setup(Enemy enemy)
        {
            if (enemy == null) return;
            _enemy = enemy;
            
            Sync();
        }

        public void Sync()
        {
            if (_enemy == null) return;
            
            _armorImage.fillAmount = _enemy.DamageSystem.GetVitalNormalized("Armor");
            _lifeImage.fillAmount = _enemy.DamageSystem.GetVitalNormalized("Life");
        }

        void Update()
        {
            transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
        }
    }
}

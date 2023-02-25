using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Descending.Gui
{
    public class EnemyInitiativeWidget : InitiativeWidget
    {
        [SerializeField] private Image _portrait = null;
        
        private Enemy _enemy = null;

        public void Setup(Enemy enemy, int index, int initiativeRoll)
        {
            _enemy = enemy;
            _index = index;
            _initiativeRoll = initiativeRoll;
            _portrait.sprite = _enemy.Definition.Icon;
            _nameLabel.SetText(_enemy.GetShortName());
            _initiativeLabel.SetText(_initiativeRoll.ToString());
        }
    }
}

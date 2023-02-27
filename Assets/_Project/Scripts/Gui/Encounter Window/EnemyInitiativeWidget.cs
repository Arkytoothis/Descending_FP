using System.Collections;
using System.Collections.Generic;
using Descending.Player;
using Descending.Units;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Descending.Gui
{
    public class EnemyInitiativeWidget : InitiativeWidget, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image _portrait = null;
        [SerializeField] private Sprite _deadImage = null;
        
        private Enemy _enemy = null;

        public Enemy Enemy => _enemy;

        public void Setup(Enemy enemy, int index, int initiativeRoll)
        {
            _enemy = enemy;
            _index = index;
            _initiativeRoll = initiativeRoll;
            _portrait.sprite = _enemy.Definition.Icon;
            _nameLabel.SetText(_enemy.GetShortName());
            _nameLabel.color = _nameColor;
            _initiativeLabel.SetText(_initiativeRoll.ToString());
            
            Sync();
            Deselect();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            CombatRaycaster.Instance.SetInitiativeWidgetHover(this);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            CombatRaycaster.Instance.ClearInitiativeWidget();
        }

        public override void Select()
        {
            _selectionBorder.enabled = true;
            _deselectedImage.enabled = false;
        }

        public override void Deselect()
        {
            _selectionBorder.enabled = false;
            _deselectedImage.enabled = true;
        }

        public override void Sync()
        {
            if (_enemy.IsAlive == true)
            {
                _lifeBar.UpdateData(_enemy.Attributes.GetVital("Life").Current, _enemy.Attributes.GetVital("Life").Maximum);
            }
            else
            {
                _portrait.sprite = _deadImage;
                _lifeBar.UpdateData(_enemy.Attributes.GetVital("Life").Current, _enemy.Attributes.GetVital("Life").Maximum);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Descending.Player;
using Descending.Units;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Descending.Gui
{
    public class HeroInitiativeWidget : InitiativeWidget, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private RawImage _portrait = null;
        
        private Hero _hero = null;

        public Hero Hero => _hero;

        public void Setup(Hero hero, int index, int initiativeRoll)
        {
            _hero = hero;
            _index = index;
            _initiativeRoll = initiativeRoll;
            _portrait.texture = hero.Portrait.RtClose;
            _nameLabel.SetText(hero.HeroData.Name.FirstName);
            _nameLabel.color = _nameColor;
            _initiativeLabel.SetText(_initiativeRoll.ToString());
            _lifeBar.UpdateData(_hero.Attributes.GetVital("Life").Current, _hero.Attributes.GetVital("Life").Maximum);
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
    }
}

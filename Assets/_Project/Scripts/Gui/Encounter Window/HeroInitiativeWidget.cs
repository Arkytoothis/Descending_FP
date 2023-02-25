using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Descending.Gui
{
    public class HeroInitiativeWidget : InitiativeWidget
    {
        [SerializeField] private RawImage _portrait = null;
        
        private Hero _hero = null;

        public void Setup(Hero hero, int index, int initiativeRoll)
        {
            _hero = hero;
            _index = index;
            _initiativeRoll = initiativeRoll;
            _portrait.texture = hero.Portrait.RtClose;
            _nameLabel.SetText(hero.HeroData.Name.FirstName);
            _initiativeLabel.SetText(_initiativeRoll.ToString());
        }
    }
}

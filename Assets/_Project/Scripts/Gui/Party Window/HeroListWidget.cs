using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Descending.Gui
{
    public class HeroListWidget : MonoBehaviour
    {
        [SerializeField] private RawImage _portraitImage = null;
        [SerializeField] private TMP_Text _nameLabel = null;
        [SerializeField] private TMP_Text _detailsLabel = null;

        private PartyWindow _partyWindow = null;
        private HeroUnit _hero = null;
        
        public void Setup(PartyWindow partyWindow, HeroUnit hero)
        {
            _hero = hero;
            
            if(_hero.Portrait != null)
                _portraitImage.texture = hero.Portrait.RtClose;
            
            _partyWindow = partyWindow;
            _nameLabel.SetText(hero.GetShortName());
            _detailsLabel.SetText(hero.HeroData.Gender + " " + hero.HeroData.RaceKey + " " + hero.HeroData.ProfessionKey);
        }

        public void OnLeftClick()
        {
            _partyWindow.SelectHero(_hero);
        }
    }
}
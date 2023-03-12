using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using TMPro;
using UnityEngine;

namespace Descending.Gui
{
    public class StartingHeroWidget : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameLabel = null;
        [SerializeField] private TMP_Text _detailsLabel = null;

        public void DisplayHero(Hero hero)
        {
            _nameLabel.SetText(hero.GetFullName());
            _detailsLabel.SetText("Level " + hero.HeroData.Level + " " + hero.HeroData.Gender + " " + hero.HeroData.RaceKey + " " + hero.HeroData.ProfessionKey);
        }
    }
}
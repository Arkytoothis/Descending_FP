using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using TMPro;
using UnityEngine;

namespace Descending.Gui
{
    public class HeroDetailsPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameLabel = null;
        [SerializeField] private TMP_Text _raceLabel = null;
        [SerializeField] private TMP_Text _professionLabel = null;
        [SerializeField] private TMP_Text _backgroundLabel = null;
        [SerializeField] private VitalBar _experienceBar = null;

        public void Setup()
        {
            
        }
        
        public void DisplayHero(Hero hero)
        {
            _nameLabel.SetText(hero.GetFullName());
            _raceLabel.SetText("Race: " + hero.HeroData.RaceKey);
            _professionLabel.SetText("Profession: " + hero.HeroData.ProfessionKey);
            _backgroundLabel.SetText("Background: none");
            //_experienceBar.UpdateData(hero.HeroData.Experience, hero.HeroData.ExpToNextLevel);
        }
    }
}
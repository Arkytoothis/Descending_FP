using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using UnityEngine;

namespace Descending.Gui
{
    public class HeroVitalsPanel : MonoBehaviour
    {
        [SerializeField] private VitalWidget _actionsWidget = null;
        [SerializeField] private VitalWidget _armorWidget = null;
        [SerializeField] private VitalWidget _lifeWidget = null;
        [SerializeField] private VitalWidget _staminaWidget = null;
        [SerializeField] private VitalWidget _magicWidget = null;
        [SerializeField] private VitalWidget _luckWidget = null;

        public void Setup()
        {
            
        }
        
        public void DisplayHero(Hero hero)
        {
            _actionsWidget.SetAttribute(hero.Attributes.GetVital("Actions"));
            _armorWidget.SetAttribute(hero.Attributes.GetVital("Armor"));
            _lifeWidget.SetAttribute(hero.Attributes.GetVital("Life"));
            _staminaWidget.SetAttribute(hero.Attributes.GetVital("Stamina"));
            _magicWidget.SetAttribute(hero.Attributes.GetVital("Magic"));
            _luckWidget.SetAttribute(hero.Attributes.GetVital("Luck"));
        }
    }
}
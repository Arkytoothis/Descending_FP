using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using UnityEngine;

namespace Descending.Gui
{
    public class HeroCharacteristicsPanel : MonoBehaviour
    {
        [SerializeField] private CharacteristicWidget _mightWidget = null;
        [SerializeField] private CharacteristicWidget _enduranceWidget = null;
        [SerializeField] private CharacteristicWidget _finesseWidget = null;
        [SerializeField] private CharacteristicWidget _intellectWidget = null;
        [SerializeField] private CharacteristicWidget _spiritWidget = null;
        [SerializeField] private CharacteristicWidget _sensesWidget = null;

        public void Setup()
        {
            
        }
        
        public void DisplayHero(Hero hero)
        {
            _mightWidget.SetAttribute(hero.Attributes.GetAttribute("Might"));
            _enduranceWidget.SetAttribute(hero.Attributes.GetAttribute("Endurance"));
            _finesseWidget.SetAttribute(hero.Attributes.GetAttribute("Finesse"));
            _intellectWidget.SetAttribute(hero.Attributes.GetAttribute("Intellect"));
            _spiritWidget.SetAttribute(hero.Attributes.GetAttribute("Spirit"));
            _sensesWidget.SetAttribute(hero.Attributes.GetAttribute("Senses"));
        }
    }
}
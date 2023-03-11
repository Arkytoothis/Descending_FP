using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using UnityEngine;

namespace Descending.Gui
{
    public class HeroVitalsPanel : MonoBehaviour
    {
        [SerializeField] private VitalWidget _actionsWidget = null;
        [SerializeField] private VitalWidget _luckWidget = null;
        [SerializeField] private VitalBar _armorBar = null;
        [SerializeField] private VitalBar _lifeBar = null;
        [SerializeField] private VitalBar _staminaBar = null;
        [SerializeField] private VitalBar _magicBar = null;

        public void Setup()
        {
            
        }
        
        public void DisplayHero(Hero hero)
        {
            _actionsWidget.SetAttribute(hero.Attributes.GetVital("Actions"));
            _luckWidget.SetAttribute(hero.Attributes.GetVital("Luck"));
            
            _armorBar.UpdateData(hero.Attributes.GetVital("Armor").Current, hero.Attributes.GetVital("Armor").Maximum);
            _lifeBar.UpdateData(hero.Attributes.GetVital("Life").Current, hero.Attributes.GetVital("Life").Maximum);
            _staminaBar.UpdateData(hero.Attributes.GetVital("Stamina").Current, hero.Attributes.GetVital("Stamina").Maximum);
            _magicBar.UpdateData(hero.Attributes.GetVital("Magic").Current, hero.Attributes.GetVital("Magic").Maximum);
        }
    }
}
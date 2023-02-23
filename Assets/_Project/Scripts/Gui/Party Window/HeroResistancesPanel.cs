using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using UnityEngine;
using UnityEngine.Serialization;

namespace Descending.Gui
{
    public class HeroResistancesPanel : MonoBehaviour
    {
        [SerializeField] private ResistanceWidget _bluntWidget = null;
        [SerializeField] private ResistanceWidget _pierceWidget = null;
        [SerializeField] private ResistanceWidget _slashWidget = null;
        [SerializeField] private ResistanceWidget _fireWidget = null;
        [SerializeField] private ResistanceWidget _coldWidget = null;
        [SerializeField] private ResistanceWidget _shockWidget = null;
        [SerializeField] private ResistanceWidget _natureWidget = null;
        [SerializeField] private ResistanceWidget _holyWidget = null;
        [SerializeField] private ResistanceWidget _unholyWidget = null;
        [SerializeField] private ResistanceWidget _shadowWidget = null;

        public void Setup()
        {
            
        }
        
        public void DisplayHero(HeroUnit hero)
        {
            _bluntWidget.SetResistance(hero.Attributes.GetResistance("Blunt").CurrentValue, hero.Attributes.GetResistance("Blunt").MaximumValue);
            _pierceWidget.SetResistance(hero.Attributes.GetResistance("Pierce").CurrentValue, hero.Attributes.GetResistance("Pierce").MaximumValue);
            _slashWidget.SetResistance(hero.Attributes.GetResistance("Slash").CurrentValue, hero.Attributes.GetResistance("Slash").MaximumValue);
            _fireWidget.SetResistance(hero.Attributes.GetResistance("Fire").CurrentValue, hero.Attributes.GetResistance("Fire").MaximumValue);
            _coldWidget.SetResistance(hero.Attributes.GetResistance("Cold").CurrentValue, hero.Attributes.GetResistance("Cold").MaximumValue);
            _shockWidget.SetResistance(hero.Attributes.GetResistance("Shock").CurrentValue, hero.Attributes.GetResistance("Shock").MaximumValue);
            _natureWidget.SetResistance(hero.Attributes.GetResistance("Nature").CurrentValue, hero.Attributes.GetResistance("Nature").MaximumValue);
            _holyWidget.SetResistance(hero.Attributes.GetResistance("Holy").CurrentValue, hero.Attributes.GetResistance("Holy").MaximumValue);
            _unholyWidget.SetResistance(hero.Attributes.GetResistance("Unholy").CurrentValue, hero.Attributes.GetResistance("Unholy").MaximumValue);
            _shadowWidget.SetResistance(hero.Attributes.GetResistance("Shadow").CurrentValue, hero.Attributes.GetResistance("Shadow").MaximumValue);
        }
    }
}
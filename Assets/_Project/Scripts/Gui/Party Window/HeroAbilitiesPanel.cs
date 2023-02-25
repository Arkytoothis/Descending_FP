using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Units;
using UnityEngine;
using UnityEngine.UI;

namespace Descending.Gui
{
    public class HeroAbilitiesPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _abilityWidgetPrefab = null;
        [SerializeField] private Transform _powersParent = null;
        [SerializeField] private Transform _spellsParent = null;
        //[SerializeField] private Transform _traitsParent = null;
        
        [SerializeField] private List<AbilityWidget> _powerWidgets = null;
        [SerializeField] private List<AbilityWidget> _spellWidgets = null;
        [SerializeField] private List<AbilityWidget> _traitWidgets = null;

        public void Setup()
        {
            
        }
        
        public void DisplayHero(Hero hero)
        {
            _powersParent.ClearTransform();
            _spellsParent.ClearTransform();
            
            _powerWidgets.Clear();
            _spellWidgets.Clear();
            _traitWidgets.Clear();
            
            for (int i = 0; i < hero.Abilities.MemorizedPowers.Count; i++)
            {
                GameObject clone = Instantiate(_abilityWidgetPrefab, _powersParent);
                AbilityWidget widget = clone.GetComponent<AbilityWidget>();
                widget.SetAbility(hero.Abilities.MemorizedPowers[i]);
                _powerWidgets.Add(widget);
            }
            
            for (int i = 0; i < hero.Abilities.MemorizedSpells.Count; i++)
            {
                GameObject clone = Instantiate(_abilityWidgetPrefab, _spellsParent);
                AbilityWidget widget = clone.GetComponent<AbilityWidget>();
                widget.SetAbility(hero.Abilities.MemorizedSpells[i]);
                _spellWidgets.Add(widget);
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using Descending.Abilities;
using Descending.Units;
using UnityEngine;

namespace Descending.Gui
{
    public class ActionsPanel : MonoBehaviour
    {
        [SerializeField] private List<ActionWidget> _defaultActionBar = null;
        [SerializeField] private List<ActionWidget> _topActionBar = null;
        [SerializeField] private List<ActionWidget> _bottomActionBar = null;

        public void Setup()
        {
            for (int i = 0; i < _topActionBar.Count; i++)
            {
                _topActionBar[i].Setup(i, i.ToString());
            }
            
            for (int i = 0; i < _bottomActionBar.Count; i++)
            {
                _bottomActionBar[i].Setup(i, i.ToString());
            }
        }

        public void OnDisplaySelectedHero(Hero hero)
        {
            Clear();

            for (int i = 0; i < hero.Abilities.MemorizedPowers.Count; i++)
            {
                _topActionBar[i].SetAbility(hero.Abilities.MemorizedPowers[i]);
            }

            for (int i = 0; i < hero.Abilities.MemorizedSpells.Count; i++)
            {
                _bottomActionBar[i].SetAbility(hero.Abilities.MemorizedSpells[i]);
            }
        }

        private void Clear()
        {
            foreach (ActionWidget widget in _topActionBar)
            {
                widget.Clear();
            }

            foreach (ActionWidget widget in _bottomActionBar)
            {
                widget.Clear();
            }
        }
    }
}

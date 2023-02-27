using System.Collections;
using System.Collections.Generic;
using Descending.Abilities;
using Descending.Core;
using Descending.Units;
using UnityEngine;

namespace Descending.Gui
{
    public class ActionsPanel : MonoBehaviour
    {
        //[SerializeField] private List<ActionWidget> _defaultActionBar = null;
        [SerializeField] private List<ActionWidget> _topActionBar = null;
        [SerializeField] private List<ActionWidget> _bottomActionBar = null;
        [SerializeField] private UiModes _mode = UiModes.World;

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

            if (hero == null) return;
            
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

        public void SetMode(UiModes mode)
        {
            _mode = mode;
            // foreach (PartyPanelWidget widget in _widgets)
            // {
            //     if (_mode == UiModes.Combat)
            //     {
            //         widget.SetCanSelect(false);
            //     }
            //     else if (_mode == UiModes.World)
            //     {
            //         widget.SetCanSelect(true);
            //     }
            // }
        }
    }
}

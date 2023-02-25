using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using UnityEngine;

namespace Descending.Gui
{
    public class PartyPanel : MonoBehaviour
    {
        [SerializeField] private List<PartyPanelWidget> _widgets = null;

        public void Setup()
        {
            for (int i = 0; i < _widgets.Count; i++)
            {
                _widgets[i].Setup(this, null, i);
            }
            
            SelectWidget(0);
        }

        public void OnSyncHero(Hero hero)
        {
            _widgets[hero.HeroData.ListIndex].SetHero(hero);
        }

        public void SelectWidget(int index)
        {
            foreach (PartyPanelWidget widget in _widgets)
            {
                widget.Deselect();
            }
            
            _widgets[index].Select();
        }
    }
}

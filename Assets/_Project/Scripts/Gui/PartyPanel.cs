using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Units;
using UnityEngine;

namespace Descending.Gui
{
    
    public class PartyPanel : MonoBehaviour
    {
        [SerializeField] private List<PartyPanelWidget> _widgets = null;
        [SerializeField] private UiModes _mode = UiModes.World;

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
            DeselectAll();
            _widgets[index].Select();
        }

        public void DeselectAll()
        {
            foreach (PartyPanelWidget widget in _widgets)
            {
                widget.Deselect();
            }
        }

        public void OnSelectWidget(int index)
        {
            if (index == -1)
            {
                DeselectAll();
            }
            else
            {
                SelectWidget(index);
            }
        }

        public void SetMode(UiModes mode)
        {
            _mode = mode;
            foreach (PartyPanelWidget widget in _widgets)
            {
                if (_mode == UiModes.Combat)
                {
                    widget.SetCanSelect(false);
                }
                else if (_mode == UiModes.World)
                {
                    widget.SetCanSelect(true);
                }
            }
        }

        public void OnUpdateHeroUnitEffects(int index)
        {
            for (int i = 0; i < _widgets.Count; i++)
            {
                _widgets[i].SyncUnitEffects();
            }
        }

        public void OnDisplayDamageText(HeroDamageText damageText)
        {
            _widgets[damageText.ListIndex].ShowDamage(damageText);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Units;
using TMPro;
using UnityEngine;

namespace Descending.Gui
{
    public class ActionsPanel : MonoBehaviour
    {
        [SerializeField] private UiModes _mode = UiModes.World;
        [SerializeField] private List<ActionWidget> _topActionBar = null;
        [SerializeField] private List<ActionWidget> _bottomActionBar = null;
        [SerializeField] private TMP_Text _actionsLabel = null;
        [SerializeField] private VitalBar _armorBar = null;
        [SerializeField] private VitalBar _lifeBar = null;
        [SerializeField] private VitalBar _staminaBar = null;
        [SerializeField] private VitalBar _magicBar = null;
        [SerializeField] private VitalBar _moraleBar = null;

        private int _selectedHeroIndex = -1;
        
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
            
            _selectedHeroIndex = hero.HeroData.ListIndex;
            
            for (int i = 0; i < hero.Abilities.MemorizedPowers.Count; i++)
            {
                _topActionBar[i].SetAbility(hero.Abilities.MemorizedPowers[i]);
            }

            for (int i = 0; i < hero.Abilities.MemorizedSpells.Count; i++)
            {
                _bottomActionBar[i].SetAbility(hero.Abilities.MemorizedSpells[i]);
            }
            
            _actionsLabel.enabled = true;
            _armorBar.gameObject.SetActive(true);
            _lifeBar.gameObject.SetActive(true);
            _staminaBar.gameObject.SetActive(true);
            _magicBar.gameObject.SetActive(true);
            _moraleBar.gameObject.SetActive(true);
            
            DisplayHeroVitals(hero);
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
            
            _actionsLabel.enabled = false;
            _armorBar.gameObject.SetActive(false);
            _lifeBar.gameObject.SetActive(false);
            _staminaBar.gameObject.SetActive(false);
            _magicBar.gameObject.SetActive(false);
            _moraleBar.gameObject.SetActive(false);
        }

        public void SetMode(UiModes mode)
        {
            _mode = mode;
        }

        public void DisplayHeroVitals(Hero hero)
        {
            if (hero != HeroManager.Instance.SelectedHero) return;
            
            _actionsLabel.SetText("Actions: " + hero.Attributes.GetVital("Actions").Current + "/" + hero.Attributes.GetVital("Actions").Maximum);
            _armorBar.UpdateData(hero.Attributes.GetVital("Armor").Current, hero.Attributes.GetVital("Armor").Maximum);
            _lifeBar.UpdateData(hero.Attributes.GetVital("Life").Current, hero.Attributes.GetVital("Life").Maximum);
            _staminaBar.UpdateData(hero.Attributes.GetVital("Stamina").Current, hero.Attributes.GetVital("Stamina").Maximum);
            _magicBar.UpdateData(hero.Attributes.GetVital("Magic").Current, hero.Attributes.GetVital("Magic").Maximum);
        }
    }
}

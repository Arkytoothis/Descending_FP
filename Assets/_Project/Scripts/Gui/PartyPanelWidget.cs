using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Descending.Gui
{
    public class PartyPanelWidget : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Button _button = null;
        [SerializeField] private TMP_Text _nameLabel = null;
        [SerializeField] private RawImage _portraitImage = null;
        [SerializeField] private Image _selectionBorder = null;
        [SerializeField] private Image _deselectedImage = null;

        [SerializeField] private VitalBar _lifeBar = null;
        [SerializeField] private VitalBar _staminaBar = null;
        [SerializeField] private VitalBar _magicBar = null;
        [SerializeField] private VitalBar _moraleBar = null;
        [SerializeField] private VitalBar _experienceBar = null;

        private PartyPanel _partyPanel = null;
        private Hero _hero = null;
        private int _index = -1;
        private bool _canSelect = true;

        public void Setup(PartyPanel partyPanel, Hero hero, int index)
        {
            _button = GetComponent<Button>();
            _partyPanel = partyPanel;
            _hero = null;
            _index = index;
            Clear();
            _button.interactable = false;
            Deselect();
        }

        public void SetHero(Hero hero)
        {
            _button.interactable = true;
            _hero = hero;
            _nameLabel.SetText(hero.GetFirstName());
            _portraitImage.texture = hero.Portrait.RtClose;
            _portraitImage.color = Color.white;

            _lifeBar.gameObject.SetActive(true);
            _staminaBar.gameObject.SetActive(true);
            _magicBar.gameObject.SetActive(true);
            _moraleBar.gameObject.SetActive(true);
            _experienceBar.gameObject.SetActive(true);
            _lifeBar.UpdateData(hero.Attributes.GetVital("Life").Current, hero.Attributes.GetVital("Life").Maximum);
            _staminaBar.UpdateData(hero.Attributes.GetVital("Stamina").Current, hero.Attributes.GetVital("Stamina").Maximum);
            _magicBar.UpdateData(hero.Attributes.GetVital("Magic").Current, hero.Attributes.GetVital("Magic").Maximum);
            _moraleBar.UpdateData(100, 100);
            _experienceBar.UpdateData(hero.HeroData.Experience, hero.HeroData.ExpToNextLevel);
        }

        public void Clear()
        {
            _nameLabel.SetText("");
            _portraitImage.texture = null;
            _portraitImage.color = new Color(0f, 0f, 0f, 0.5f);

            _lifeBar.gameObject.SetActive(false);
            _staminaBar.gameObject.SetActive(false);
            _magicBar.gameObject.SetActive(false);
            _moraleBar.gameObject.SetActive(false);
            _experienceBar.gameObject.SetActive(false);
        }

        public void Select()
        {
            _selectionBorder.gameObject.SetActive(true);
            _deselectedImage.enabled = false;
            HeroManager.Instance.SelectHero(_hero);
        }

        public void Deselect()
        {
            _selectionBorder.gameObject.SetActive(false);
            _deselectedImage.enabled = true;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_hero == null || _canSelect == false) return;

            _partyPanel.SelectWidget(_index);
        }

        public void SetCanSelect(bool canSelect)
        {
            _canSelect = canSelect;
        }
    }
}
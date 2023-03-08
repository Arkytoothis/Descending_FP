using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Player;
using Descending.Units;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Descending.Gui
{
    public class PartyPanelWidget : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Button _button = null;
        [SerializeField] private TMP_Text _nameLabel = null;
        [SerializeField] private TMP_Text _actionsLabel = null;
        [SerializeField] private RawImage _portraitImage = null;
        [SerializeField] private Image _selectionBorder = null;
        [SerializeField] private Image _deselectedImage = null;

        [SerializeField] private VitalBar _armorBar = null;
        [SerializeField] private VitalBar _lifeBar = null;
        [SerializeField] private VitalBar _staminaBar = null;
        [SerializeField] private VitalBar _magicBar = null;
        [SerializeField] private VitalBar _moraleBar = null;
        [SerializeField] private VitalBar _experienceBar = null;
        
        [SerializeField] private GameObject _unitEffectWidgetPrefab = null;
        [SerializeField] private Transform _unitEffectWidgetsParent = null;
        [SerializeField] private List<UnitEffectWidget> _unitEffectWidgets = null;

        private PartyPanel _partyPanel = null;
        private Hero _hero = null;
        private int _index = -1;
        private bool _canSelect = true;

        public Hero Hero => _hero;

        public void Setup(PartyPanel partyPanel, Hero hero, int index)
        {
            _button = GetComponent<Button>();
            _partyPanel = partyPanel;
            _hero = null;
            _index = index;
            _canSelect = true;
            Clear();
            _button.interactable = false;
            Deselect();
        }

        public void SetHero(Hero hero)
        {
            _button.interactable = true;
            _hero = hero;
            _nameLabel.SetText(hero.GetFirstName());
            _actionsLabel.SetText(hero.Attributes.GetVital("Actions").Current + "/" + hero.Attributes.GetVital("Actions").Maximum);
            _portraitImage.texture = hero.Portrait.RtClose;
            _portraitImage.color = Color.white;

            _armorBar.gameObject.SetActive(true);
            _lifeBar.gameObject.SetActive(true);
            _staminaBar.gameObject.SetActive(true);
            _magicBar.gameObject.SetActive(true);
            _moraleBar.gameObject.SetActive(true);
            _experienceBar.gameObject.SetActive(true);
            _armorBar.UpdateData(hero.Attributes.GetVital("Armor").Current, hero.Attributes.GetVital("Armor").Maximum);
            _lifeBar.UpdateData(hero.Attributes.GetVital("Life").Current, hero.Attributes.GetVital("Life").Maximum);
            _staminaBar.UpdateData(hero.Attributes.GetVital("Stamina").Current, hero.Attributes.GetVital("Stamina").Maximum);
            _magicBar.UpdateData(hero.Attributes.GetVital("Magic").Current, hero.Attributes.GetVital("Magic").Maximum);
            _moraleBar.UpdateData(100, 100);
            _experienceBar.UpdateData(hero.HeroData.Experience, hero.HeroData.ExpToNextLevel);
            
            SyncUnitEffects();
        }

        public void Clear()
        {
            _nameLabel.SetText("");
            _portraitImage.texture = null;
            _portraitImage.color = new Color(0f, 0f, 0f, 0.5f);

            _armorBar.gameObject.SetActive(false);
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
            if (eventData.button != PointerEventData.InputButton.Left) return;
            if (_hero == null || _canSelect == false) return;

            _partyPanel.SelectWidget(_index);
        }

        public void SetCanSelect(bool canSelect)
        {
            _canSelect = canSelect;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            CombatRaycaster.Instance.SetPartyPanelHover(this);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            CombatRaycaster.Instance.ClearPartyPanelWidget();
            _canSelect = true;
        }

        public void SyncUnitEffects()
        {
            _unitEffectWidgetsParent.ClearTransform();
            
            if (_hero == null || _hero.UnitEffects == null) return;
            
            foreach (UnitEffect unitEffect in _hero.UnitEffects.Effects)
            {
                GameObject clone = Instantiate(_unitEffectWidgetPrefab, _unitEffectWidgetsParent);
                UnitEffectWidget widget = clone.GetComponent<UnitEffectWidget>();
                widget.Setup(unitEffect);
                _unitEffectWidgets.Add(widget);
            }
        }

        // public void SyncUnitEffectsDuration()
        // {
        //     if (_hero == null || _hero.UnitEffects == null) return;
        //     
        //     for (int i = 0; i < _hero.UnitEffects.Effects.Count; i++)
        //     {
        //         _unitEffectWidgets[i].SyncDuration();
        //     }
        //
        //     for (int i = _hero.UnitEffects.Effects.Count - 1; i >= 0; i--)
        //     {
        //         if (_hero.UnitEffects.Effects[i].Duration <= 0)
        //         {
        //             _hero.UnitEffects.Effects.RemoveAt(i);
        //         }
        //     }
        // }
    }
}
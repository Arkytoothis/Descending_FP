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
        [SerializeField] private TMP_Text _nameLabel = null;
        [SerializeField] private RawImage _portraitImage = null;
        [SerializeField] private Image _selectionBorder = null;

        private PartyPanel _partyPanel = null;
        private HeroUnit _hero = null;
        private int _index = -1;
        
        public void Setup(PartyPanel partyPanel, HeroUnit hero, int index)
        {
            _partyPanel = partyPanel;
            _hero = null;
            _index = index;
            Clear();
            Deselect();
        }

        public void SetHero(HeroUnit hero)
        {
            _hero = hero;
            _nameLabel.SetText(hero.GetFirstName());
            _portraitImage.texture = hero.Portrait.RtClose;
            _portraitImage.color = Color.white;
        }

        public void Clear()
        {
            _nameLabel.SetText("");
            _portraitImage.texture = null;
            _portraitImage.color = new Color(0f, 0f, 0f, 0.5f);
        }

        public void Select()
        {
            _selectionBorder.gameObject.SetActive(true);
            HeroManager.Instance.SelectHero(_hero);
        }

        public void Deselect()
        {
            _selectionBorder.gameObject.SetActive(false);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_hero == null) return;
            
            _partyPanel.SelectWidget(_index);
        }
    }
}

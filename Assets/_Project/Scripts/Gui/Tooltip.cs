using System.Collections;
using System.Collections.Generic;
using Descending.Abilities;
using UnityEngine;
using TMPro;
using Descending.Equipment;
using UnityEngine.UI;
using Descending.Core;

namespace Descending.Gui
{
    public class Tooltip : MonoBehaviour
    {
        [SerializeField] private GameObject _container = null;
        //[SerializeField] private CanvasGroup _canvasGroup = null;
        //[SerializeField] private RectTransform _rect = null;
        [SerializeField] private Image _icon = null;
        [SerializeField] private TMP_Text _title = null;
        [SerializeField] private TMP_Text _description = null;
        [SerializeField] private TMP_Text _details = null;
        [SerializeField] private Image _encumbranceIcon = null;
        [SerializeField] private Image _goldIcon = null;
        [SerializeField] private Image _gemsIcon = null;
        [SerializeField] private TMP_Text _encumbranceLabel = null;
        [SerializeField] private TMP_Text _goldLabel = null;
        [SerializeField] private TMP_Text _gemsLabel = null;
        [SerializeField] private GameObject _header = null;
        //[SerializeField] private float _openDelay = 0.15f;
        //[SerializeField] private float _openSpeed = 0.1f;
        //[SerializeField] private float _closeSpeed = 0.1f;

        //[SerializeField] private Vector3 _offset = Vector3.zero;
        //[SerializeField] private float _padding = 25f;
        
        //private bool _isShown = false;

        private void Start()
        {
            Hide();
        }

        public void Setup()
        {
            
        }
        
        //private void Update()
        //{
        //    FollowCursor();
        //}

        //private void FollowCursor()
        //{
        //    if (_isShown == true) return;

        //    Vector3 newPos = Input.mousePosition + _offset;
        //    newPos.z = 0f;

        //    float rightEdgeToScreenEdgeDistance = Screen.width - (newPos.x + _rect.rect.width * _canvas.scaleFactor / 2) - _padding;

        //    if (rightEdgeToScreenEdgeDistance < 0)
        //    {
        //        newPos.x += rightEdgeToScreenEdgeDistance;
        //    }

        //    float leftEdgeToScreenEdgeDistance = 0 - (newPos.x - _rect.rect.width * _canvas.scaleFactor / 2) + _padding;

        //    if (leftEdgeToScreenEdgeDistance > 0)
        //    {
        //        newPos.x += leftEdgeToScreenEdgeDistance;
        //    }

        //    float topEdgeToScreenEdgeDistance = Screen.height - (newPos.y + _rect.rect.height * _canvas.scaleFactor) - _padding;

        //    if (topEdgeToScreenEdgeDistance < 0)
        //    {
        //        newPos.y += topEdgeToScreenEdgeDistance;
        //    }

        //    _rect.transform.position = newPos;
        //}

        public void Clear()
        {
            _icon.sprite = Database.instance.BlankSprite;
            _title.text = "";
            _description.text = "";
            _details.text = "";
        }

        private Color GetTitleColor(Item item)
        {
            RarityDefinition rarity = Database.instance.Rarities.GetRarity(item.RarityKey);
            return Database.instance.Rarities.GetRarity(rarity.Order).Color;
        }

        private Color GetTitleColor(Ability ability)
        {
            return new Color(1f, 1f, 1f, 1f);
        }

        public void DisplayItem(Item item)
        {
            if (item != null && item.Key != "")
            {
                SetupFull();
                _icon.sprite = item.Icon;
                _title.text = item.DisplayName();
                _title.color = GetTitleColor(item);
                _description.text = item.ItemDefinition.Name + " Description - ";  
                _details.text = item.GetTooltipText();

                _encumbranceIcon.enabled = true;
                _encumbranceLabel.enabled = true;
                _encumbranceLabel.text = item.Encumbrance.ToString();
                _goldIcon.enabled = true;
                _goldLabel.enabled = true;
                _goldLabel.text = item.GoldValue.ToString();
                _gemsIcon.enabled = true;
                _gemsLabel.enabled = true;
                _gemsLabel.text = item.GemValue.ToString();

                Show();
            }
            else
            {
                Hide();
            }
        }

        public void DisplayAbility(Ability ability)
        {
            if (ability != null && ability.IsEmpty == false)
            {
                SetupFull();
                _icon.sprite = ability.Definition.Icon;
                _title.text = ability.DisplayName();
                _title.color = GetTitleColor(ability);
                _description.text = ability.Definition.Description;  
                _details.text = ability.GetTooltipText();
        
                _encumbranceIcon.enabled = false;
                _encumbranceLabel.enabled = false;
                _encumbranceLabel.text = "";
                _goldIcon.enabled = false;
                _goldLabel.enabled = false;
                _goldLabel.text = "";
                _gemsIcon.enabled = false;
                _gemsLabel.enabled = false;
                _gemsLabel.text = "";
        
                Show();
            }
            else
            {
                Hide();
            }
        }

        // public void SetData(PlayerController pc)
        // {
        //     if (pc != null)
        //     {
        //         SetupFull();
        //
        //         _icon.sprite = null;
        //         _title.text = pc.PlayerData.Name.FullName;
        //         _title.color = Color.white;
        //         //ProfessionDefinition definition = Database.instance.Professions.GetProfession(pc.Details.Profession);
        //         _description.text = "Level " + pc.PlayerData.Level + " " + pc.PlayerData.Gender + " " + pc.PlayerData.RaceKey;
        //         //_details.text = pc.GetTooltipText();
        //
        //         _encumbranceIcon.enabled = false;
        //         _encumbranceLabel.enabled = false;
        //         _encumbranceLabel.text = "";
        //         _goldIcon.enabled = false;
        //         _goldLabel.enabled = false;
        //         _goldLabel.text = "";
        //         _gemsIcon.enabled = false;
        //         _gemsLabel.enabled = false;
        //         _gemsLabel.text = "";
        //
        //         Show();
        //     }
        //     else
        //     {
        //         Hide();
        //     }
        // }

        // public void SetData(Npc npc)
        // {
        //     if (npc != null)
        //     {
        //         SetupFull();
        //
        //         _icon.sprite = null;
        //         _icon.enabled = false;
        //         _title.text = npc.Name.FullName;
        //         _title.color = Color.white;
        //
        //         _details.text = "Level " + npc.Level + " " + npc.Gender + " " + npc.Race + " " + npc.Profession;
        //         _encumbranceIcon.enabled = false;
        //         _encumbranceLabel.enabled = false;
        //         _encumbranceLabel.text = "";
        //         _goldIcon.enabled = false;
        //         _goldLabel.enabled = false;
        //         _goldLabel.text = "";
        //         _gemsIcon.enabled = false;
        //         _gemsLabel.enabled = false;
        //         _gemsLabel.text = "";
        //
        //         Show();
        //     }
        //     else
        //     {
        //         Hide();
        //     }
        // }

        private void SetupSimple()
        {
            HideHeader();
            _description.gameObject.SetActive(false);
            //experienceBar.Hide();
        }

        private void SetupFull()
        {
            ShowHeader();
            _description.gameObject.SetActive(true);
        }

        private void Show()
        {
            //_isShown = true;
            //Invoke("DelayedOpen", _openDelay);
            _container.SetActive(true);
        }

        // public void DelayedOpen()
        // {
        //     //_isShown = true;
        //     LayoutRebuilder.ForceRebuildLayoutImmediate(_rect);
        //     //_canvasGroup.DOFade(1f, _openSpeed);
        // }

        public void Hide()
        {
            //_isShown = false;
            //CancelInvoke("DelayedOpen");
            //_canvasGroup.DOFade(0f, _closeSpeed);
            _container.SetActive(false);
        }

        // public void Close()
        // {
        //     //_isShown = false;
        //     CancelInvoke("DelayedOpen");
        //     //_canvasGroup.DOFade(0f, 0f);
        // }

        public void ShowHeader()
        {
            _header.SetActive(true);
        }

        public void HideHeader()
        {
            _header.SetActive(false);
        }
    }
}
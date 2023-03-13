using System.Collections;
using System.Collections.Generic;
using Descending.Abilities;
using Descending.Core;
using Descending.Gui;
using Descending.Interactables;
using Descending.Units;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Descending.Player
{
    public class WorldRaycaster : MonoBehaviour
    {
        [SerializeField] private Texture2D _interactCursor = null;
        [SerializeField] private Sprite _interactSprite = null;
        [SerializeField] private Texture2D _guiCursor = null;
        [SerializeField] private Sprite _crosshairSprite = null;
        [SerializeField] private Image _crosshair = null;
        [SerializeField] private float _interactDistance = 1f;

        private Camera _camera = null;
        private bool _raycastingEnabled = true;
        private PartyPanelWidget _partyPanelWidget = null;
        private Ability _currentAbility = null;
        
        private void Start()
        {
            _camera = Camera.main;
        }

        void Update()
        {
            if (Utilities.IsMouseInWindow() == false)
            {
                SetCursor(null, _crosshairSprite);
                return;
            }
            
            if (EventSystem.current.IsPointerOverGameObject())
            {
                SetCursor(_guiCursor, _crosshairSprite);
                return;
            }
            
            if (_partyPanelWidget != null)
            {
                    SetCursor(_guiCursor, _crosshairSprite);
                    
                    if (Input.GetMouseButtonUp(0))
                    {
                        ProcessClick(_partyPanelWidget.Hero);
                    }
                
                return;
            }
            
            if (_raycastingEnabled == true)
            {
                PerformRaycasts();
            }
        }

        void PerformRaycasts()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (RaycastForInteractable(ray) == true) { return; }

            SetCursor(_guiCursor, _crosshairSprite);
        }

        bool RaycastForInteractable(Ray ray)
        {
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _interactDistance))
            {
                IInteractable interactable = hit.collider.gameObject.GetComponent<IInteractable>();
                
                if(interactable != null)
                {
                    SetCursor(_interactCursor, _interactSprite);

                    if (Input.GetMouseButtonUp(0) || Input.GetKeyDown(KeyCode.F))
                    {
                        interactable.Interact(HeroManager.Instance.SelectedHero);
                    }

                    return true;
                }
            }

            return false;
        }

        private void SetCursor(Texture2D cursor, Sprite crosshair)
        {
            Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
            _crosshair.sprite = crosshair;
        }

        public void SetInitiativeWidgetHover(PartyPanelWidget widget)
        {
            _partyPanelWidget = widget;
        }

        public void ClearInitiativeWidget()
        {
            _partyPanelWidget = null;
        }
        
        private void ProcessClick(Hero heroTarget)
        {
            //int actionsRequired = 0;
            
            // if (_targetingMode == TargetingModes.Melee || _targetingMode == TargetingModes.Ranged)
            // {
            //     EncounterManager.Instance.ProcessAttack(HeroManager.Instance.SelectedHero, enemyTarget);
            // }
            // else if (_targetingMode == TargetingModes.Ability)
            // {
            //     //Debug.Log("Using " + _currentAbility.DisplayName() + " on " + enemyTarget.GetFullName());
            //     _currentAbility.Use(HeroManager.Instance.SelectedHero, new List<Unit> { enemyTarget });
            // }
        }
        
        public void OnTargetAbility(Ability ability)
        {
            //Debug.Log("Targeting: " + ability.DisplayName());
            //_targetingMode = TargetingModes.Ability;
            _currentAbility = ability;
            //_currentItem = null;
            //_currentWeapon = null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Descending.Abilities;
using Descending.Core;
using Descending.Encounters;
using Descending.Equipment;
using Descending.Gui;
using Descending.Interactables;
using Descending.Units;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Descending.Player
{
    public enum TargetingModes { Melee, Ranged, Ability, Item, Number, None }
    
    public class CombatRaycaster : MonoBehaviour
    {
        public static CombatRaycaster Instance { get; private set; }
        
        [SerializeField] private TargetingModes _targetingMode = TargetingModes.None;
        [SerializeField] private Texture2D _meleeCursor = null;
        [SerializeField] private Texture2D _rangedCursor = null;
        [SerializeField] private Texture2D _abilityCursor = null;
        [SerializeField] private Texture2D _guiCursor = null;
        [SerializeField] private Sprite _crosshairSprite = null;
        [SerializeField] private Texture2D _interactCursor = null;
        [SerializeField] private Sprite _interactSprite = null;
        [SerializeField] private Image _crosshair = null;
        [SerializeField] private float _interactDistance = 1f;
        [SerializeField] private float _enemyRaycastDistance = 1f;

        private Camera _camera = null;
        private bool _raycastingEnabled = true;
        private bool _raycastForEnemy = false;
        private InitiativeWidget _initiativeWidgetHovering = null;
        [SerializeField] private PartyPanelWidget _partyWidgetHovering = null;
        [SerializeField] private Ability _currentAbility = null;
        private Item _currentItem = null;
        private Item _currentWeapon = null;
        
        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("Multiple EncounterManagers " + transform + " - " + Instance);
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
            _camera = Camera.main;
            SetTargetingMode(TargetingModes.Melee);
        }

        void Update()
        {
            if (Utilities.IsMouseInWindow() == false)
            {
                SetCursor(null, _crosshairSprite);
                return;
            }

            if (_currentAbility != null && Input.GetMouseButtonDown(1))
            {
                _currentAbility = null;
                SetTargetingMode(TargetingModes.Melee);
                SetCursor(_guiCursor, _crosshairSprite);
                return;
            }
            
            if (CheckForInitiativeWidgetHover()) return;
            if (CheckForPartyWidgetHover()) return;
            
            if (EventSystem.current.IsPointerOverGameObject())
            {
                SetCursor(_guiCursor, _crosshairSprite);
                
                return;
            }
            
            if (_raycastingEnabled == true)
            {
                PerformRaycasts();
            }
        }

        private bool CheckForInitiativeWidgetHover()
        {
            if (_initiativeWidgetHovering != null)
            {
                if (_initiativeWidgetHovering.GetType() == typeof(HeroInitiativeWidget))
                {
                    SetCursor(_guiCursor, _crosshairSprite);

                    if (Input.GetMouseButtonUp(0))
                    {
                        ProcessClick(((HeroInitiativeWidget)_initiativeWidgetHovering).Hero);
                    }
                }
                else if (_initiativeWidgetHovering.GetType() == typeof(EnemyInitiativeWidget))
                {
                    SetCursor(_interactSprite);

                    if (Input.GetMouseButtonUp(0))
                    {
                        ProcessClick(((EnemyInitiativeWidget)_initiativeWidgetHovering).Enemy);
                    }
                }

                return true;
            }

            return false;
        }

        private bool CheckForPartyWidgetHover()
        {
            if (_partyWidgetHovering != null)
            {
                Cursor.SetCursor(_abilityCursor, Vector2.zero, CursorMode.Auto);

                if (Input.GetMouseButtonUp(0))
                {
                    ProcessClick(_partyWidgetHovering.Hero);
                    _partyWidgetHovering.SetCanSelect(true);
                    
                    _currentAbility = null;
                    SetTargetingMode(TargetingModes.Melee);
                    SetCursor(_guiCursor, _crosshairSprite);
                }

                return true;
            }

            return false;
        }

        public void SetTargetingMode(TargetingModes mode)
        {
            _targetingMode = mode;
        }
        
        void PerformRaycasts()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (RaycastForEnemy(ray) == true) { return; }
            if (RaycastForInteractable(ray) == true) { return; }

            SetCursor(_guiCursor, _crosshairSprite);
        }

        bool RaycastForEnemy(Ray ray)
        {
            if (_raycastForEnemy == false) return false;
            
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, _enemyRaycastDistance))
            {
                Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();
                
                if(enemy != null)
                {
                    SetCursor(_interactSprite);
                    
                    if (Input.GetMouseButtonUp(0))
                    {
                        ProcessClick(enemy);
                    }
                    
                    return true;
                }
            }
        
            return false;
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

        private void ProcessClick(Enemy enemyTarget)
        {
            int actionsRequired = 0;
            
            if (_targetingMode == TargetingModes.Melee || _targetingMode == TargetingModes.Ranged)
            {
                EncounterManager.Instance.ProcessAttack(HeroManager.Instance.SelectedHero, enemyTarget);
            }
            else if (_targetingMode == TargetingModes.Ability)
            {
                //Debug.Log("Using " + _currentAbility.DisplayName() + " on " + enemyTarget.GetFullName());
                _currentAbility.Use(HeroManager.Instance.SelectedHero, new List<Unit> { enemyTarget });
            }
        }

        private void ProcessClick(Hero heroTarget)
        {
            if (_targetingMode == TargetingModes.Ability)
            {
                //Debug.Log("Using " + _currentAbility.DisplayName() + " on " + heroTarget.GetFullName());
                _currentAbility.Use(HeroManager.Instance.SelectedHero, new List<Unit> { heroTarget });
            }
        }

        private void SetCursor(Texture2D cursor, Sprite crosshair)
        {
            Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
            _crosshair.sprite = crosshair;
        }

        private void SetCursor(Sprite crosshair)
        {
            if (_targetingMode == TargetingModes.Melee || _targetingMode == TargetingModes.Ranged)
            {
                if (HeroManager.Instance.SelectedHero.CombatMode == HeroCombatModes.Melee)
                {
                    _targetingMode = TargetingModes.Melee;
                    Cursor.SetCursor(_meleeCursor, Vector2.zero, CursorMode.Auto);
                }
                else if (HeroManager.Instance.SelectedHero.CombatMode == HeroCombatModes.Ranged)
                {
                    _targetingMode = TargetingModes.Ranged;
                    Cursor.SetCursor(_rangedCursor, Vector2.zero, CursorMode.Auto);
                }
            }
            else if (_targetingMode == TargetingModes.Ability)
            {
                Cursor.SetCursor(_abilityCursor, Vector2.zero, CursorMode.Auto);
            }
            
            _crosshair.sprite = crosshair;
        }

        public void SetCanRaycastForEnemy(bool raycastForEnemy)
        {
            _raycastForEnemy = raycastForEnemy;
        }

        public void SetInitiativeWidgetHover(HeroInitiativeWidget widget)
        {
            _initiativeWidgetHovering = widget;
        }

        public void SetInitiativeWidgetHover(EnemyInitiativeWidget widget)
        {
            _initiativeWidgetHovering = widget;
        }

        public void SetPartyPanelHover(PartyPanelWidget widget)
        {
            if (_currentAbility == null || _currentAbility.IsEmpty)
            {
                ClearPartyPanelWidget();
                return;
            }
            
            _partyWidgetHovering = widget;
            _partyWidgetHovering.SetCanSelect(false);
        }

        public void ClearInitiativeWidget()
        {
            _initiativeWidgetHovering = null;
        }

        public void ClearPartyPanelWidget()
        {
            _partyWidgetHovering = null;
        }

        public void OnTargetAbility(Ability ability)
        {
            //Debug.Log("Targeting: " + ability.DisplayName());
            _targetingMode = TargetingModes.Ability;
            _currentAbility = ability;
            _currentItem = null;
            _currentWeapon = null;
        }

        public void OnTargetItem(Item item)
        {
            Debug.Log("Targeting: " + item.DisplayName());
            _targetingMode = TargetingModes.Item;
            _currentItem = item;
            _currentAbility = null;
            _currentWeapon = null;
        }

        public void OnTargetMelee(Item weapon)
        {
            _targetingMode = TargetingModes.Melee;
            _currentWeapon = weapon;
            _currentAbility = null;
            _currentItem = null;
        }

        public void OnTargetRanged(Item weapon)
        {
            _targetingMode = TargetingModes.Ranged;
            _currentWeapon = weapon;
            _currentAbility = null;
            _currentItem = null;
        }
    }
}

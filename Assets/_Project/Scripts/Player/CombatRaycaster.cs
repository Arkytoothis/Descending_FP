using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Encounters;
using Descending.Gui;
using Descending.Units;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Descending.Player
{
    public class CombatRaycaster : MonoBehaviour
    {
        public static CombatRaycaster Instance { get; private set; }
        
        [SerializeField] private Texture2D _meleeCursor = null;
        [SerializeField] private Texture2D _guiCursor = null;
        [SerializeField] private Sprite _crosshairSprite = null;
        [SerializeField] private Sprite _interactSprite = null;
        [SerializeField] private Image _crosshair = null;
        [SerializeField] private float _interactDistance = 1f;

        private Camera _camera = null;
        private bool _raycastingEnabled = true;
        private bool _raycastForEnemy = false;
        private InitiativeWidget _widgetHovering = null;
        
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
        }

        void Update()
        {
            if (Utilities.IsMouseInWindow() == false)
            {
                SetCursor(null, _crosshairSprite);
                return;
            }
            
            if (_widgetHovering != null)
            {
                if (_widgetHovering.GetType() == typeof(HeroInitiativeWidget))
                {
                    SetCursor(_guiCursor, _crosshairSprite);
                }
                else if (_widgetHovering.GetType() == typeof(EnemyInitiativeWidget))
                {
                    SetCursor(_meleeCursor, _crosshairSprite);

                    if (Input.GetMouseButtonUp(0))
                    {
                        EncounterManager.Instance.ProcessAttack(HeroManager.Instance.SelectedHero, ((EnemyInitiativeWidget)_widgetHovering).Enemy);
                    }
                }
                
                return;
            }
            
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

        void PerformRaycasts()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (RaycastForEnemy(ray) == true) { return; }

            SetCursor(_guiCursor, _crosshairSprite);
        }

        bool RaycastForEnemy(Ray ray)
        {
            if (_raycastForEnemy == false) return false;
            
            RaycastHit hit;
        
            if (Physics.Raycast(ray, out hit, _interactDistance))
            {
                Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();
                
                if(enemy != null)
                {
                    SetCursor(_meleeCursor, _interactSprite);
        
                    if (Input.GetMouseButtonUp(0))
                    {
                        EncounterManager.Instance.ProcessAttack(HeroManager.Instance.SelectedHero, enemy);
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

        public void SetCanRaycastForEnemy(bool raycastForEnemy)
        {
            _raycastForEnemy = raycastForEnemy;
        }

        public void SetInitiativeWidgetHover(HeroInitiativeWidget widget)
        {
            _widgetHovering = widget;
        }

        public void SetInitiativeWidgetHover(EnemyInitiativeWidget widget)
        {
            _widgetHovering = widget;
        }

        public void ClearInitiativeWidget()
        {
            _widgetHovering = null;
        }
    }
}

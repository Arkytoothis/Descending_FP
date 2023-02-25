using System.Collections;
using System.Collections.Generic;
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
        [SerializeField] private Texture2D _guiCursor = null;
        [SerializeField] private Sprite _crosshairSprite = null;
        [SerializeField] private Sprite _interactSprite = null;
        [SerializeField] private Image _crosshair = null;
        [SerializeField] private float _interactDistance = 1f;

        private Camera _camera = null;
        private bool _raycastingEnabled = true;

        private void Start()
        {
            _camera = Camera.main;
        }

        void Update()
        {
            if (_raycastingEnabled == true)
            {
                PerformRaycasts();
            }
        }

        void PerformRaycasts()
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                SetCursur(_guiCursor, _crosshairSprite);
                
                return;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (RaycastForInteractable(ray) == true) { return; }

            SetCursur(_guiCursor, _crosshairSprite);
        }

        bool RaycastForInteractable(Ray ray)
        {
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _interactDistance))
            {
                IInteractable interactable = hit.collider.gameObject.GetComponent<IInteractable>();
                
                if(interactable != null)
                {
                    SetCursur(_interactCursor, _interactSprite);

                    if (Input.GetMouseButtonUp(0) || Input.GetKeyDown(KeyCode.F))
                    {
                        interactable.Interact(HeroManager.Instance.SelectedHero);
                    }

                    return true;
                }
            }

            return false;
        }

        private void SetCursur(Texture2D cursor, Sprite crosshair)
        {
            Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
            _crosshair.sprite = crosshair;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Encounters;
using StarterAssets;
using UnityEngine;

namespace Descending.Player
{
    public enum PlayerControllerModes { Look, Gui, Combat }
    public enum PlayerRaycastModes { World, Combat }
    
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private FirstPersonController _firstPersonController = null;
        [SerializeField] private PlayerControllerModes _mode = PlayerControllerModes.Look;
        [SerializeField] private GameObject _crossHair = null;
        [SerializeField] private WorldRaycaster _worldRaycaster = null;
        [SerializeField] private CombatRaycaster _combatRaycaster = null;
        //[SerializeField] private PlayerRaycastModes _raycastMode = PlayerRaycastModes.World;

        private bool _inCombat = false;

        private void Start()
        {
            SetWorldRaycastMode();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                if (_mode == PlayerControllerModes.Look)
                {
                    SetGuiMode();
                }
                else if (_mode == PlayerControllerModes.Gui)
                {
                    SetLookMode();
                }
            }
        }

        public void SetLookMode()
        {
            _mode = PlayerControllerModes.Look;
            
            if(_inCombat == false)
                _firstPersonController.SetMovementEnabled(true);
            
            _firstPersonController.SetLookEnabled(true);
            _firstPersonController.SetJumpEnabled(true);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            _crossHair.SetActive(true);
        }

        public void SetGuiMode()
        {
            _mode = PlayerControllerModes.Gui;
            _firstPersonController.SetMovementEnabled(false);
            _firstPersonController.SetLookEnabled(false);
            _firstPersonController.SetJumpEnabled(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            _crossHair.SetActive(false);
        }
        
        public void SetWorldRaycastMode()
        {
            _worldRaycaster.gameObject.SetActive(true);
            _combatRaycaster.gameObject.SetActive(false);
        }

        public void SetCombatRaycastMode()
        {
            _combatRaycaster.gameObject.SetActive(true);
            _worldRaycaster.gameObject.SetActive(false);
        }

        public void OnEnabledLookMode(bool lookEnabled)
        {
            if (lookEnabled == true)
            {
                SetLookMode();
            }
            else
            {
                SetGuiMode();
            }
        }

        public void EncounterTriggered(Encounter encounter)
        {
            SetGuiMode();
        }

        public void SetInCombat(bool inCombat)
        {
            _inCombat = inCombat;
        }

        public void SetMovementEnabled(bool movementEnabled)
        {
            _firstPersonController.SetMovementEnabled(movementEnabled);
        }
    }
}

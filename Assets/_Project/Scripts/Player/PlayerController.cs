using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

namespace Descending.Player
{
    public enum PlayerControllerModes { Look, Gui }
    public enum PlayerRaycastModes { World, Combat }
    
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private FirstPersonController _firstPersonController = null;
        [SerializeField] private PlayerControllerModes _mode = PlayerControllerModes.Look;
        [SerializeField] private GameObject _crossHair = null;
        [SerializeField] private WorldRaycaster _worldRaycaster = null;
        [SerializeField] private CombatRaycaster _combatRaycaster = null;
        [SerializeField] private PlayerRaycastModes _raycastMode = PlayerRaycastModes.World;

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

        private void SetLookMode()
        {
            _mode = PlayerControllerModes.Look;
            _firstPersonController.SetMovementEnabled(true);
            _firstPersonController.SetLookEnabled(true);
            _firstPersonController.SetJumpEnabled(true);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            _crossHair.SetActive(true);
        }

        private void SetGuiMode()
        {
            _mode = PlayerControllerModes.Gui;
            _firstPersonController.SetMovementEnabled(false);
            _firstPersonController.SetLookEnabled(false);
            _firstPersonController.SetJumpEnabled(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            _crossHair.SetActive(false);
        }

        private void SetWorldRaycastMode()
        {
            _worldRaycaster.gameObject.SetActive(true);
            _combatRaycaster.gameObject.SetActive(false);
        }

        private void SetCombatRaycastMode()
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
    }
}

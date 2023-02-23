using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Core
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance { get; private set; }
        
        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("Multiple GridRenderers " + transform + " - " + Instance);
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
        }

        public void Setup()
        {
            
        }
        
        public Vector2 GetMousePosition()
        {
            return Input.mousePosition;
        }

        public bool GetLeftMouseDown()
        {
            return Input.GetMouseButtonDown(0);
        }

        public bool GetRightMouseDown()
        {
            return Input.GetMouseButtonDown(1);
        }

        public bool GetMiddleMouseDown()
        {
            return Input.GetMouseButtonDown(2);
        }

        public Vector2 GetCameraMoveVector()
        {
            Vector2 inputMoveDirection = new Vector2(0, 0);
            if (Input.GetKey(KeyCode.W))
            {
                inputMoveDirection.y = 1f;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                inputMoveDirection.y = -1f;
            }

            if (Input.GetKey(KeyCode.A))
            {
                inputMoveDirection.x = -1f;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                inputMoveDirection.x = 1f;
            }

            return inputMoveDirection;
        }

        public float GetCameraRotation()
        {
            float rotateAmount = 0f;
            
            if (Input.GetKey(KeyCode.Q))
            {
                rotateAmount = -1f;
            }
            else if (Input.GetKey(KeyCode.E))
            {
                rotateAmount = 1f;
            }

            return rotateAmount;
        }

        public float GetCameraZoom()
        {
            float zoomAmount = 0f;
            if (Input.mouseScrollDelta.y > 0)
            {
                zoomAmount = -1f;
            }
            else if (Input.mouseScrollDelta.y < 0)
            {
                zoomAmount = 1f;
            }

            return zoomAmount;
        }
    }
}
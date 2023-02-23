using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace Descending.Core
{
    public class WorldCameraController : MonoBehaviour
    {
        [SerializeField] private float _minFollowYOffset = 2f;
        [SerializeField] private float _maxFollowYOffset = 12f;
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _rotationSpeed = 5f;
        [SerializeField] private float _zoomSpeed = 5f;
        [SerializeField] private float _zoomAmount = 5f;
        [SerializeField] private CinemachineVirtualCamera _vCamera = null;

        private CinemachineTransposer _transposer = null;
        private Vector3 _targetFollowOffset = Vector3.zero;
        
        private void Awake()
        {
            _transposer = _vCamera.GetCinemachineComponent<CinemachineTransposer>();
            _targetFollowOffset = _transposer.m_FollowOffset;
        }

        private void Update()
        {
            Move();
            Rotate();
            Zoom();
        }

        private void Move()
        {
            Vector3 inputMoveDirection = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
            {
                inputMoveDirection.z = 1f;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                inputMoveDirection.z = -1f;
            }

            if (Input.GetKey(KeyCode.A))
            {
                inputMoveDirection.x = -1f;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                inputMoveDirection.x = 1f;
            }

            Vector3 moveVector = transform.forward * inputMoveDirection.z + transform.right * inputMoveDirection.x;
            transform.position += moveVector * (_moveSpeed * Time.deltaTime);
        }

        private void Rotate()
        {
            Vector3 rotationVector = Vector3.zero;

            if (Input.GetKey(KeyCode.Q))
            {
                rotationVector.y = -1f;
            }
            else if (Input.GetKey(KeyCode.E))
            {
                rotationVector.y = 1f;
            }

            transform.eulerAngles += rotationVector * (_rotationSpeed * Time.deltaTime);
        }

        private void Zoom()
        {
            if (Input.mouseScrollDelta.y > 0)
            {
                _targetFollowOffset.y -= _zoomAmount;
            }
            else if (Input.mouseScrollDelta.y < 0)
            {
                _targetFollowOffset.y += _zoomAmount;
            }

            _targetFollowOffset.y = Mathf.Clamp(_targetFollowOffset.y, _minFollowYOffset, _maxFollowYOffset);
            //_transposer.m_FollowOffset += _targetFollowOffset * (Time.deltaTime * _zoomSpeed);
            _transposer.m_FollowOffset = Vector3.Lerp(_transposer.m_FollowOffset, _targetFollowOffset, Time.deltaTime * _zoomSpeed);
        }
    }
}

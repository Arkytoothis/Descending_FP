using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descension.Core
{
    public class PlaceOnGround : MonoBehaviour
    {
        [SerializeField] private bool _placeOnStart = false;
        [SerializeField] private float _yOffset = 0f;
        [SerializeField] private LayerMask _groundMask = new LayerMask();

        public float YOffset { get => _yOffset; set => _yOffset = value; }

        private void Start()
        {
            if (_placeOnStart == true)
            {
                Place();
            }
        }

        public void Place()
        {
            Ray ray = new Ray(transform.position + new Vector3(0f, 100f, 0f), Vector3.down);

            if (Physics.Raycast(ray, out RaycastHit hit, 1000f, _groundMask))
            {
                transform.position = new Vector3(transform.position.x, hit.point.y - _yOffset, transform.position.z);
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace Descending.Core
{
    public class KeepOnGround : MonoBehaviour
    {
        [SerializeField] private float _yOffset = 0f;
        [SerializeField] private LayerMask _groundMask = new LayerMask();

        public float YOffset { get => _yOffset; set => _yOffset = value; }

        private void Update()
        {
            Place();
        }

        public void Place()
        {
            Ray ray = new Ray(new Vector3(transform.position.x, transform.position.y + 50f, transform.position.z), Vector3.down);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, _groundMask))
            {
                transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
            }
        }
    }
}
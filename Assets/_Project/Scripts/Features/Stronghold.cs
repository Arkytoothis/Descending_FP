using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Features
{
    public class Stronghold : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Stronghold Triggered");
            }
        }
    }
}
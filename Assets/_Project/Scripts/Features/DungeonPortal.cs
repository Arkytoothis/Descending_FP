using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Descending.Features
{
    public class DungeonPortal : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Loading Dungeon");
                SceneManager.LoadScene((int)GameScenes.Underground);
            }
        }
    }
}

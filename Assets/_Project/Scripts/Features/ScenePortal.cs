using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Descending.Features
{
    public class ScenePortal : MonoBehaviour
    {
        [SerializeField] private GameScenes _sceneToLoad = GameScenes.None;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Loading " + _sceneToLoad);
                SaveManager.Instance.SaveState();
                SceneManager.LoadScene((int)_sceneToLoad);
            }
        }
    }
}

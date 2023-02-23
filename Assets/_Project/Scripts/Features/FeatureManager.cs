using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Features
{
    public class FeatureManager : MonoBehaviour
    {
        [SerializeField] private List<FeatureSpawner> _featureSpawners = null;
        [SerializeField] private float _minY = 32.64f;
        [SerializeField] private GameObject _playerObject = null;
        
        public void Setup()
        {
            _featureSpawners = new List<FeatureSpawner>();
        }

        public void RegisterFeature(GameObject featureObject)
        {
            FeatureSpawner featureSpawner = featureObject.GetComponent<FeatureSpawner>();
            
            if (featureSpawner == null || _featureSpawners.Contains(featureSpawner)) return;
            
            //Debug.Log("Registering Feature: " + feature);
            _featureSpawners.Add(featureSpawner);
            featureSpawner.Setup();
        }

        public void ProcessFeatureSpawners(GameObject playerObject)
        {
            Debug.Log("Processing " + _featureSpawners.Count + " Feature Spawners");
            //_featureSpawners.Sort((o, o1) => o.transform.position.y.CompareTo(o1.transform.position.y));
            
            _playerObject.transform.position = _featureSpawners[0].transform.position;
            //playerObject.SetActive(true);
        }
    }
}
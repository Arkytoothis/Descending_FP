using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using UnityEngine;

namespace Descending.Features
{
    public class FeaturePlacer : MonoBehaviour
    {
        [SerializeField] private Transform _featuresParent = null;

        private List<WorldFeature> _features = null;

        private void Awake()
        {
            _features = new List<WorldFeature>();
        }

        public void PlaceFeature(FeatureDefinition definition)
        {
            //Debug.Log("Placing " + definition.Name);
            GameObject clone = Instantiate(definition.Prefab, _featuresParent);
            //clone.transform.position = tile.transform.position;

            WorldFeature feature = clone.GetComponent<WorldFeature>();
            
            //tile.SetFeature(clone.GetComponent<WorldFeature>());
            _features.Add(feature);
        }


        public void ClearFeatures()
        {
            for (int i = 0; i < _features.Count; i++)
            {
                Destroy(_features[i].gameObject);
            }
            
            _features.Clear();
            _featuresParent.ClearTransform();
        }
    }
}
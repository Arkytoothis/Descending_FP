using System.Collections;
using System.Collections.Generic;
using DunGen;
using UnityEngine;

namespace Descending.Interactables
{
    public class KeySpawner : MonoBehaviour, IKeySpawnable
    {
        [SerializeField] private GameObject _bronzeKeyPrefab = null;
        [SerializeField] private GameObject _ironKeyPrefab = null;
        [SerializeField] private GameObject _goldKeyPrefab = null;
        
        public void SpawnKey(Key key, KeyManager manager)
        {
            if (key.ID == 0)
            {
                SpawnBronzeKey();
            }
            else if (key.ID == 1)
            {
                SpawnIronKey();
            }
            else if (key.ID == 2)
            {
                SpawnGoldKey();
            }
            Destroy(gameObject);
        }

        private void SpawnBronzeKey()
        {
            GameObject clone = Instantiate(_bronzeKeyPrefab, null);
            clone.transform.position = transform.position; 
        }

        private void SpawnIronKey()
        {
            GameObject clone = Instantiate(_ironKeyPrefab, null);
            clone.transform.position = transform.position; 
        }

        private void SpawnGoldKey()
        {
            GameObject clone = Instantiate(_goldKeyPrefab, null);
            clone.transform.position = transform.position; 
        }
    }
}
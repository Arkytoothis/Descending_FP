using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Interactables;
using UnityEngine;

namespace Descending.Player
{
    public class KeyDetector : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController = null;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out KeyPickup keyPickup))
            {
                if(keyPickup.KeyType == KeyTypes.Bronze)
                    ResourcesManager.Instance.AddBronzeKey(1);
                else if(keyPickup.KeyType == KeyTypes.Iron)
                    ResourcesManager.Instance.AddIronKey(1);
                else if(keyPickup.KeyType == KeyTypes.Gold)
                    ResourcesManager.Instance.AddGoldKey(1);
                
                Destroy(keyPickup.gameObject);
            }
        }
    }
}

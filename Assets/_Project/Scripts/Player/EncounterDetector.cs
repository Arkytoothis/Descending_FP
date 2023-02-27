using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Encounters;
using UnityEngine;

namespace Descending.Player
{
    public class EncounterDetector : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController = null;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Encounter encounter))
            {
                EncounterManager.Instance.TriggerEncounter(encounter);
                _playerController.EncounterTriggered(encounter);
            }
        }
    }
}

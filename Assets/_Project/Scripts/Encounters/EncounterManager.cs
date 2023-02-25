using System.Collections;
using System.Collections.Generic;
using Descending.Player;
using UnityEngine;

namespace Descending.Encounters
{
    public class EncounterManager : MonoBehaviour
    {
        public static EncounterManager Instance { get; private set; }
        
        [SerializeField] private PlayerController _playerController = null;
        [SerializeField] private List<Encounter> _encounters = null;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("Multiple EncounterManagers " + transform + " - " + Instance);
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
            _encounters = new List<Encounter>();
        }

        public void Setup()
        {
            
        }

        public void RegisterEncounter(Encounter encounter)
        {
            _encounters.Add(encounter);
            encounter.Setup(_playerController.transform);
        }
    }
}

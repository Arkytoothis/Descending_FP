using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Encounters
{
    public class EncounterManager : MonoBehaviour
    {
        public static EncounterManager Instance { get; private set; }
        
        [SerializeField] private List<Encounter> _encounters = null;
        [SerializeField] private List<EncounterSpawner> _encounterSpawners = null;

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
            _encounterSpawners = new List<EncounterSpawner>();
        }

        public void Setup()
        {
            
        }

        public void RegisterEncounter(Encounter encounter)
        {
            _encounters.Add(encounter);
        }

        public void RegisterEncounterSpawner(EncounterSpawner spawner)
        {
            _encounterSpawners.Add(spawner);
        }
    }
}

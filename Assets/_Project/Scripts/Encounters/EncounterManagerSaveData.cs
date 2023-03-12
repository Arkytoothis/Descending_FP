using System.Collections;
using System.Collections.Generic;
using Descending.Encounters;
using Descending.Units;
using UnityEngine;

namespace Descending.Party
{
    [System.Serializable]
    public class EncounterManagerSaveData
    {
        [SerializeField] private List<EncounterSaveData> _encounterData = null;

        public List<EncounterSaveData> EncounterData => _encounterData;

        public EncounterManagerSaveData()
        {
            _encounterData = new List<EncounterSaveData>();
        }

        public EncounterManagerSaveData(List<Encounter> encounterList)
        {
            _encounterData = new List<EncounterSaveData>();
            
            for (int i = 0; i < encounterList.Count; i++)
            {
                if(encounterList[i] == null) continue;
                
                _encounterData.Add(new EncounterSaveData(encounterList[i]));
            }
        }
    }
}
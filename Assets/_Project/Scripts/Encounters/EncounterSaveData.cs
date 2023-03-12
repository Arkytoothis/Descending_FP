using System.Collections;
using System.Collections.Generic;
using Descending.Abilities;
using Descending.Attributes;
using Descending.Core;
using Descending.Encounters;
using Descending.Equipment;
using UnityEngine;

namespace Descending.Units
{
    [System.Serializable]
    public class EncounterSaveData
    {
        [SerializeField] private bool _isActive;
        [SerializeField] private Vector3 _worldPosition;

        public bool IsActive => _isActive;
        public Vector3 WorldPosition => _worldPosition;

        public EncounterSaveData()
        {
            _isActive = false;
            _worldPosition = Vector3.zero;
        }

        public EncounterSaveData(Encounter encounter)
        {
            _isActive = encounter.IsActive;
            _worldPosition = encounter.transform.position;
        }
    }
}
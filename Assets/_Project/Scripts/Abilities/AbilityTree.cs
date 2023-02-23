using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Abilities
{
    [System.Serializable]
    public class AbilityTree
    {
        [SerializeField] private List<AbilityTreeEntry> _entries = null;

        public List<AbilityTreeEntry> Entries => _entries;
    }
}
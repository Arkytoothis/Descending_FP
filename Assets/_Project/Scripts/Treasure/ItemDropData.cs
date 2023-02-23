using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Equipment;
using UnityEngine;

namespace Descending.Treasure
{
    [System.Serializable]
    public class ItemDropData
    {
        public int Chance = 0;
        public GenerateItemType ItemType = GenerateItemType.None;
        public RarityDefinition MinRarity = null;
        public RarityDefinition MaxRarity = null;
    }
}
using Descending.Core;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace Descending.Equipment
{
    [CreateAssetMenu(fileName = "Rarity Database", menuName = "Descending/Database/Rarity Database")]
    public class RarityDatabase : ScriptableObject
    {
        [SerializeField] private List<RarityDefinition> _rarities = null;
        public List<RarityDefinition> Rarities { get => _rarities; }

        public RarityDefinition GetRarity(int rarity)
        {
            return _rarities.FirstOrDefault(i => i.Order == rarity);
        }
        
        public RarityDefinition GetRarity(string rarityKey)
        {
            return _rarities.FirstOrDefault(i => i.name == rarityKey);
        }
    }
}
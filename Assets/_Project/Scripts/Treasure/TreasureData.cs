using System.Collections;
using System.Collections.Generic;
using Descending.Equipment;
using UnityEngine;

namespace Descending
{
    [System.Serializable]
    public class TreasureData
    {
        [SerializeField] private int _coins = 0;
        [SerializeField] private int _gems = 0;
        [SerializeField] private int _supplies = 0;
        [SerializeField] private List<Item> _items = null;

        public int Coins => _coins;
        public int Gems => _gems;
        public int Supplies => _supplies;
        public List<Item> Items => _items;

        public TreasureData(int coins, int gems, int supplies, List<Item> items)
        {
            _coins = coins;
            _gems = gems;
            _supplies = supplies;
            _items = items;
        }
    }
}

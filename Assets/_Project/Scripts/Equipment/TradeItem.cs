using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Equipment
{
    [System.Serializable]
    public class TradeItem
    {
        [SerializeField] private Item _item = null;
        [SerializeField] private int _numberAvailable = 0;
        [SerializeField] private int _goldCost = 0;
        [SerializeField] private int _gemCost = 0;

        public Item Item { get => _item; }
        public int NumberAvailable { get => _numberAvailable; }
        public int GoldCost { get => _goldCost; }
        public int GemCost { get => _gemCost; }

        public TradeItem(Item item, int numberAvailable, int goldCost, int gemCost)
        {
            _item = new Item(item);
            _numberAvailable = numberAvailable;
            _goldCost = goldCost;
            _gemCost = gemCost;
        }
    }
}

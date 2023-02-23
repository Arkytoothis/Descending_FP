using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Descending.Core;
using UnityEngine;

namespace Descending.Equipment
{
    [CreateAssetMenu(fileName = "Item Database", menuName = "Descending/Database/Item Database")]
    public class ItemDatabase : ScriptableObject
    {
        [SerializeField] private ItemsDictionary _data = null;
        public ItemsDictionary Dictionary { get => _data; }

        public ItemDefinition GetItem(string key)
        {
            if (Contains(key))
            {
                return _data[key];
            }
            else
            {
                Debug.Log("Item Key: (" + key + ") does not exist");
                return null;
            }
        }

        // public ItemDefinition GetRandomItem()
        // {
        //     return _data[Random.Range(0, _data.Count)];
        // }

        public string GetRandomItemKey()
        {
            return Utilities.RandomKey(_data);
        }

        public bool Contains(string key)
        {
            return _data.ContainsKey(key);
        }

        public void AddItem(ItemDefinition item)
        {
            if (_data.ContainsKey(item.Key) == false)
            {
                _data.Add(item.Key, item);
            }
        }

        public void RemoveItem(ItemDefinition item)
        {
            if (_data.ContainsKey(item.Key) == true)
            {
                _data.Remove(item.Key);
            }
        }
    }
}
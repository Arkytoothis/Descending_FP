using System.Collections;
using System.Collections.Generic;
using Descending.Equipment;
using ScriptableObjectArchitecture;
using Sirenix.Serialization;
using UnityEngine;

namespace Descending.Core
{
    public class StockpileManager : MonoBehaviour
    {
        public static StockpileManager Instance { get; private set; }
        public const int MAX_STOCKPILE_SLOTS = 96;

        [SerializeField] private int _numItemToGenerate = 0;
        [SerializeField] private bool _loadData = false;
        
        [SerializeField] private BoolEvent onSyncStockpile = null;
        
        [SerializeField] private List<Item> _items = null;

        public List<Item> Items => _items;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("Multiple Stockpile Managers " + transform + " - " + Instance);
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
        }

        public void Setup()
        {
            if (_loadData == true)
            {
                LoadState();
            }
            else
            {
                GenerateData();
            }
        }

        public Item GetItem(int index)
        {
            return _items[index];
        }

        public void AddItem(Item item)
        {
            int index = -1;

            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].IsEmpty())
                {
                    index = i;
                    break;
                }
            }

            if (index > -1)
            {
                _items[index] = new Item(item);
            }
            onSyncStockpile.Invoke(true);
        }

        public void OnItemPickedUp(Item item)
        {
            AddItem(item);
            onSyncStockpile.Invoke(true);
        }

        public void ClearItem(int index)
        {
            _items[index] = new Item();
        }

        public void SetItem(Item item, int index)
        {
            _items[index] = new Item(item);
        }

        public void SyncStockpile()
        {
            onSyncStockpile.Invoke(true);
        }
        
        public void SaveState()
        {
            byte[] bytes = SerializationUtility.SerializeValue(_items, DataFormat.JSON);
            //File.WriteAllBytes(Database.instance.StockpileFilePath, bytes);
        }

        private void GenerateData()
        {
            _items = new List<Item>();
            
            for (int i = 0; i < MAX_STOCKPILE_SLOTS; i++)
            {
                _items.Add(new Item());    
            }

            for (int i = 0; i < _numItemToGenerate; i++)
            {
                AddItem(ItemGenerator.GenerateRandomItem(Database.instance.Rarities.GetRarity("Legendary"), 10, 10, 10));
            }
        }
        
        public void LoadState()
        {
            // if (!File.Exists(Database.instance.StockpileFilePath)) return; // No state to load
	           //
            // byte[] bytes = File.ReadAllBytes(Database.instance.StockpileFilePath);
            // _items = SerializationUtility.DeserializeValue<List<Item>>(bytes, DataFormat.JSON);
            
            SyncStockpile();
        }

        public void SetLoadData(bool loadData)
        {
            _loadData = loadData;
        }
    }
}
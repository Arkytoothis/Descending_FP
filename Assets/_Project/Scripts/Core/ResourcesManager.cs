using System.Collections;
using System.Collections.Generic;
using System.IO;
using ScriptableObjectArchitecture;
using Sirenix.Serialization;
using UnityEngine;

namespace Descending.Core
{
    public class ResourcesManager : MonoBehaviour
    {
        public static ResourcesManager Instance { get; private set; }

        [SerializeField] private int _coins = 0;
        [SerializeField] private int _gems = 0;
        [SerializeField] private int _supplies = 0;
        
        [SerializeField] private bool _loadData = false;

        [SerializeField] private IntEvent onUpdateCoins = null;
        [SerializeField] private IntEvent onUpdateGems = null;
        [SerializeField] private IntEvent onUpdateSupplies = null;
        
        public int Coins => _coins;
        public int Gems => _gems;
        public int Supplies => _supplies;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("Multiple Resource Managers " + transform + " - " + Instance);
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
                Setup(100, 0, 20);
            }
        }
        
        private void Setup(int coins, int gems, int supplies)
        {
            
            AddCoins(coins);
            AddGems(gems);
            AddSupplies(supplies);
        }

        public void AddCoins(int coins)
        {
            _coins += coins;
            onUpdateCoins.Invoke(_coins);
            //Debug.Log("Coins Added: " + coins + "/" + _coins);
        }

        public void AddSupplies(int supplies)
        {
            _supplies += supplies;
            onUpdateSupplies.Invoke(_supplies);
        }

        public void AddGems(int gems)
        {
            _gems += gems;
            onUpdateGems.Invoke(_gems);
        }
        
        public void SpendCoins(int coins)
        {
            _coins -= coins;
            onUpdateCoins.Invoke(_coins);
            //Debug.Log("Coins Added: " + coins + "/" + _coins);
        }

        public void SpendSupplies(int supplies)
        {
            _supplies -= supplies;
            onUpdateSupplies.Invoke(_supplies);
        }

        public void SpendGems(int gems)
        {
            _gems -= gems;
            onUpdateGems.Invoke(_gems);
        }

        public void SyncResources()
        {
            onUpdateCoins.Invoke(_coins);
            onUpdateGems.Invoke(_gems);
            onUpdateSupplies.Invoke(_supplies);
        }
        
        public void SaveState()
        {
            ResourcesSaveData saveData = new ResourcesSaveData();
            byte[] bytes = SerializationUtility.SerializeValue(saveData, DataFormat.JSON);
            //File.WriteAllBytes(Database.instance.ResourceDataFilePath, bytes);
        }
        
        public void LoadState()
        {
            // if (!File.Exists(Database.instance.ResourceDataFilePath)) return; // No state to load
	           //
            // byte[] bytes = File.ReadAllBytes(Database.instance.ResourceDataFilePath);
            //ResourcesSaveData saveData = SerializationUtility.DeserializeValue<ResourcesSaveData>(bytes, DataFormat.JSON);

            // _coins = saveData.Coins;
            // _gems = saveData.Gems;
            // _materials = saveData.Materials;
            // _supplies = saveData.Supplies;

            SyncResources();
        }

        public void SetLoadData(bool loadData)
        {
            _loadData = loadData;
        }
    }

    [System.Serializable]
    public class ResourcesSaveData
    {
        [SerializeField] private int _coins = 0;
        [SerializeField] private int _gems = 0;
        [SerializeField] private int _supplies = 0;

        public int Coins => _coins;
        public int Gems => _gems;
        public int Supplies => _supplies;

        public ResourcesSaveData()
        {
            _coins = ResourcesManager.Instance.Coins;
            _gems = ResourcesManager.Instance.Gems;
            _supplies = ResourcesManager.Instance.Supplies;
        }
    }
}

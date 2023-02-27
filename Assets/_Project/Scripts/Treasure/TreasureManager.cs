using System.Collections;
using System.Collections.Generic;
using Descending.Equipment;
using Descending.Interactables;
using UnityEngine;

namespace Descending.Treasure
{
    public class TreasureManager : MonoBehaviour
    {
        public static TreasureManager Instance { get; private set; }

        [SerializeField] private GameObject _lootContainerPrefab = null;
        [SerializeField] private Transform _lootContainers = null;
        
        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("Multiple Treasure Managers " + transform + " - " + Instance);
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
        }

        public void Setup()
        {
            
        }

        public void SpawnTreasureChest(Vector3 position)
        {
            GameObject clone = Instantiate(_lootContainerPrefab, _lootContainers);
            clone.transform.position = position;

            TreasureChest treasureChest = clone.GetComponent<TreasureChest>();
            treasureChest.SetTreasureData(GetTreasureData());
        }

        private TreasureData GetTreasureData()
        {
            int coins = Random.Range(1, 10);
            int gems = Random.Range(0, 1);
            int supplies = Random.Range(0, 1);
            List<Item> itemList = new List<Item>();
            
            return new TreasureData(coins, gems, supplies, itemList);
        }
    }
}
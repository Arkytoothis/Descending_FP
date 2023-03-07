using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Equipment;
using Descending.Interactables;
using Descending.Player;
using UnityEngine;

namespace Descending.Treasure
{
    public class TreasureManager : MonoBehaviour
    {
        public static TreasureManager Instance { get; private set; }

        [SerializeField] private PlayerController _playerController = null;
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
            clone.transform.LookAt(_playerController.transform, Vector3.up);
            Utilities.PlaceOnGround(clone.transform, -1f);
            
            TreasureChest treasureChest = clone.GetComponent<TreasureChest>();
            treasureChest.SetTreasureData(GetTreasureData());
        }

        private TreasureData GetTreasureData()
        {
            List<Item> itemList = new List<Item>();
            int coins = Random.Range(1, 10);
            int gems = Random.Range(0, 1);
            int supplies = Random.Range(0, 1);
            int numItems = Random.Range(1, 4);
            
            for (int i = 0; i < numItems; i++)
            {
                Item item = ItemGenerator.GenerateRandomItem(Database.instance.Rarities.GetRarity("Common"), GenerateItemType.Any, 10, 10, 10);
                itemList.Add(item);
            }
            
            return new TreasureData(coins, gems, supplies, itemList);
        }
    }
}
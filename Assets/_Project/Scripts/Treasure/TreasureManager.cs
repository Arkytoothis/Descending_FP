using System.Collections;
using System.Collections.Generic;
using Descending.Equipment;
using UnityEngine;

namespace Descending.Treasure
{
    public enum CoinTypes { Copper, Silver, Gold, Mithril }
    public enum GemTypes { Sapphire, Emerald, Ruby, Diamond }
    
    public class TreasureManager : MonoBehaviour
    {
        public static TreasureManager Instance { get; private set; }

        [SerializeField] private List<GameObject> _coinPrefabs = null;
        [SerializeField] private List<GameObject> _gemPrefabs = null;
        [SerializeField] private Transform _coinsParent = null;
        [SerializeField] private Transform _gemsParent = null;
        [SerializeField] private Transform _itemDropsParent = null;
        [SerializeField] private float _torqueModifier = 10f;
        [SerializeField] private float _horizontalSpawnRadius = 0.4f;
        [SerializeField] private float _verticalSpawnMin = 0.5f;
        [SerializeField] private float _verticalSpawnMax = 2f;
        
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

        public void SpawnCoins(Vector3 spawnPosition, int amount, CoinTypes coinType, float delay)
        {
            for (int i = 0; i < amount; i++)
            {
                StartCoroutine(SpawnCoin_Coroutine(delay, spawnPosition, coinType));
            }
        }

        public void SpawnGems(Vector3 spawnPosition, int amount, GemTypes gemType, float delay)
        {
            for (int i = 0; i < amount; i++)
            {
                StartCoroutine(SpawnGem_Coroutine(delay, spawnPosition, gemType));
            }
        }

        public ItemDrop SpawnItemDrop(ItemDefinition itemDefinition, Vector3 spawnPosition)
        {
            float xOffset = Random.Range(-_horizontalSpawnRadius, _horizontalSpawnRadius);
            float yOffset = Random.Range(_verticalSpawnMin, _verticalSpawnMax);
            float zOffset = Random.Range(-_horizontalSpawnRadius, _horizontalSpawnRadius);
            
            GameObject clone = Instantiate(itemDefinition.ItemDrop.gameObject, _itemDropsParent);
            clone.transform.position = new Vector3(spawnPosition.x + xOffset, spawnPosition.y + yOffset, spawnPosition.z + zOffset);

            Rigidbody rigidbody = clone.GetComponent<Rigidbody>();
            rigidbody.AddTorque(new Vector3(Random.Range(-_torqueModifier, _torqueModifier), Random.Range(-_torqueModifier, _torqueModifier), Random.Range(-_torqueModifier, _torqueModifier)));
            
            ItemDrop itemDrop = clone.GetComponent<ItemDrop>();

            return itemDrop;
            
        }
        
        private IEnumerator SpawnCoin_Coroutine(float delay, Vector3 spawnPosition, CoinTypes coinType)
        {
            yield return new WaitForSeconds(delay);
            
            //Debug.Log("Spawning " + coinType.ToString());
            float xOffset = Random.Range(-_horizontalSpawnRadius, _horizontalSpawnRadius);
            float yOffset = Random.Range(_verticalSpawnMin, _verticalSpawnMax);
            float zOffset = Random.Range(-_horizontalSpawnRadius, _horizontalSpawnRadius);
            GameObject clone = Instantiate(_coinPrefabs[(int) coinType], _coinsParent);
            clone.transform.position = new Vector3(spawnPosition.x + xOffset, spawnPosition.y + yOffset, spawnPosition.z + zOffset);
            
            Rigidbody rigidbody = clone.GetComponent<Rigidbody>();
            rigidbody.AddTorque(new Vector3(Random.Range(-_torqueModifier, _torqueModifier), Random.Range(-_torqueModifier, _torqueModifier), Random.Range(-_torqueModifier, _torqueModifier)));
            //rigidbody.AddExplosionForce(50f, transform.position, 10f, 5f);
        }
        
        private IEnumerator SpawnGem_Coroutine(float delay, Vector3 spawnPosition, GemTypes gemType)
        {
            yield return new WaitForSeconds(0.2f);
            
            //Debug.Log("Spawning " + gemType.ToString());
            float xOffset = Random.Range(-0.1f, 0.1f);
            float yOffset = Random.Range(2f, 2.2f);
            float zOffset = Random.Range(-0.1f, 0.1f);
            GameObject clone = Instantiate(_gemPrefabs[(int) gemType], _gemsParent);
            clone.transform.position = new Vector3(spawnPosition.x + xOffset, spawnPosition.y + yOffset, spawnPosition.z + zOffset);
            
            Rigidbody rigidbody = clone.GetComponent<Rigidbody>();
            rigidbody.AddTorque(new Vector3(Random.Range(-_torqueModifier, _torqueModifier), Random.Range(-_torqueModifier, _torqueModifier), Random.Range(-_torqueModifier, _torqueModifier)));
            //rigidbody.AddExplosionForce(50f, transform.position, 10f, 5f);
        }
    }
}
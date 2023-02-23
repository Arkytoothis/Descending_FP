using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Equipment
{
    public class ItemDrop : MonoBehaviour
    {
        [SerializeField] private ItemDefinition _itemDefinition = null;
        
        //[SerializeField] private ItemEvent onPickupItem = null;
        public ItemDefinition ItemDefinition => _itemDefinition;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Item Pickup Sphere"))
            {
                PickupItem();
            }
        }

        private void PickupItem()
        {
            Item item = ItemGenerator.GenerateItem(Database.instance.Rarities.GetRarity("Legendary"), _itemDefinition.Key, 100, 100, 100);
            //onPickupItem.Invoke(item);
            Destroy(gameObject);
            //Debug.Log(item.Name + " picked up");
        }
    }
}

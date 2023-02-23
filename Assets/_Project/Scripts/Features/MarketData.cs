using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Equipment;
using UnityEngine;

namespace Descending.Features
{
    [System.Serializable]
    public class MarketData : MonoBehaviour
    {
        [SerializeField] private List<Item> _shopItems = null;

        public List<Item> ShopItems => _shopItems;

        public void GenerateShopItems()
        {
            _shopItems = new List<Item>();
            int numWeaponsToGenerate = 5;

            for (int i = 0; i < numWeaponsToGenerate; i++)
            {
                Item item = ItemGenerator.GenerateRandomItem(Database.instance.Rarities.GetRarity("Uncommon"), GenerateItemType.Any_Weapon, 0, 0, 0);
                _shopItems.Add(item);
            }

            int numArmorToGenerate = 5;

            for (int i = 0; i < numArmorToGenerate; i++)
            {
                Item item = ItemGenerator.GenerateRandomItem(Database.instance.Rarities.GetRarity("Uncommon"), GenerateItemType.Any_Armor, 0, 0, 0);
                _shopItems.Add(item);
            }

            int numShieldsToGenerate = 2;

            for (int i = 0; i < numShieldsToGenerate; i++)
            {
                Item item = ItemGenerator.GenerateRandomItem(Database.instance.Rarities.GetRarity("Uncommon"), GenerateItemType.Any_Shield, 0, 0, 0);
                _shopItems.Add(item);
            }

            int numHealingPotionsToGenerate = 3;

            for (int i = 0; i < numHealingPotionsToGenerate; i++)
            {
                Item item = ItemGenerator.GenerateRandomItem(Database.instance.Rarities.GetRarity("Uncommon"), Database.instance.Items.GetItem("Small Healing Potion"), 0, 0, 0);
                _shopItems.Add(item);
            }

            int numEssencePotionsToGenerate = 3;

            for (int i = 0; i < numEssencePotionsToGenerate; i++)
            {
                Item item = ItemGenerator.GenerateRandomItem(Database.instance.Rarities.GetRarity("Uncommon"), Database.instance.Items.GetItem("Small Essence Potion"), 0, 0, 0);
                _shopItems.Add(item);
            }

            int numBombsToGenerate = 2;

            for (int i = 0; i < numBombsToGenerate; i++)
            {
                Item item = ItemGenerator.GenerateRandomItem(Database.instance.Rarities.GetRarity("Uncommon"), Database.instance.Items.GetItem("Small Bomb"), 0, 0, 0);
                _shopItems.Add(item);
            }
        }
    }
}
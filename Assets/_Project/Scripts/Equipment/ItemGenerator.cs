using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Equipment.Enchantments;
using UnityEngine;

namespace Descending.Equipment
{
    public static class ItemGenerator
    {
        private static List<string> _accessories = new List<string>();

        private static List<List<MaterialDefinition>> _anyMaterials = new List<List<MaterialDefinition>>();
        private static List<List<MaterialDefinition>> _woodMaterials = new List<List<MaterialDefinition>>();
        private static List<List<MaterialDefinition>> _clothMaterials = new List<List<MaterialDefinition>>();
        private static List<List<MaterialDefinition>> _leatherMaterials = new List<List<MaterialDefinition>>();
        private static List<List<MaterialDefinition>> _stoneMaterials = new List<List<MaterialDefinition>>();
        private static List<List<MaterialDefinition>> _metalMaterials = new List<List<MaterialDefinition>>();
        private static List<List<MaterialDefinition>> _hardMaterials = new List<List<MaterialDefinition>>();
        private static List<List<MaterialDefinition>> _softMaterials = new List<List<MaterialDefinition>>();
        private static List<List<MaterialDefinition>> _potionMaterials = new List<List<MaterialDefinition>>();
        private static List<List<MaterialDefinition>> _foodMaterials = new List<List<MaterialDefinition>>();
        private static List<List<MaterialDefinition>> _drinkMaterials = new List<List<MaterialDefinition>>();
        private static List<List<MaterialDefinition>> _paperMaterials = new List<List<MaterialDefinition>>();
        private static List<List<MaterialDefinition>> _bookMaterials = new List<List<MaterialDefinition>>();

        private static List<EnchantmentDefinition> _qualityEnchants = new List<EnchantmentDefinition>();
        private static List<EnchantmentDefinition> _prefixEnchants = new List<EnchantmentDefinition>();
        private static List<EnchantmentDefinition> _suffixEnchants = new List<EnchantmentDefinition>();

        private static List<List<string>> _itemsBySlot = null;
        private static List<List<string>> _itemsByType = null;

        public static void Setup()
        {
            LoadItemsBySlot();
            LoadItemsByType();
            LoadMaterials();
            LoadAccessories();
            LoadEnchants();
        }

        public static Item GenerateRandomItem(RarityDefinition bestMaterial, int plusChance, int prefixChance, int suffixChance)
        {
            string itemKey = Database.instance.Items.GetRandomItemKey();
            Item item = new Item(Database.instance.Items.GetItem(itemKey));
            MaterialDefinition material = GetItemMaterial(item, bestMaterial);
            item.SetMaterial(material);

            RandomizeQuality(ref item, plusChance);

            if (item.ItemDefinition.Category != ItemCategory.Accessories)
            {
                RandomizePrefix(ref item, prefixChance);
                RandomizeSuffix(ref item, suffixChance);
            }

            item.CalculateValue();

            return item;
        }

        public static string GetRandomKeyByType(GenerateItemType itemType)
        {
            string itemKey = _itemsByType[(int)itemType][UnityEngine.Random.Range(0, _itemsByType[(int)itemType].Count)];
            return itemKey;
        }
        
        public static Item GenerateRandomItem(RarityDefinition bestMaterial, GenerateItemType itemType, int plusChance, int prefixChance, int suffixChance)
        {
            if (_itemsByType[(int)itemType].Count == 0) { return null; }

            string itemKey = _itemsByType[(int)itemType][UnityEngine.Random.Range(0, _itemsByType[(int)itemType].Count)];
            Item item = new Item(Database.instance.Items.GetItem(itemKey));
            MaterialDefinition material = GetItemMaterial(item, bestMaterial);
            item.SetMaterial(material);
            RandomizeQuality(ref item, plusChance);

            if (item.ItemDefinition.Category != ItemCategory.Accessories)
            {
                RandomizePrefix(ref item, prefixChance);
                RandomizeSuffix(ref item, suffixChance);
            }

            item.CalculateValue();

            return item;
        }
        
        
        public static Item GenerateRandomItem(RarityDefinition bestMaterial, ItemDefinition itemDefinition, int plusChance, int prefixChance, int suffixChance)
        {
            string itemKey = itemDefinition.Key;
            Item item = new Item(Database.instance.Items.GetItem(itemKey));
            MaterialDefinition material = GetItemMaterial(item, bestMaterial);
            item.SetMaterial(material);
            RandomizeQuality(ref item, plusChance);

            if (item.ItemDefinition.Category != ItemCategory.Accessories)
            {
                RandomizePrefix(ref item, prefixChance);
                RandomizeSuffix(ref item, suffixChance);
            }

            item.CalculateValue();

            return item;
        }

        public static Item GenerateItem(RarityDefinition bestMaterial, string itemKey, int plusChance, int prefixChance, int suffixChance)
        {
            Item item = new Item(Database.instance.Items.GetItem(itemKey));
            MaterialDefinition material = GetItemMaterial(item, bestMaterial);
            item.SetMaterial(material);
            RandomizeQuality(ref item, plusChance);

            if (item.ItemDefinition.Category != ItemCategory.Accessories)
            {
                RandomizePrefix(ref item, prefixChance);
                RandomizeSuffix(ref item, suffixChance);
            }

            item.CalculateValue();

            return item;
        }
        
        public static Item GenerateRandomAccessory(RarityDefinition bestMaterial)
        {
            string itemKey = _accessories[UnityEngine.Random.Range(0, _accessories.Count)];
            Item item = new Item(Database.instance.Items.GetItem(itemKey));
            MaterialDefinition material = GetItemMaterial(item, bestMaterial);
            item.SetMaterial(material);
            item.CalculateValue();

            return item;
        }

        public static Item GenerateAccessory(string accessory, RarityDefinition bestMaterial)
        {
            Item item = new Item(Database.instance.Items.GetItem(accessory));
            MaterialDefinition material = GetItemMaterial(item, bestMaterial);
            item.SetMaterial(material);
            item.CalculateValue();

            return item;
        }

        //public static TradeItem GenerateRandomTradeItem(Rarity bestMaterial, int plusChance, int prefixChance, int suffixChance)
        //{
        //    Item item = GenerateRandomItem(bestMaterial, plusChance, prefixChance, suffixChance);
        //    int numberAvailable = UnityEngine.Random.Range(1, 6);
        //    int goldCost = item.GoldValue;
        //    int gemCost = item.GemValue;
        //    TradeItem tradeItem = new TradeItem(item, numberAvailable, goldCost, gemCost);

        //    return tradeItem;
        //}

        //public static TradeItem GenerateRandomTradeItem(Rarity bestMaterial, GenerateItemType itemType, int plusChance, int prefixChance, int suffixChance)
        //{
        //    Item item = GenerateRandomItem(bestMaterial, itemType, plusChance, prefixChance, suffixChance);
        //    int numberAvailable = 1;
        //    int goldCost = item.GoldValue;
        //    int gemCost = item.GemValue;
        //    TradeItem tradeItem = new TradeItem(item, numberAvailable, goldCost, gemCost);

        //    return tradeItem;
        //}

        public static ItemShort GenerateRandomItemShort(RarityDefinition bestMaterial, int bestQuality, int plusChance, int prefixChance, int suffixChance)
        {
            Item item = GenerateRandomItem(bestMaterial, plusChance, prefixChance, suffixChance);
            MaterialDefinition material = null;
            EnchantmentDefinition quality = null;            
            EnchantmentDefinition prefix = null;
            EnchantmentDefinition suffix = null;

            if (UnityEngine.Random.Range(0, 100) < plusChance)
            {
                quality = Database.instance.Enchants.GetEnchant(_qualityEnchants[UnityEngine.Random.Range(5, _qualityEnchants.Count)].Key);
            }
            else if (bestQuality > -1)
            {
                quality = Database.instance.Enchants.GetEnchant(_qualityEnchants[UnityEngine.Random.Range(0, bestQuality)].Key);
            }

            if (UnityEngine.Random.Range(0, 100) < prefixChance)
            {
                prefix = Database.instance.Enchants.GetEnchant(_prefixEnchants[UnityEngine.Random.Range(0, _prefixEnchants.Count)].Key);
            }

            if (UnityEngine.Random.Range(0, 100) < suffixChance)
            {
                suffix = Database.instance.Enchants.GetEnchant(_suffixEnchants[UnityEngine.Random.Range(0, _suffixEnchants.Count)].Key);
            }

            ItemShort itemShort = new ItemShort(item.ItemDefinition, quality, material, prefix, suffix);

            return itemShort;
        }

        public static Item GenerateItem(RarityDefinition bestMaterial, ItemShort itemShort)
        {
            if (Database.instance.Items.Contains(itemShort.Item.Key) == false)
            {
                Debug.Log("Key: " + itemShort.Item.Key + " does not exist");
                return null;
            }

            Item item = new Item(Database.instance.Items.GetItem(itemShort.Item.Key));
            MaterialDefinition material = GetItemMaterial(item, bestMaterial);
            item.SetMaterial(material);
            item.CalculateValue();

            return item;
        }

        public static Item GenerateItem(ItemShort itemShort)
        {
            if (Database.instance.Items.Contains(itemShort.Item.Key) == false)
            {
                Debug.Log("Key: " + itemShort.Item.Key + " does not exist");
                return null;
            }

            Item item = new Item(Database.instance.Items.GetItem(itemShort.Item.Key));
            MaterialDefinition material = Database.instance.Materials.GetMaterial(itemShort.Material.Key);
            item.SetMaterial(material);
            EnchantmentDefinition quality = Database.instance.Enchants.GetEnchant(itemShort.Quality.Key);
            item.SetQualityEnchant(quality);

            if (itemShort.Prefix != null)
            {
                EnchantmentDefinition prefix = Database.instance.Enchants.GetEnchant(itemShort.Prefix.Key);
                item.SetPrefixEnchant(prefix);
            }

            if (itemShort.Suffix != null)
            {
                EnchantmentDefinition suffix = Database.instance.Enchants.GetEnchant(itemShort.Suffix.Key);
                item.SetSuffixEnchant(suffix);
            }

            item.CalculateValue();
            return item;
        }

        private static void RandomizeQuality(ref Item item, int plusChance)
        {
            ItemDefinition definition = Database.instance.Items.GetItem(item.Key);

            //if (UnityEngine.Random.Range(0, 100) < plusChance)
            //{
            string key = _qualityEnchants[0].Key;
            //Debug.Log(key);
            item.SetQualityEnchant(_qualityEnchants[UnityEngine.Random.Range(0, _qualityEnchants.Count)]);
            //}

            // if (definition.BestQualityAllowed > -1)
            // {
            //     item.SetQualityEnchant(new Enchantment(_qualityEnchants[UnityEngine.Random.Range(0, definition.BestQualityAllowed)]));
            // }
            // else
            // {
            //     item.SetQualityEnchant(null);
            // }
        }

        private static void RandomizePrefix(ref Item item, int prefixChance)
        {
            ItemDefinition definition = Database.instance.Items.GetItem(item.Key);

            if (definition.Enchantable == false) { return; }

            if (UnityEngine.Random.Range(0, 100) < prefixChance)
            {
                item.SetPrefixEnchant(new Enchantment(_prefixEnchants[UnityEngine.Random.Range(0, _prefixEnchants.Count)]));
            }
        }

        private static void RandomizeSuffix(ref Item item, int suffixChance)
        {
            ItemDefinition definition = Database.instance.Items.GetItem(item.Key);

            if (definition.Enchantable == false) { return; }

            if (UnityEngine.Random.Range(0, 100) < suffixChance)
            {
                item.SetSuffixEnchant(new Enchantment(_suffixEnchants[UnityEngine.Random.Range(0, _suffixEnchants.Count)]));
            }
        }
        
        private static MaterialDefinition GetItemMaterial(Item item, RarityDefinition bestRarity)
        {
            MaterialDefinition material = null;

            //Debug.Log(item.Name + " " + bestRarity);
            switch (item.MaterialAllowed)
            {
                case ItemMaterialAllowed.Any:
                    material = GetMaterial(ItemMaterialAllowed.Any, UnityEngine.Random.Range(0, bestRarity.Order), _anyMaterials);
                    break;
                case ItemMaterialAllowed.Hard:
                    material = GetMaterial(ItemMaterialAllowed.Hard, UnityEngine.Random.Range(0, bestRarity.Order), _hardMaterials);
                    break;
                case ItemMaterialAllowed.Soft:
                    material = GetMaterial(ItemMaterialAllowed.Soft, UnityEngine.Random.Range(0, bestRarity.Order), _softMaterials);
                    break;
                case ItemMaterialAllowed.Metal:
                    material = GetMaterial(ItemMaterialAllowed.Metal, UnityEngine.Random.Range(0, bestRarity.Order), _metalMaterials);
                    break;
                case ItemMaterialAllowed.Stone:
                    material = GetMaterial(ItemMaterialAllowed.Stone, UnityEngine.Random.Range(0, bestRarity.Order), _stoneMaterials);
                    break;
                case ItemMaterialAllowed.Wood:
                    material = GetMaterial(ItemMaterialAllowed.Wood, UnityEngine.Random.Range(0, bestRarity.Order), _woodMaterials);
                    break;
                case ItemMaterialAllowed.Cloth:
                    material = GetMaterial(ItemMaterialAllowed.Cloth, UnityEngine.Random.Range(0, bestRarity.Order), _clothMaterials);
                    break;
                case ItemMaterialAllowed.Leather:
                    material = GetMaterial(ItemMaterialAllowed.Leather, UnityEngine.Random.Range(0, bestRarity.Order), _leatherMaterials);
                    break;
                case ItemMaterialAllowed.Food:
                    material = GetMaterial(ItemMaterialAllowed.Food, UnityEngine.Random.Range(0, bestRarity.Order), _foodMaterials);
                    break;
                case ItemMaterialAllowed.Drink:
                    material = GetMaterial(ItemMaterialAllowed.Drink, UnityEngine.Random.Range(0, bestRarity.Order), _drinkMaterials);
                    break;
                case ItemMaterialAllowed.Potion:
                    material = GetMaterial(ItemMaterialAllowed.Potion, UnityEngine.Random.Range(0, bestRarity.Order), _potionMaterials);
                    break;
                case ItemMaterialAllowed.Paper:
                    material = GetMaterial(ItemMaterialAllowed.Paper, UnityEngine.Random.Range(0, bestRarity.Order), _paperMaterials);
                    break;
                case ItemMaterialAllowed.Book:
                    material = GetMaterial(ItemMaterialAllowed.Book, UnityEngine.Random.Range(0, bestRarity.Order), _bookMaterials);
                    break;
                default:
                    break;
            }

            return material;
        }

        private static MaterialDefinition GetMaterial(ItemMaterialAllowed allowed, int rarityIndex, List<List<MaterialDefinition>> materials)
        {
            //Debug.Log(allowed.ToString() + " - Rarity: " + rarityIndex);
            int materialIndex = UnityEngine.Random.Range(0, materials[rarityIndex].Count);
            //Debug.Log(" Material: " + materialIndex);
            return materials[rarityIndex][materialIndex];
        }

        private static void LoadMaterials()
        {
            for (int i = 0; i < Database.instance.Rarities.Rarities.Count; i++)
            {
                _anyMaterials.Add(new List<MaterialDefinition>());
                _woodMaterials.Add(new List<MaterialDefinition>());
                _clothMaterials.Add(new List<MaterialDefinition>());
                _leatherMaterials.Add(new List<MaterialDefinition>());
                _stoneMaterials.Add(new List<MaterialDefinition>());
                _metalMaterials.Add(new List<MaterialDefinition>());
                _hardMaterials.Add(new List<MaterialDefinition>());
                _softMaterials.Add(new List<MaterialDefinition>());
                _foodMaterials.Add(new List<MaterialDefinition>());
                _drinkMaterials.Add(new List<MaterialDefinition>());
                _potionMaterials.Add(new List<MaterialDefinition>());
                _paperMaterials.Add(new List<MaterialDefinition>());
                _bookMaterials.Add(new List<MaterialDefinition>());
            }

            foreach (var materialKvp in Database.instance.Materials.Materials)
            {
                if (materialKvp.Value.MaterialType == ItemMaterialType.Cloth)
                {
                    _anyMaterials[materialKvp.Value.Rarity.Order].Add(materialKvp.Value);
                    _clothMaterials[materialKvp.Value.Rarity.Order].Add(materialKvp.Value);
                    _softMaterials[materialKvp.Value.Rarity.Order].Add(materialKvp.Value);
                }
                else if (materialKvp.Value.MaterialType == ItemMaterialType.Leather)
                {
                    _anyMaterials[materialKvp.Value.Rarity.Order].Add(materialKvp.Value);
                    _leatherMaterials[materialKvp.Value.Rarity.Order].Add(materialKvp.Value);
                    _softMaterials[materialKvp.Value.Rarity.Order].Add(materialKvp.Value);
                }
                else if (materialKvp.Value.MaterialType == ItemMaterialType.Metal)
                {
                    _anyMaterials[materialKvp.Value.Rarity.Order].Add(materialKvp.Value);
                    _metalMaterials[materialKvp.Value.Rarity.Order].Add(materialKvp.Value);
                    _hardMaterials[materialKvp.Value.Rarity.Order].Add(materialKvp.Value);
                }
                else if (materialKvp.Value.MaterialType == ItemMaterialType.Stone)
                {
                    _anyMaterials[materialKvp.Value.Rarity.Order].Add(materialKvp.Value);
                    _stoneMaterials[materialKvp.Value.Rarity.Order].Add(materialKvp.Value);
                    _hardMaterials[materialKvp.Value.Rarity.Order].Add(materialKvp.Value);
                }
                else if (materialKvp.Value.MaterialType == ItemMaterialType.Wood)
                {
                    _anyMaterials[materialKvp.Value.Rarity.Order].Add(materialKvp.Value);
                    _woodMaterials[materialKvp.Value.Rarity.Order].Add(materialKvp.Value);
                    _hardMaterials[materialKvp.Value.Rarity.Order].Add(materialKvp.Value);
                }
                else if (materialKvp.Value.MaterialType == ItemMaterialType.Food)
                {
                    _foodMaterials[materialKvp.Value.Rarity.Order].Add(materialKvp.Value);
                }
                else if (materialKvp.Value.MaterialType == ItemMaterialType.Drink)
                {
                    _drinkMaterials[materialKvp.Value.Rarity.Order].Add(materialKvp.Value);
                }
                else if (materialKvp.Value.MaterialType == ItemMaterialType.Potion)
                {
                    _potionMaterials[materialKvp.Value.Rarity.Order].Add(materialKvp.Value);
                }
                else if (materialKvp.Value.MaterialType == ItemMaterialType.Paper)
                {
                    _paperMaterials[materialKvp.Value.Rarity.Order].Add(materialKvp.Value);
                }
                else if (materialKvp.Value.MaterialType == ItemMaterialType.Book)
                {
                    _bookMaterials[materialKvp.Value.Rarity.Order].Add(materialKvp.Value);
                }
            }
        }

        private static void LoadAccessories()
        {
            foreach (var item in Database.instance.Items.Dictionary)
            {
                if (item.Value.AccessoryData.HasData == true)
                {
                    _accessories.Add(item.Key);
                }
            }
        }

        private static void LoadEnchants()
        {
            foreach (var enchantKvp in Database.instance.Enchants.Enchantments)
            {
                if (enchantKvp.Value.EnchantmentType == EnchantmentType.Quality)
                {
                    _qualityEnchants.Add(enchantKvp.Value);
                }
                else if (enchantKvp.Value.EnchantmentType == EnchantmentType.Prefix)
                {
                    _prefixEnchants.Add(enchantKvp.Value);
                }
                else if (enchantKvp.Value.EnchantmentType == EnchantmentType.Suffix)
                {
                    _suffixEnchants.Add(enchantKvp.Value);
                }
            }
        }

        private static void LoadItemsBySlot()
        {
            _itemsBySlot = new List<List<string>>();
            for (int i = 0; i < (int)EquipmentSlots.Number; i++)
            {
                _itemsBySlot.Add(new List<string>());
            }

            foreach (var item in Database.instance.Items.Dictionary)
            {
                if (item.Value.EquipmentSlot != EquipmentSlots.None)
                {
                    //Debug.Log("Key: " + item.Key + " Slot: " + item.Value.EquipmentSlot);
                    if (item.Value.EquipmentSlot != EquipmentSlots.None)
                    {
                        _itemsBySlot[(int) item.Value.EquipmentSlot].Add(item.Key);
                    }
                }
            }
        }

        private static void LoadItemsByType()
        {
            _itemsByType = new List<List<string>>();
            for (int i = 0; i < (int)GenerateItemType.Number; i++)
            {
                _itemsByType.Add(new List<string>());
            }

            foreach (var item in Database.instance.Items.Dictionary)
            {
                if (item.Value.ItemType != ItemType.None)
                {
                    _itemsByType[(int)item.Value.ItemType].Add(item.Key);
                    _itemsByType[(int)GenerateItemType.Any].Add(item.Key);

                    if (item.Value.ItemType == ItemType.Axe || item.Value.ItemType == ItemType.Bow || item.Value.ItemType == ItemType.Dagger || item.Value.ItemType == ItemType.Firearm ||
                        item.Value.ItemType == ItemType.Hammer || item.Value.ItemType == ItemType.Instrument || item.Value.ItemType == ItemType.Mace || item.Value.ItemType == ItemType.Polearm ||
                        item.Value.ItemType == ItemType.Scepter || item.Value.ItemType == ItemType.Staff || item.Value.ItemType == ItemType.Sword)
                    {
                        _itemsByType[(int)GenerateItemType.Any_Weapon].Add(item.Key);
                    }
                    else if (item.Value.ItemType == ItemType.Backpack || item.Value.ItemType == ItemType.Cloak ||
                        item.Value.ItemType == ItemType.Finger || item.Value.ItemType == ItemType.Foot_Armor || item.Value.ItemType == ItemType.Hand_Armor || item.Value.ItemType == ItemType.Head_Armor ||
                        item.Value.ItemType == ItemType.Armor || item.Value.ItemType == ItemType.Necklace)
                    {
                        _itemsByType[(int)GenerateItemType.Any_Armor].Add(item.Key);
                    }
                    else if (item.Value.ItemType == ItemType.Bomb || item.Value.ItemType == ItemType.Drink || item.Value.ItemType == ItemType.Food || item.Value.ItemType == ItemType.Potion ||
                             item.Value.ItemType == ItemType.Scroll || item.Value.ItemType == ItemType.Spellbook)
                    {
                        _itemsByType[(int)GenerateItemType.Any_Accessory].Add(item.Key);
                    }
                    else if (item.Value.ItemType == ItemType.Shield)
                    {
                        _itemsByType[(int)GenerateItemType.Any_Shield].Add(item.Key);
                    }
                }
            }
        }
    }
}
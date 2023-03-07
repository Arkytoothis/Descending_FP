using System.Collections;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using Descending.Attributes;
using Descending.Core;
using Descending.Units;
using UnityEngine;

namespace Descending.Equipment
{
    public class InventoryController : MonoBehaviour
    {
        public const int MAX_ACCESSORY_SLOTS = 6;
        
        [SerializeField] private AttributesController _attributes = null;
        [SerializeField] private Item[] _equipment = null;
        [SerializeField] private Item[] _accessories = null;
        
        [SerializeField] private int _accessorySlots = 2;
        [SerializeField] private BodyRenderer _portraitBody = null;
        [SerializeField] private BodyRenderer _worldBody = null;

        private Genders _gender = Genders.None;
        [SerializeField] private Item _currentWeapon = null;
        
        public Item[] Equipment => _equipment;
        public Item[] Accessories => _accessories;
        public int AccessorySlots => _accessorySlots;

        public void Setup(BodyRenderer portraitBody, BodyRenderer worldBody, Genders gender, RaceDefinition race, ProfessionDefinition profession)
        {
            _portraitBody = portraitBody;
            _worldBody = worldBody;
            _gender = gender;
            _equipment = new Item[(int) EquipmentSlots.Number];
            _accessories = new Item[MAX_ACCESSORY_SLOTS];
            
            for (int i = 0; i < (int)EquipmentSlots.Number; i++)
            {
                _equipment[i] = null;
            }
        
            for (int i = 0; i < MAX_ACCESSORY_SLOTS; i++)
            {
                _accessories[i] = null;
            }
            
            for (int i = 0; i < profession.StartingItems.Count; i++)
            {
                Item item = ItemGenerator.GenerateItem(profession.StartingItems[i]);

                if (item.ItemDefinition.ItemType == ItemType.Potion || item.ItemDefinition.ItemType == ItemType.Scroll || item.ItemDefinition.ItemType == ItemType.Bomb ||
                    item.ItemDefinition.ItemType == ItemType.Spellbook || item.ItemDefinition.ItemType == ItemType.Food || item.ItemDefinition.ItemType == ItemType.Drink)
                {
                    EquipAccessory(item);
                }
                else
                {
                    EquipItem(item);
                }
            }
        
            if (profession.PrefersRanged == false)
            {
                if (_portraitBody != null)
                {
                    _portraitBody.EquipWeapon(_equipment[(int) EquipmentSlots.Melee_Weapon], true);
                    _portraitBody.EquipWeapon(_equipment[(int) EquipmentSlots.Off_Weapon], true);
                }

                if (_worldBody != null)
                {
                    _worldBody.EquipWeapon(_equipment[(int) EquipmentSlots.Melee_Weapon], false);
                    _worldBody.EquipWeapon(_equipment[(int) EquipmentSlots.Off_Weapon], false);
                }

                _currentWeapon = _equipment[(int) EquipmentSlots.Melee_Weapon];
            }
            else
            {
                if (_worldBody != null)
                {
                    _worldBody.EquipWeapon(_equipment[(int) EquipmentSlots.Ranged_Weapon], false);
                }
                
                if (_portraitBody != null)
                {
                    _portraitBody.EquipWeapon(_equipment[(int) EquipmentSlots.Ranged_Weapon], true);
                }

                _currentWeapon = _equipment[(int) EquipmentSlots.Ranged_Weapon];
            }
        }

        public void Setup(EnemyDefinition enemyDefinition)
        {
            _portraitBody = null;
            _worldBody = null;
            _gender = Genders.Male;
            _equipment = new Item[(int) EquipmentSlots.Number];
            _accessories = new Item[MAX_ACCESSORY_SLOTS];
            
            for (int i = 0; i < (int)EquipmentSlots.Number; i++)
            {
                _equipment[i] = null;
            }
        
            for (int i = 0; i < MAX_ACCESSORY_SLOTS; i++)
            {
                _accessories[i] = null;
            }
            
            if(enemyDefinition.MeleeWeapon != null)
                EquipItem(ItemGenerator.GenerateItem(enemyDefinition.MeleeWeapon));
            if(enemyDefinition.RangedWeapon != null)
                EquipItem(ItemGenerator.GenerateItem(enemyDefinition.RangedWeapon));
        }

        public void LoadData(BodyRenderer worldBody, BodyRenderer portraitBody, HeroSaveData saveData)
        {
            _worldBody = worldBody;
            _portraitBody = portraitBody;
            _gender = saveData.Gender;
            _equipment = new Item[saveData.InventorySaveData.EquippedItems.Length];
            _accessories = new Item[saveData.InventorySaveData.Accessories.Length];
            
            for (int i = 0; i < saveData.InventorySaveData.EquippedItems.Length; i++)
            {
                _equipment[i] = new Item(saveData.InventorySaveData.EquippedItems[i]);
            }
        
            for (int i = 0; i < saveData.InventorySaveData.Accessories.Length; i++)
            {
                _accessories[i] = new Item(saveData.InventorySaveData.Accessories[i]);
            }
            
            for (int i = 0; i < saveData.InventorySaveData.EquippedItems.Length; i++)
            {
                if (saveData.InventorySaveData.EquippedItems[i].Key == "" || saveData.InventorySaveData.EquippedItems[i].ItemDefinition.Key == "") continue;
                
                EquipItem(saveData.InventorySaveData.EquippedItems[i]);
            }

            ProfessionDefinition profession = Database.instance.Profession.GetProfession(saveData.ProfessionKey);
            
            if (profession.PrefersRanged == false)
            {
                if (_portraitBody != null)
                {
                    _portraitBody.EquipWeapon(_equipment[(int) EquipmentSlots.Melee_Weapon], true);
                    _portraitBody.EquipWeapon(_equipment[(int) EquipmentSlots.Off_Weapon], true);
                }

                if (_worldBody != null)
                {
                    _worldBody.EquipWeapon(_equipment[(int) EquipmentSlots.Melee_Weapon], false);
                    _worldBody.EquipWeapon(_equipment[(int) EquipmentSlots.Off_Weapon], false);
                }

                _currentWeapon = _equipment[(int) EquipmentSlots.Melee_Weapon];
            }
            else
            {
                if (_worldBody != null)
                {
                    _worldBody.EquipWeapon(_equipment[(int) EquipmentSlots.Ranged_Weapon], false);
                }
                
                if (_portraitBody != null)
                {
                    _portraitBody.EquipWeapon(_equipment[(int) EquipmentSlots.Ranged_Weapon], true);
                }

                _currentWeapon = _equipment[(int) EquipmentSlots.Ranged_Weapon];
            }
        }
        
        public void EquipItem(Item item)
        {
            if (_equipment[(int) item.ItemDefinition.EquipmentSlot] == null)
            {
                _equipment[(int) item.ItemDefinition.EquipmentSlot] = new Item(item);

                if (_portraitBody != null)
                {
                    _portraitBody.EquipItem(item, true);
                }

                if (_worldBody != null)
                {
                    _worldBody.EquipItem(item, false);
                }
            }
            else
            {
                _equipment[(int) item.ItemDefinition.EquipmentSlot] = new Item(item);
                if (_portraitBody != null)
                {
                    _portraitBody.EquipItem(item, true);
                }

                if (_worldBody != null)
                {
                    _worldBody.EquipItem(item, false);
                }
            }
            
            _attributes.CalculateAttributes();
        }

        public void EquipItem(Item item, int slot)
        {
            //MasterAudio.PlaySound(item.ItemDefinition.EquipSound);
            
            _equipment[slot] = new Item(item);
            
            if (_portraitBody != null)
            {
                _portraitBody.EquipItem(item, true);
            }

            if (_worldBody != null)
            {
                _worldBody.EquipItem(item, false);
            }
            
            _attributes.CalculateAttributes();
        }

        public void EquipAccessory(Item item)
        {
            //MasterAudio.PlaySound(item.ItemDefinition.EquipSound);
            
            int index = -1;
            for (int i = 0; i < _accessories.Length; i++)
            {
                if (_accessories[i] == null)
                {
                    index = i;
                    break;
                }
            }

            _accessories[index] = new Item(item);
        }
        
        public void EquipAccessory(Item item, int slot)
        {
            //MasterAudio.PlaySound(item.ItemDefinition.EquipSound);
            _accessories[slot] = new Item(item);
        }

        public void UnequipItem(int slot, bool addToStockpile)
        {
            //MasterAudio.PlaySound(_equipment[slot].ItemDefinition.UnequipSound);
            
            if (_portraitBody != null)
            {
                _portraitBody.UnequipItem(_equipment[slot], slot);
            }

            if (_worldBody != null)
            {
                _worldBody.UnequipItem(_equipment[slot], slot);
            }

            if (addToStockpile == true)
            {
                StockpileManager.Instance.AddItem(_equipment[slot]);
            }
            
            _equipment[slot] = null;
            
            _attributes.CalculateAttributes();
        }
        
        public void UnequipAccessory(int slot)
        {
            //MasterAudio.PlaySound(_equipment[slot].ItemDefinition.UnequipSound);
            StockpileManager.Instance.AddItem(_accessories[slot]);
            _accessories[slot] = null;
        }

        public void ClearAccessory(int slot)
        {
            _accessories[slot] = null;
        }
        
        public Item GetCurrentWeapon()
        {
            return _currentWeapon;
        }
        
        public Item GetMeleeWeapon()
        {
            return _equipment[(int) EquipmentSlots.Melee_Weapon];
        }

        public Item GetRangedWeapon()
        {
            return _equipment[(int) EquipmentSlots.Ranged_Weapon];
        }

        public Item GetOffhandItem()
        {
            return _equipment[(int) EquipmentSlots.Off_Weapon];
        }

        public Item GetAmmo()
        {
            return _equipment[(int) EquipmentSlots.Ammo];
        }

        public void PlayStepSound()
        {
            string sound = _equipment[(int)EquipmentSlots.Feet].GetWearableData().GetStepSound();
            
            if (sound != "")
            {
                //MasterAudio.PlaySound3DAtVector3(sound, _worldBody.transform.position, 0.01f);
            }
        }

        public void TryEquipMelee()
        {
            //if (_equipment[(int)EquipmentSlots.Melee_Weapon].IsEmpty() == false)
            //{
                _currentWeapon = _equipment[(int)EquipmentSlots.Melee_Weapon];
            //}
        }

        public void TryEquipRanged()
        {
            //if (_equipment[(int)EquipmentSlots.Ranged_Weapon].IsEmpty() == false)
            //{
                _currentWeapon = _equipment[(int)EquipmentSlots.Ranged_Weapon];
            //}
        }
    }

    [System.Serializable]
    public class InventorySaveData
    {
        [SerializeField] private Item[] _equippedItems = null;
        [SerializeField] private Item[] _accessories = null;
        [SerializeField] private int _accessorySlots = 0;

        public Item[] EquippedItems => _equippedItems;
        public Item[] Accessories => _accessories;
        public int AccessorySlots => _accessorySlots;

        public InventorySaveData(Hero hero)
        {
             _accessorySlots = hero.Inventory.AccessorySlots;
             _equippedItems = new Item[hero.Inventory.Equipment.Length];
             _accessories = new Item[hero.Inventory.Accessories.Length];
            
             for (int i = 0; i < hero.Inventory.Equipment.Length; i++)
             {
                 _equippedItems[i] = new Item(hero.Inventory.Equipment[i]);
             }
            
             for (int i = 0; i < hero.Inventory.Accessories.Length; i++)
             {
                 _accessories[i] = new Item(hero.Inventory.Accessories[i]);
             }
        }
    }
}
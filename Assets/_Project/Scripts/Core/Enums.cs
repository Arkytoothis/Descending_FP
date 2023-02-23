using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Core
{
    public enum Genders
    {
        Male, Female,
        Number, None
    }
    
    public enum EquipmentSlots
    {
        Melee_Weapon, Off_Weapon, Ranged_Weapon, Ammo, Head, Torso, Back, Wrists, Hands, Legs, Feet, Neck, Finger_Left, Finger_Right,
        Number, None
    }
    
    public enum SkillCategory
    {
        Combat, Magic, Utility,
        Number, None
    }

    public enum ItemType
    {
        Head_Armor, Backpack, Cloak, Armor, Leg_Armor, Wrist_Armor, Hand_Armor, Foot_Armor, 
        Finger, Necklace,
        Shield,
        Ammo,
        Sword, Axe, Dagger, Hammer, Mace, Staff, Scepter, Polearm, Firearm, Instrument, Bow,
        Potion, Drink, Food, Bomb, Scroll, Spellbook,
        Ingredient, 
        Number, None
    }
    public enum GenerateItemType
    {
        Head_Armor, Backpack, Cloak, Armor, Leg_Armor, Wrist_Armor, Hand_Armor, Foot_Armor, 
        Finger, Necklace,
        Shield,
        Ammo,
        Sword, Axe, Dagger, Hammer, Mace, Staff, Scepter, Polearm, Firearm, Instrument, Bow,
        Potion, Drink, Food, Bomb, Scroll, Spellbook,
        Ingredient,
        Any, Any_Weapon, Any_Armor, Any_Shield, Any_Accessory,
        Number, None
    }

    public enum ItemNameFormat
    {
        Material_First, Material_Middle, Material_Last,
        Number, None
    }

    public enum ItemMaterialAllowed
    {
        Any, Hard, Soft, Wood, Stone, Metal, Cloth, Leather, Food, Drink, Potion, Paper, Book,
        Number, None
    }

    public enum Hands
    {
        Left, Right, Both, Either,
        Number, None
    }
    
    public enum AccessoryType
    {
        Food, Drink, Potion, Scroll, Spellbook, Bomb,
        Number, None
    }
    
    public enum ItemCategory { Accessories, Ammo, Ingredient, Shields, Weapons, Wearable, Number, None }


    public enum ItemMaterialType
    {
        Leather, Cloth, Wood, Stone, Metal, Organic, Food, Drink, Potion, Paper, Book,
        Number, None
    }

    public enum EnchantmentType
    {
        Quality, Prefix, Suffix,
        Number, None
    }
    
    public enum WearableType
    {
        Head, Armor, Wrists, Gloves, Legs, Feet, Back, Neck, Finger, 
        Number, None
    }

    public enum HeadCoverType
    {
        Full_Head, Hair, No_Hair, No_Facial_Hair,
        Number, None
    }

    public enum EnchantmentUsability
    {
        Permanent, Usable,
        Number, None
    }

    public enum GameScenes
    {
        Main_Menu, Overworld, Combat_Outdoor, Combat_Indoor,
        Number, None
    }
    
    public enum AbilityEffectType
    {
        Buff_Attribute, Buff_Skill, Damage, Damage_Over_Time, Debuff_Attribute, Debuff_Skill, Restore, Restore_Over_Time, Stun, Taunt, Weapon_Attack, Projectile,
        Number, None
    }

    public enum AbilityEffectAffects
    {
        User, Target, Both,
        Number, None
    }

    public enum AbilityType
    {
        Power, Spell, Trait, Number, None
    }

    public enum CanUseAbilityResult
    {
        Can_Use_Ability, Cannot_Use_Ability_Actions, Cannot_Use_Ability_Range, Cannot_Use_Ability_Resource,
        Number, None
    }

    public enum AbilityTryResultType
    {
        Can_Use, Cannot_Use_Resource, Cannot_Use_Wrong_Mode,
        Number, None
    }
    
    public enum SpellSchoolType
    {
        Fire, Air, Water, Earth, Life, Death, Order, Chaos, Number, None
    }

    public enum DurationType
    { 
        Instant, Permanent, Seconds, Number, None 
    }

    public enum TargetTypes
    { 
        Any, Party, Self, Friend, Enemy, Ground, Number, None 
    }

    public enum AreaTypes
    { 
        Single, Party, Group, Sphere, Rectangle, Cone, Beam, Number, None 
    }

    public enum EnemyGroups
    {
        Goblinoid, Undead, Viking, Bandit,
        Number, None
    }
    
    public enum EncounterDifficulties
    {
        Easy, Standard, Hard, Overseer, Boss, Random,
        Number, None
    }

    public enum DamageClasses
    {
        Might, Finesse, Magic, 
        Number, None
    }
    
    public enum WeaponTypes
    {
        Melee, Ranged, Magic, Number, None
    }

    public enum UsableTypes
    {
        Potion, Scroll, Bomb, Spellbook, Food, Drink,
        Number, None
    }

    public enum AttributeTypes
    {
        Characteristic, Vital, Statistic, Resistance,
        Number, None
    }

    public enum DungeonTypes
    {
        Crypt, Forest, Goblin_Village,
        Number, None
    }
}
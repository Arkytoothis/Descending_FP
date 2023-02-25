using System.Collections;
using System.Collections.Generic;
using Descending.Abilities;
using Descending.Attributes;
using Descending.Core;
using Descending.Equipment;
using UnityEngine;

namespace Descending.Units
{
    [System.Serializable]
    public class HeroSaveData
    {
        [SerializeField] private FantasyName _name = new FantasyName();
        [SerializeField] private Genders _gender = Genders.None;
        [SerializeField] private string _raceKey = "";
        [SerializeField] private string _professionKey = "";
        [SerializeField] private int _level = 0;
        [SerializeField] private int _experience = 0;
        [SerializeField] private int _expToNextLevel = 0;
        
        [SerializeField] private int _listIndex = -1;
        [SerializeField] private int _headIndex = -1;
        [SerializeField] private int _hairIndex = -1;
        [SerializeField] private int _earIndex = -1;
        [SerializeField] private int _facialHairIndex = -1;
        [SerializeField] private int _eyebrowIndex = -1;
        [SerializeField] private int _skinColorIndex = -1;
        [SerializeField] private int _tattooColorIndex = -1;
        [SerializeField] private int _hairColorIndex = -1;
        [SerializeField] private int _eyeColorIndex = -1;
        
        [SerializeField] private AttributesSaveData _attributesSaveData = null;
        [SerializeField] private SkillsSaveData _skillsSaveData = null;
        [SerializeField] private InventorySaveData _inventorySaveData = null;
        [SerializeField] private AbilitySaveData _abilitySaveData = null;
        
        public FantasyName Name => _name;
        public Genders Gender => _gender;
        public string RaceKey => _raceKey;
        public string ProfessionKey => _professionKey;
        public int Level => _level;
        public int Experience => _experience;
        public int ExpToNextLevel => _expToNextLevel;
        public int ListIndex => _listIndex;
        public int HeadIndex => _headIndex;
        public int HairIndex => _hairIndex;
        public int EarIndex => _earIndex;
        public int FacialHairIndex => _facialHairIndex;
        public int EyebrowIndex => _eyebrowIndex;
        public int SkinColorIndex => _skinColorIndex;
        public int HairColorIndex => _hairColorIndex;
        public int EyeColorIndex => _eyeColorIndex;
        public int TattooColorIndex => _tattooColorIndex;

        public AttributesSaveData AttributesSaveData => _attributesSaveData;
        public SkillsSaveData SkillsSaveData => _skillsSaveData;
        public InventorySaveData InventorySaveData => _inventorySaveData;
        public AbilitySaveData AbilitySaveData => _abilitySaveData;

        public HeroSaveData()
        {
            _name = new FantasyName();
            _gender = Genders.None;
            _raceKey = "";
            _professionKey = "";
            _level = 0;
            _experience = 0;
            _expToNextLevel = 0;
            
            _listIndex = -1;
            _headIndex = -1;
            _hairIndex = -1;
            _earIndex = -1;
            _facialHairIndex = -1;
            _eyebrowIndex = -1;
            _skinColorIndex = -1;
            _tattooColorIndex = -1;
            _hairColorIndex = -1;
            _eyeColorIndex = -1;
            _attributesSaveData = null;
            _skillsSaveData = null;
            _inventorySaveData = null;
            _abilitySaveData = null;
        }

        public HeroSaveData(Hero hero)
        {
            _name = new FantasyName(hero.HeroData.Name);
            _gender = hero.HeroData.Gender;
            _raceKey = hero.HeroData.RaceKey;
            _professionKey = hero.HeroData.ProfessionKey;
            _level = hero.HeroData.Level;
            _experience = hero.HeroData.Experience;
            _expToNextLevel = hero.HeroData.ExpToNextLevel;
            
            _listIndex = hero.HeroData.ListIndex;
            _headIndex = hero.HeroData.HeadIndex;
            _hairIndex = hero.HeroData.HairIndex;
            _earIndex = hero.HeroData.EarIndex;
            _facialHairIndex = hero.HeroData.FacialHairIndex;
            _eyebrowIndex = hero.HeroData.EyebrowIndex;
            _skinColorIndex = hero.HeroData.SkinColorIndex;
            _tattooColorIndex = hero.HeroData.TattooColorIndex;
            _hairColorIndex = hero.HeroData.HairColorIndex;
            _eyeColorIndex = hero.HeroData.EyeColorIndex;

            _attributesSaveData = new AttributesSaveData(hero);
            _skillsSaveData = new SkillsSaveData(hero);
            _inventorySaveData = new InventorySaveData(hero);
            _abilitySaveData = new AbilitySaveData(hero);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Equipment;
using Descending.Units;
using UnityEngine;
using UnityEngine.Serialization;

namespace Descending.Attributes
{
    public enum ProfessionArchtypes { Fighter, Rogue, Caster, Number, None }
    
    [CreateAssetMenu(fileName = "Profession Definition", menuName = "Descending/Definition/Profession Definition")]
    public class ProfessionDefinition : ScriptableObject
	{
        [SerializeField] private bool _unlocked = false;
        [SerializeField] private ProfessionArchtypes _archtype = ProfessionArchtypes.None;
        [SerializeField] private string _key = "";
        [SerializeField] private string _nameMale = "";
        [SerializeField] private string _nameFemale = "";
        [SerializeField] private Sprite _icon = null;
        [SerializeField] private StartingCharacteristicDictionary _startingCharacteristics = null;
        [SerializeField] private StartingVitalDictionary _startingVitals = null;
        [SerializeField] private StartingStatisticDictionary _startingStatistic = null;
        [SerializeField] private StartingSkillDictionary _startingSkills = null;
        [SerializeField] private List<ItemShort> _startingItems = null;

        [SerializeField] private int _attributePointsPerLevel = 0;
        [SerializeField] private int _skillPointsPerLevel = 0;
        [SerializeField] private float _mightModifier = 1f;
        [SerializeField] private float _finesseModifier = 1f;
        [SerializeField] private float _spellModifier = 1f;
        [SerializeField] private bool _prefersRanged = false;
        [SerializeField] private HeroCombatModes _defaultCombatMode = HeroCombatModes.Unarmed;

        public bool Unlocked => _unlocked;
        public ProfessionArchtypes Archtype => _archtype;
        public string Key => _key;
        public string NameMale => _nameMale;
        public string NameFemale => _nameFemale;
        public Sprite Icon => _icon;
        public StartingCharacteristicDictionary StartingCharacteristics => _startingCharacteristics;
        public StartingVitalDictionary StartingVitals => _startingVitals;
        public StartingStatisticDictionary StartingStatistic => _startingStatistic;
        public StartingSkillDictionary StartingSkills => _startingSkills;
        public List<ItemShort> StartingItems => _startingItems;
        public int AttributePointsPerLevel => _attributePointsPerLevel;
        public int SkillPointsPerLevel => _skillPointsPerLevel;
        public float MightModifier => _mightModifier;
        public float FinesseModifier => _finesseModifier;
        public float SpellModifier => _spellModifier;
        public bool PrefersRanged => _prefersRanged;
        public HeroCombatModes DefaultCombatMode => _defaultCombatMode;

        public string GetGenderName(Genders gender)
        {
            string s = "";

            if (gender == Genders.Male)
            {
                s = _nameMale;
            }
            else if (gender == Genders.Female)
            {
                s = _nameFemale;
            }

            return s;
        }
    }
}
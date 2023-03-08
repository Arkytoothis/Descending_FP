using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using UnityEngine;

namespace Descending.Attributes
{
    [CreateAssetMenu(fileName = "Race Definition", menuName = "Descending/Definition/Race Definition")]
	public class RaceDefinition : ScriptableObject
	{
        [SerializeField] private bool _unlocked = false;
        [SerializeField] private GameObject _prefabMale = null;
        [SerializeField] private GameObject _prefabFemale = null;
        [SerializeField] private string _key = "";
        [SerializeField] private string _name = "";
        [SerializeField] private Sprite _icon = null;
        [SerializeField] private ParticleSystem _hitEffect = null;
        
        [SerializeField] private int _earIndex = 0;
        [SerializeField] private bool _hairAllowed = true;
        [SerializeField] private bool _eyebrowsAllowed = true;
        [SerializeField] private int _maleBeardChance = 75;
        [SerializeField] private int _femaleBeardChance = 75;
        [SerializeField] private List<Color> _skinColors = null;
        [SerializeField] private List<Color> _eyeColors = null;
        [SerializeField] private List<Color> _hairColors = null;
        [SerializeField] private List<Color> _tattooColors = null;
        [SerializeField] private List<Color> _scarColors = null;
        [SerializeField] private List<Color> _stubbleColors = null;
        
        [SerializeField] private float _expModifier = 1f;
        
        [SerializeField] private StartingCharacteristicDictionary _startingCharacteristics = null;
        [SerializeField] private StartingVitalDictionary _startingVitals = null;
        [SerializeField] private StartingStatisticDictionary _startingStatistics = null;
        [SerializeField] private StartingSkillDictionary _startingSkills = null;
        [SerializeField] private List<Resistance> _resistances = null;

        //[SoundGroup, SerializeField] private List<string> SelectSoundsFemale;
        //[SoundGroup, SerializeField] private List<string> SelectSoundsMale;
        //[SoundGroupAttribute] public List<string> AttackSoundsFemale;
        //[SoundGroupAttribute] public List<string> HitSoundsMale;
        //[SoundGroupAttribute] public List<string> HitSoundsFemale;
        //[SoundGroup] public List<string> WoundSoundsMale;
        //[SoundGroup] public List<string> WoundSoundsFemale;
        public StartingCharacteristicDictionary StartingCharacteristics => _startingCharacteristics;
        public StartingVitalDictionary StartingVitals => _startingVitals;
        public StartingStatisticDictionary StartingStatistics => _startingStatistics;
        public StartingSkillDictionary StartingSkills => _startingSkills;
        public List<Resistance> Resistances => _resistances;
        public bool Unlocked { get => _unlocked; set => _unlocked = value; }
        public int MaleBeardChance => _maleBeardChance;
        public int FemaleBeardChance => _femaleBeardChance;
        public GameObject PrefabMale => _prefabMale;
        public GameObject PrefabFemale => _prefabFemale;
        public ParticleSystem HitEffect => _hitEffect;

        public string Key
        {
            get => _key;
            set => _key = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int EarIndex => _earIndex;
        public bool HairAllowed => _hairAllowed;
        public bool EyebrowsAllowed => _eyebrowsAllowed;
        public List<Color> SkinColors => _skinColors;
        public List<Color> EyeColors => _eyeColors;
        public List<Color> ScarColors => _scarColors;
        public List<Color> StubbleColors => _stubbleColors;
        public List<Color> HairColors => _hairColors;
        public List<Color> TattooColors => _tattooColors;
        public Sprite Icon => _icon;
        public float ExpModifier => _expModifier;

        // public string GetSelectSound(Genders gender)
        // {
        //     if(gender == Genders.Male)
        //         return SelectSoundsMale[Random.Range(0, SelectSoundsMale.Count)];
        //     else
        //         return SelectSoundsFemale[Random.Range(0, SelectSoundsFemale.Count)];
        // }

        // public string GetWoundSound(Genders gender)
        // {
        //     if(gender == Genders.Male)
        //         return WoundSoundsMale[Random.Range(0, WoundSoundsMale.Count)];
        //     else
        //         return WoundSoundsFemale[Random.Range(0, WoundSoundsFemale.Count)];
        // }
    }
}
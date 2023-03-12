using Descending.Abilities;
using Descending.Attributes;
using Descending.Combat;
using Descending.Equipment;
using Descending.Equipment.Enchantments;
using Descending.Features;
using Descending.Units;
using Sirenix.OdinInspector;
using UnityEditor.UIElements;
using UnityEngine;

namespace Descending.Core
{
    [CreateAssetMenu(menuName = "Descending/Database/Database")]
    public class Database : SingletonScriptableObject<Database>
    {
        [SerializeField] private AbilityDatabase _abilities = null;
        [SerializeField] private AttributeDatabase _attributes = null;
        [SerializeField] private SkillDatabase _skills = null;
        [SerializeField] private RaceDatabase _races = null;
        [SerializeField] private ProfessionDatabase _profession = null;
        [SerializeField] private DamageTypeDatabase _damageTypes = null;
        [SerializeField] private ItemDatabase _items = null;
        [SerializeField] private MaterialDatabase _materials = null;
        [SerializeField] private EnchantmentDatabase _enchants = null;
        [SerializeField] private RarityDatabase _rarities = null;
        [SerializeField] private FeatureDatabase _features = null;
        [SerializeField] private EnemyDatabase _enemies = null;

        [SerializeField] private string _sceneLoadFilePath = "";
        [SerializeField] private string _partyDataFilePath = "";
        [SerializeField] private string _resourcesDataFilePath = "";
        [SerializeField] private string _stockpileDataFilePath = "";
        [SerializeField] private string _overworldEncounterDataFilePath = "";
        [SerializeField] private string _undergroundEncounterDataFilePath = "";
        [SerializeField] private Sprite _blankSprite = null;
        
        [SerializeField] private LayerMask _groundMask = new LayerMask();


        private bool _initialized = false;

        public AbilityDatabase Abilities => _abilities;
        public AttributeDatabase Attributes => _attributes;
        public SkillDatabase Skills => _skills;
        public RaceDatabase Races => _races;
        public ProfessionDatabase Profession => _profession;
        public DamageTypeDatabase DamageTypes => _damageTypes;
        public ItemDatabase Items => _items;
        public MaterialDatabase Materials => _materials;
        public EnchantmentDatabase Enchants => _enchants;
        public RarityDatabase Rarities => _rarities;
        public FeatureDatabase Features => _features;
        public EnemyDatabase Enemies => _enemies;
        public Sprite BlankSprite => _blankSprite;
        public string SceneLoadFilePath => _sceneLoadFilePath;
        public string PartyDataFilePath => _partyDataFilePath;
        public string ResourcesDataFilePath => _resourcesDataFilePath;
        public string StockpileDataFilePath => _stockpileDataFilePath;
        public string OverworldEncounterDataFilePath => _overworldEncounterDataFilePath;
        public string UndergroundEncounterDataFilePath => _undergroundEncounterDataFilePath;

        public LayerMask GroundMask => _groundMask;

        public void Setup()
        {
            if (_initialized == true) return;

            _initialized = true;
            LoadPaths();
        }

        [Button("Load Paths")]
        private void LoadPaths()
        {
            _sceneLoadFilePath = Application.streamingAssetsPath + "/SaveData/scene_load_data.dat";
            _partyDataFilePath = Application.streamingAssetsPath + "/SaveData/party_data.dat";
            _resourcesDataFilePath = Application.streamingAssetsPath + "/SaveData/resources_data.dat";
            _stockpileDataFilePath = Application.streamingAssetsPath + "/SaveData/stockpile_data.dat";
            _overworldEncounterDataFilePath = Application.streamingAssetsPath + "/SaveData/overworld_encounter_data.dat";
            _undergroundEncounterDataFilePath = Application.streamingAssetsPath + "/SaveData/underground_encounter_data.dat";
            // _timeDataFilePath = Application.streamingAssetsPath + "/SaveData/time_data.dat";
            // _overworldSpawnFilePath = Application.streamingAssetsPath + "/SaveData/overworld_spawn.dat";
            // _worldDataFilePath = Application.streamingAssetsPath + "/SaveData/world_data.dat";
        }

        public string GetEncounterDataFilePath(GameScenes currentScene)
        {
            if (currentScene == GameScenes.Overworld)
                return _overworldEncounterDataFilePath;
            else if (currentScene == GameScenes.Underground)
                return _undergroundEncounterDataFilePath;
            else
                return "";
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Equipment;
using Descending.Equipment.Enchantments;
using Descending.Units;
using UnityEngine;

namespace Descending.Attributes
{
    public class AttributesController : MonoBehaviour
    {
        [SerializeField] private UnitEffects _unitEffects = null;
        [SerializeField] private InventoryController _inventory = null;
        [SerializeField] private AttributeDictionary _characteristics = null;
        [SerializeField] private AttributeDictionary _vitals = null;
        [SerializeField] private AttributeDictionary _statistics = null;
        [SerializeField] private ResistanceDictionary _resistances = null;

        private RaceDefinition _raceDefinition = null;
        private ProfessionDefinition _professionDefinition = null;
        
        public AttributeDictionary Characteristics => _characteristics;
        public AttributeDictionary Vitals => _vitals;
        public AttributeDictionary Statistics => _statistics;
        public ResistanceDictionary Resistances => _resistances;

        public void Setup(RaceDefinition race, ProfessionDefinition profession)
        {
            _raceDefinition = race;
            _professionDefinition = profession;
            
            _characteristics.Clear();
            _vitals.Clear();
            _statistics.Clear();
            _resistances.Clear();
            
            foreach (var startingAttribute in race.StartingCharacteristics)
            {
                int value = Random.Range(startingAttribute.Value.MinimumValue, startingAttribute.Value.MaximumValue + 1);
                _characteristics.Add(startingAttribute.Key, new Attribute(startingAttribute.Key));
                _characteristics[startingAttribute.Key].Setup(value);
            }
            
            foreach (var startingAttribute in profession.StartingCharacteristics)
            {
                int value = Random.Range(startingAttribute.Value.MinimumValue, startingAttribute.Value.MaximumValue + 1);
                _characteristics[startingAttribute.Key].AddValue(value);
            }

            foreach (var kvp in Database.instance.Attributes.Vitals)
            {
                _vitals.Add(kvp.Key, new Attribute(kvp.Key));
            }

            foreach (var kvp in Database.instance.Attributes.Statistics)
            {
                _statistics.Add(kvp.Key, new Attribute(kvp.Key));
            }
            
            foreach (var damageTypeKVP in Database.instance.DamageTypes.Data)
            {
                _resistances.Add(damageTypeKVP.Key, new Resistance(damageTypeKVP.Value, 0));
            }

            foreach (Resistance raceResistance in race.Resistances)
            {
                _resistances[raceResistance.DamageType].SetResistance(raceResistance);
            }
        }
        
        public void Setup(EnemyDefinition definition)
        {
            _characteristics.Clear();
            _vitals.Clear();
            _statistics.Clear();
            
            foreach (var startingVital in definition.StartingVitals)
            {
                int value = Random.Range(startingVital.Value.MinimumValue, startingVital.Value.MaximumValue + 1);
                _vitals.Add(startingVital.Key, new Attribute(startingVital.Key));
                _vitals[startingVital.Key].Setup(value);
            }

            foreach (var startingStatistic in definition.StartingStatistics)
            {
                int value = Random.Range(startingStatistic.Value.MinimumValue, startingStatistic.Value.MaximumValue + 1);
                _statistics.Add(startingStatistic.Key, new Attribute(startingStatistic.Key));
                _statistics[startingStatistic.Key].Setup(value);
            }
        }

        private void ResetModifiers()
        {
            foreach (KeyValuePair<string,Attribute> kvp in _characteristics)
            {
                kvp.Value.ResetModifier();
            }
            
            foreach (KeyValuePair<string,Attribute> kvp in _vitals)
            {
                kvp.Value.ResetModifier();
            }
            
            foreach (KeyValuePair<string,Attribute> kvp in _statistics)
            {
                kvp.Value.ResetModifier();
            }
        }
        
        public void CalculateAttributes()
        {
            ResetModifiers();
            CalculateCharacteristicModifiers();
            
            _vitals["Life"].Setup(Random.Range(_raceDefinition.StartingVitals["Life"].MinimumValue, _raceDefinition.StartingVitals["Life"].MinimumValue + 1) + 
                                  (_characteristics["Endurance"].Maximum + _characteristics["Might"].Maximum) / 2);
            _vitals["Stamina"].Setup(Random.Range(_raceDefinition.StartingVitals["Stamina"].MinimumValue, _raceDefinition.StartingVitals["Stamina"].MinimumValue + 1) + 
                                  (_characteristics["Endurance"].Maximum + _characteristics["Spirit"].Maximum) / 2);
            _vitals["Magic"].Setup(Random.Range(_raceDefinition.StartingVitals["Magic"].MinimumValue, _raceDefinition.StartingVitals["Magic"].MinimumValue + 1) + 
                                  (_characteristics["Intellect"].Maximum + _characteristics["Spirit"].Maximum) / 2);
            
            _vitals["Actions"].Setup(Random.Range(_raceDefinition.StartingVitals["Actions"].MinimumValue, _raceDefinition.StartingVitals["Actions"].MinimumValue + 1));
            _vitals["Armor"].Setup(Random.Range(_raceDefinition.StartingVitals["Armor"].MinimumValue, _raceDefinition.StartingVitals["Armor"].MinimumValue + 1));
            _vitals["Luck"].Setup(Random.Range(_raceDefinition.StartingVitals["Luck"].MinimumValue, _raceDefinition.StartingVitals["Luck"].MinimumValue + 1));

            CalculateVitalModifiers();
            
            int mightAttack = _characteristics["Might"].Maximum + _characteristics["Finesse"].Maximum;
            int finesseAttack = _characteristics["Finesse"].Maximum + _characteristics["Senses"].Maximum;
            int magicAttack = _characteristics["Intellect"].Maximum + _characteristics["Spirit"].Maximum;
            
            _statistics["Might Attack"].Setup(mightAttack + Random.Range(_raceDefinition.StartingStatistics["Might Attack"].MinimumValue, _raceDefinition.StartingStatistics["Might Attack"].MaximumValue + 1));
            _statistics["Finesse Attack"].Setup(finesseAttack + Random.Range(_raceDefinition.StartingStatistics["Finesse Attack"].MinimumValue, _raceDefinition.StartingStatistics["Finesse Attack"].MaximumValue + 1));
            _statistics["Magic Attack"].Setup(magicAttack + Random.Range(_raceDefinition.StartingStatistics["Magic Attack"].MinimumValue, _raceDefinition.StartingStatistics["Magic Attack"].MaximumValue + 1));
            
            int mightDamage = (_characteristics["Might"].Maximum - 10) / 10;
            int finesseDamage = (_characteristics["Finesse"].Maximum - 10) / 10;
            int magicDamage = ((_characteristics["Intellect"].Maximum - 10) + (_characteristics["Spirit"].Maximum - 10)) / 10;
            
            _statistics["Might Modifier"].Setup(mightDamage + Random.Range(_raceDefinition.StartingStatistics["Might Modifier"].MinimumValue, _raceDefinition.StartingStatistics["Might Modifier"].MaximumValue + 1));
            _statistics["Finesse Modifier"].Setup(finesseDamage + Random.Range(_raceDefinition.StartingStatistics["Finesse Modifier"].MinimumValue, _raceDefinition.StartingStatistics["Finesse Modifier"].MaximumValue + 1));
            _statistics["Magic Modifier"].Setup(magicDamage + Random.Range(_raceDefinition.StartingStatistics["Magic Modifier"].MinimumValue, _raceDefinition.StartingStatistics["Magic Modifier"].MaximumValue + 1));
            
            _statistics["Block"].Setup(Random.Range(_raceDefinition.StartingStatistics["Block"].MinimumValue, _raceDefinition.StartingStatistics["Block"].MaximumValue + 1) + 
                                     (_characteristics["Might"].Maximum + _characteristics["Endurance"].Maximum) / 2);
            _statistics["Dodge"].Setup(Random.Range(_raceDefinition.StartingStatistics["Dodge"].MinimumValue, _raceDefinition.StartingStatistics["Dodge"].MaximumValue + 1) + 
                                      (_characteristics["Finesse"].Maximum + _characteristics["Senses"].Maximum) / 2);
            _statistics["Willpower"].Setup(Random.Range(_raceDefinition.StartingStatistics["Willpower"].MinimumValue, _raceDefinition.StartingStatistics["Willpower"].MaximumValue + 1) + 
                                       (_characteristics["Endurance"].Maximum + _characteristics["Spirit"].Maximum) / 2);
            
            _statistics["Perception"].Setup(Random.Range(_raceDefinition.StartingStatistics["Perception"].MinimumValue, _raceDefinition.StartingStatistics["Perception"].MaximumValue + 1) + 
                                            _characteristics["Finesse"].Maximum + _characteristics["Senses"].Maximum);
            _statistics["Movement"].Setup(_raceDefinition.StartingStatistics["Movement"].MinimumValue);
            _statistics["Critical Damage"].Setup(_raceDefinition.StartingStatistics["Critical Damage"].MinimumValue);
            _statistics["Critical Hit"].Setup(magicDamage + Random.Range(_raceDefinition.StartingStatistics["Critical Hit"].MinimumValue, _raceDefinition.StartingStatistics["Critical Hit"].MaximumValue + 1));
            _statistics["Fumble"].Setup(magicDamage + Random.Range(_raceDefinition.StartingStatistics["Fumble"].MinimumValue, _raceDefinition.StartingStatistics["Fumble"].MaximumValue + 1));
            
            CalculateStatisticModifiers();

            _vitals["Armor"].Refresh();
        }
        
        public void CalculateAttributes(EnemyDefinition enemyDefinition)
        {
            ResetModifiers();
            CalculateCharacteristicModifiers();
            
            _vitals["Life"].Setup(Random.Range(enemyDefinition.StartingVitals["Life"].MinimumValue, enemyDefinition.StartingVitals["Life"].MinimumValue + 1) + 
                                  (_characteristics["Endurance"].Maximum + _characteristics["Might"].Maximum) / 2);
            _vitals["Stamina"].Setup(Random.Range(enemyDefinition.StartingVitals["Stamina"].MinimumValue, enemyDefinition.StartingVitals["Stamina"].MinimumValue + 1) + 
                                  (_characteristics["Endurance"].Maximum + _characteristics["Spirit"].Maximum) / 2);
            _vitals["Magic"].Setup(Random.Range(enemyDefinition.StartingVitals["Magic"].MinimumValue, enemyDefinition.StartingVitals["Magic"].MinimumValue + 1) + 
                                  (_characteristics["Intellect"].Maximum + _characteristics["Spirit"].Maximum) / 2);
            
            _vitals["Actions"].Setup(Random.Range(enemyDefinition.StartingVitals["Actions"].MinimumValue, enemyDefinition.StartingVitals["Actions"].MinimumValue + 1));
            _vitals["Armor"].Setup(Random.Range(enemyDefinition.StartingVitals["Armor"].MinimumValue, enemyDefinition.StartingVitals["Armor"].MinimumValue + 1));
            _vitals["Luck"].Setup(Random.Range(enemyDefinition.StartingVitals["Luck"].MinimumValue, enemyDefinition.StartingVitals["Luck"].MinimumValue + 1));

            CalculateVitalModifiers();
            
            int mightAttack = _characteristics["Might"].Maximum + _characteristics["Finesse"].Maximum;
            int finesseAttack = _characteristics["Finesse"].Maximum + _characteristics["Senses"].Maximum;
            int magicAttack = _characteristics["Intellect"].Maximum + _characteristics["Spirit"].Maximum;
            
            _statistics["Might Attack"].Setup(mightAttack + Random.Range(enemyDefinition.StartingStatistics["Might Attack"].MinimumValue, enemyDefinition.StartingStatistics["Might Attack"].MaximumValue + 1));
            _statistics["Finesse Attack"].Setup(finesseAttack + Random.Range(enemyDefinition.StartingStatistics["Finesse Attack"].MinimumValue, enemyDefinition.StartingStatistics["Finesse Attack"].MaximumValue + 1));
            _statistics["Magic Attack"].Setup(magicAttack + Random.Range(enemyDefinition.StartingStatistics["Magic Attack"].MinimumValue, enemyDefinition.StartingStatistics["Magic Attack"].MaximumValue + 1));
            
            int mightDamage = (_characteristics["Might"].Maximum - 10) / 10;
            int finesseDamage = (_characteristics["Finesse"].Maximum - 10) / 10;
            int magicDamage = ((_characteristics["Intellect"].Maximum - 10) + (_characteristics["Spirit"].Maximum - 10)) / 10;
            
            _statistics["Might Modifier"].Setup(mightDamage + Random.Range(enemyDefinition.StartingStatistics["Might Modifier"].MinimumValue, enemyDefinition.StartingStatistics["Might Modifier"].MaximumValue + 1));
            _statistics["Finesse Modifier"].Setup(finesseDamage + Random.Range(enemyDefinition.StartingStatistics["Finesse Modifier"].MinimumValue, enemyDefinition.StartingStatistics["Finesse Modifier"].MaximumValue + 1));
            _statistics["Magic Modifier"].Setup(magicDamage + Random.Range(enemyDefinition.StartingStatistics["Magic Modifier"].MinimumValue, enemyDefinition.StartingStatistics["Magic Modifier"].MaximumValue + 1));
            
            _statistics["Block"].Setup(Random.Range(enemyDefinition.StartingStatistics["Block"].MinimumValue, enemyDefinition.StartingStatistics["Block"].MaximumValue + 1) + 
                                     (_characteristics["Might"].Maximum + _characteristics["Endurance"].Maximum) / 2);
            _statistics["Dodge"].Setup(Random.Range(enemyDefinition.StartingStatistics["Dodge"].MinimumValue, enemyDefinition.StartingStatistics["Dodge"].MaximumValue + 1) + 
                                      (_characteristics["Finesse"].Maximum + _characteristics["Senses"].Maximum) / 2);
            _statistics["Willpower"].Setup(Random.Range(enemyDefinition.StartingStatistics["Willpower"].MinimumValue, enemyDefinition.StartingStatistics["Willpower"].MaximumValue + 1) + 
                                       (_characteristics["Endurance"].Maximum + _characteristics["Spirit"].Maximum) / 2);
            
            _statistics["Perception"].Setup(Random.Range(enemyDefinition.StartingStatistics["Perception"].MinimumValue, enemyDefinition.StartingStatistics["Perception"].MaximumValue + 1) + 
                                            _characteristics["Finesse"].Maximum + _characteristics["Senses"].Maximum);
            _statistics["Movement"].Setup(enemyDefinition.StartingStatistics["Movement"].MinimumValue);
            _statistics["Critical Damage"].Setup(enemyDefinition.StartingStatistics["Critical Damage"].MinimumValue);
            _statistics["Critical Hit"].Setup(magicDamage + Random.Range(enemyDefinition.StartingStatistics["Critical Hit"].MinimumValue, enemyDefinition.StartingStatistics["Critical Hit"].MaximumValue + 1));
            _statistics["Fumble"].Setup(magicDamage + Random.Range(enemyDefinition.StartingStatistics["Fumble"].MinimumValue, enemyDefinition.StartingStatistics["Fumble"].MaximumValue + 1));
            
            CalculateStatisticModifiers();

            _vitals["Armor"].Refresh();
        }
        
        public void CalculateModifiers()
        {
            ResetModifiers();
            CalculateCharacteristicModifiers();
            CalculateVitalModifiers();
            CalculateStatisticModifiers();
        }
        
        public void CalculateCharacteristicModifiers()
        {
            foreach (Item equippedItem in _inventory.Equipment)
            {
                if (equippedItem == null || equippedItem.Key == "") continue;

                if (equippedItem.PrefixEnchantKey != "")
                {
                    CalculateEnchantModifiers(equippedItem.PrefixDefinition, _characteristics, AttributeTypes.Characteristic);
                }
                
                if (equippedItem.SuffixEnchantKey != "")
                {
                    CalculateEnchantModifiers(equippedItem.SuffixDefinition, _characteristics, AttributeTypes.Characteristic);
                }
            }
            
            CalculateUnitEffectModifiers(_characteristics, AttributeTypes.Characteristic);
        }

        public void CalculateVitalModifiers()
        {
            _vitals["Armor"].SetMaximum(0);
            
            foreach (Item equippedItem in _inventory.Equipment)
            {
                if (equippedItem == null || equippedItem.Key == "") continue;

                if (equippedItem.PrefixEnchantKey != "")
                {
                    CalculateEnchantModifiers(equippedItem.PrefixDefinition, _vitals, AttributeTypes.Vital);
                }
                
                if (equippedItem.SuffixEnchantKey != "")
                {
                    CalculateEnchantModifiers(equippedItem.SuffixDefinition, _vitals, AttributeTypes.Vital);
                }
                
                WearableData wearableData = equippedItem.GetWearableData();
                
                if (wearableData != null)
                {
                    _vitals["Armor"].AddToMaximum(wearableData.Armor);
                }
            }
            
            CalculateUnitEffectModifiers(_vitals, AttributeTypes.Vital);
        }
        
        public void CalculateStatisticModifiers()
        {
            foreach (Item equippedItem in _inventory.Equipment)
            {
                if (equippedItem == null || equippedItem.Key == "") continue;

                if (equippedItem.PrefixEnchantKey != "")
                {
                    CalculateEnchantModifiers(equippedItem.PrefixDefinition, _statistics, AttributeTypes.Statistic);
                }
                
                if (equippedItem.SuffixEnchantKey != "")
                {
                    CalculateEnchantModifiers(equippedItem.SuffixDefinition, _statistics, AttributeTypes.Statistic);
                }

                WearableData wearableData = equippedItem.GetWearableData();
                
                if (wearableData != null)
                {
                    _statistics["Block"].Modify(wearableData.Block);
                    _statistics["Dodge"].Modify(wearableData.Dodge);
                    _statistics["Perception"].Modify(wearableData.PerceptionModifier);
                }
            }
            
            CalculateUnitEffectModifiers(_statistics, AttributeTypes.Statistic);
        }
        
        private void CalculateEnchantModifiers(EnchantmentDefinition enchant, AttributeDictionary attributes, AttributeTypes type)
        {
            foreach (EnchantmentEffect enchantmentEffect in enchant.Effects)
            {
                if (enchantmentEffect.GetType() == typeof(ModifyAttributeEnchantmentEffect))
                {
                    ModifyAttributeEnchantmentEffect modifyAttributeEffect = (ModifyAttributeEnchantmentEffect)enchantmentEffect;
                            
                    if (modifyAttributeEffect.AttributeDefinition == null || modifyAttributeEffect.AttributeDefinition.AttributeType != type) continue;
                            
                    attributes[modifyAttributeEffect.AttributeDefinition.Key].Modify(modifyAttributeEffect.Modifier);
                }
            }
        }

        private void CalculateUnitEffectModifiers(AttributeDictionary attributes, AttributeTypes type)
        {
            foreach (UnitEffect unitEffect in _unitEffects.Effects)
            {
                //if (unitEffect.GetType() == typeof(ModifyAttributeUnitEffect))
                //{
                    //ModifyAttributeUnitEffect modifyAttributeEffect = (ModifyAttributeUnitEffect)unitEffect;
                            
                    //if (modifyAttributeEffect.AttributeDefinition == null || modifyAttributeEffect.AttributeDefinition.AttributeType != type) continue;
                            
                    //attributes[modifyAttributeEffect.AttributeDefinition.Key].Modify(modifyAttributeEffect.Modifier);
                //}
            }
        }

        public Attribute GetAttribute(string key)
        {
            return _characteristics[key];
        }

        public Attribute GetVital(string key)
        {
            return _vitals[key];
        }

        public Attribute GetStatistic(string key)
        {
            return _statistics[key];
        }

        public Resistance GetResistance(string key)
        {
            return _resistances[key];
        }

        public void RefreshActions()
        {
            GetVital("Actions").Refresh();
        }

        public void ModifyVital(string key, int amount, bool resetToZero)
        {
            _vitals[key].Damage(amount, resetToZero);
        }

        public void RecoverVital(string key, int amount)
        {
            _vitals[key].Restore(amount);
        }

        public void LoadData(AttributesSaveData saveData)
        {
            _characteristics = Attribute.ConvertToDictionary(saveData.Characteristics);
            _vitals = Attribute.ConvertToDictionary(saveData.Vitals);
            _statistics = Attribute.ConvertToDictionary(saveData.Statistics);
            _resistances = Attribute.ConvertToDictionary(saveData.Resistances);
        }
    }

    [System.Serializable]
    public class AttributesSaveData
    {
        [SerializeField] private List<Attribute> _characteristics = null;
        [SerializeField] private List<Attribute> _vitals = null;
        [SerializeField] private List<Attribute> _statistics = null;
        [SerializeField] private List<Resistance> _resistances = null;
    
        public List<Attribute> Characteristics => _characteristics;
        public List<Attribute> Vitals => _vitals;
        public List<Attribute> Statistics => _statistics;
        public List<Resistance> Resistances => _resistances;
    
        public AttributesSaveData(Hero hero)
        {
             _characteristics = Attribute.ConvertToList(hero.Attributes.Characteristics);
             _vitals = Attribute.ConvertToList(hero.Attributes.Vitals);
             _statistics = Attribute.ConvertToList(hero.Attributes.Statistics);
             _resistances = Attribute.ConvertToList(hero.Attributes.Resistances);
        }
    }
}
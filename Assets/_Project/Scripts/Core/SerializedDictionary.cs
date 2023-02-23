using System;
using System.Collections.Generic;
using Descending.Abilities;
using Descending.Attributes;
using Descending.Combat;
using Descending.Equipment;
using Descending.Equipment.Enchantments;
using Descending.Features;
using Descending.Units;
using UnityEngine;

namespace Descending.Core
{
    public abstract class SerializedDictionary<TKey, TValue> : Dictionary<TKey, TValue>,
        ISerializationCallbackReceiver
    {
        [SerializeField, HideInInspector] private List<TKey> keyData = new List<TKey>();

        [SerializeField, HideInInspector] private List<TValue> valueData = new List<TValue>();

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            this.Clear();
            for (int i = 0; i < this.keyData.Count && i < this.valueData.Count; i++)
            {
                this[this.keyData[i]] = this.valueData[i];
            }
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            this.keyData.Clear();
            this.valueData.Clear();

            foreach (var item in this)
            {
                this.keyData.Add(item.Key);
                this.valueData.Add(item.Value);
            }
        }
    }

    [Serializable]
    public class EffectDictionary : SerializedDictionary<string, GameObject>
    {
    }
    
    [Serializable]
    public class AttributeDictionary : SerializedDictionary<string, Attributes.Attribute>
    {
    }
    
    [Serializable]
    public class ResistanceDictionary : SerializedDictionary<string, Resistance>
    {
    }
    
    // [Serializable]
    // public class AttributeWidgetDictionary : SerializedDictionary<string, AttributeWidget>
    // {
    // }
    //
    // [Serializable]
    // public class SkillWidgetDictionary : SerializedDictionary<string, SkillWidget>
    // {
    // }
    //
    // [Serializable]
    // public class VitalWidgetDictionary : SerializedDictionary<string, VitalWidget>
    // {
    // }
    //
    // [Serializable]
    // public class VitalBarDictionary : SerializedDictionary<string, VitalBar>
    // {
    // }
    
    [Serializable]
    public class SkillDictionary : SerializedDictionary<string, Skill>
    {
    }
    
    [Serializable]
    public class AttributeDefinitionDictionary : SerializedDictionary<string, AttributeDefinition>
    {
    }
    
    [Serializable]
    public class SkillDefinitionDictionary : SerializedDictionary<string, SkillDefinition>
    {
    }

    [Serializable]
    public class StartingCharacteristicDictionary : SerializedDictionary<string, StartingCharacteristic>
    {
    }

    [Serializable]
    public class StartingVitalDictionary : SerializedDictionary<string, StartingVital>
    {
    }
    
    [Serializable]
    public class StartingStatisticDictionary : SerializedDictionary<string, StartingStatistic>
    {
    }
    
    [Serializable]
    public class StartingSkillDictionary : SerializedDictionary<string, StartingSkill>
    {
    }
    
    [Serializable]
    public class ProfessionDictionary : SerializedDictionary<string, ProfessionDefinition>
    {
    }
    
    [Serializable]
    public class RaceDictionary : SerializedDictionary<string, RaceDefinition>
    {
    }
    
    [Serializable]
    public class ItemsDictionary : SerializedDictionary<string, ItemDefinition>
    {
    }
    
    [Serializable]
    public class EnemiesDictionary : SerializedDictionary<string, EnemyDefinition>
    {
    }
    
    [Serializable]
    public class MaterialsDictionary : SerializedDictionary<string, MaterialDefinition>
    {
    }
    
    [Serializable]
    public class EnchantsDictionary : SerializedDictionary<string, EnchantmentDefinition>
    {
    }
    
    [Serializable]
    public class DamageTypeDictionary : SerializedDictionary<string, DamageTypeDefinition>
    {
    }
    
    [Serializable]
    public class AbilityDefinitionDictionary : SerializedDictionary<string, AbilityDefinition>
    {
    }
    
    [Serializable]
    public class FeatureDefinitionDictionary : SerializedDictionary<string, FeatureDefinition>
    {
    }
}
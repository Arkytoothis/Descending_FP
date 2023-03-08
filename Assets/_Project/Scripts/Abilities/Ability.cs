using System.Collections;
using System.Collections.Generic;
using System.Text;
using Descending.Core;
using Descending.Units;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.Serialization;

namespace Descending.Abilities
{
    [System.Serializable]
    public class Ability
    {
        [SerializeField] private AbilityType _abilityType = AbilityType.None;
        [SerializeField] private string _key = "";
        [SerializeField] private bool _isEmpty = true;

        public AbilityType AbilityType { get => _abilityType; }
        public bool IsEmpty { get => _isEmpty; set => _isEmpty = value; }
        public string Key { get => _key; set => _key = value; }

        public AbilityDefinition Definition => Database.instance.Abilities.GetAbility(_key);

        public Ability()
        {
            _abilityType = AbilityType.None;
            _key = "";
            _isEmpty = true;
        }

        public Ability(Ability ability)
        {
            _abilityType = ability.AbilityType;
            _key = ability.Key;
            _isEmpty = false;
        }

        public Ability(AbilityDefinition definition)
        {
            _isEmpty = false;
            _abilityType = definition.AbilityType;
            _key = definition.Key;
        }

        public string DisplayName()
        {
            return Definition.Name;
        }

        public string GetTooltipText()
        {
            StringBuilder sb = new StringBuilder();
            AbilityDefinition definition = Database.instance.Abilities.GetAbility(_key);

            sb.Append(definition.GetTooltipText());

            if (definition.Effects != null)
            {
                sb.Append(definition.Effects.GetTooltipText());
            }

            return sb.ToString();
        }

        public bool Use(Unit user, List<Unit> targets)
        {
            AbilityDefinition definition = Database.instance.Abilities.GetAbility(_key);

            if (user.Attributes.GetVital("Actions").Current < definition.ActionsToUse)
            {
                Debug.Log("Not Enough Actions");
                return false;
            }
            
            if (definition.Effects != null)
            {
                for (int i = 0; i < definition.Effects.Data.Count; i++)
                {
                    definition.Effects.Data[i].Process(user, targets);
                }
            }
        
            user.SpendActionPoints(definition.ActionsToUse);
            user.UseResource(definition.ResourceAttribute.Key, definition.ResourceAmount);
            
            return true;
        }
    }
}
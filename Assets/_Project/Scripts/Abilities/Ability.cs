using System.Collections;
using System.Collections.Generic;
using System.Text;
using Descending.Core;
using Descending.Units;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Abilities
{
    [System.Serializable]
    public class Ability
    {
        [SerializeField] private AbilityType _abilityType = AbilityType.None;
        [SerializeField] private string _key = "";
        [SerializeField] private bool _empty = true;

        public AbilityType AbilityType { get => _abilityType; }
        public bool Empty { get => _empty; set => _empty = value; }
        public string Key { get => _key; set => _key = value; }

        public AbilityDefinition Definition => Database.instance.Abilities.GetAbility(_key);

        public Ability()
        {
            _abilityType = AbilityType.None;
            _key = "";
            _empty = true;
        }

        public Ability(Ability ability)
        {
            _abilityType = ability.AbilityType;
            _key = ability.Key;

            if (ability.AbilityType == AbilityType.None)
            {
                _empty = true;
            }
            else
            {
                _empty = false;
            }
        }

        public Ability(AbilityDefinition definition)
        {
            _empty = false;
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
            bool success = false;
            AbilityDefinition definition = Database.instance.Abilities.GetAbility(_key);
            
            if (definition.Effects != null)
            {
                for (int i = 0; i < definition.Effects.Data.Count; i++)
                {
                    definition.Effects.Data[i].Process(user, targets);
                }
            }
        
            user.UseResource(definition.ResourceAttribute.Key, definition.ResourceAmount);
            
            return success;
        }
    }
}
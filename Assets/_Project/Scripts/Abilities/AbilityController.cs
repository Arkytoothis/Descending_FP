using System.Collections;
using System.Collections.Generic;
using Descending.Attributes;
using Descending.Core;
using Descending.Units;
using UnityEngine;

namespace Descending.Abilities
{
    public class AbilityController : MonoBehaviour
    {
        [SerializeField] private List<Ability> _memorizedPowers = null;
        [SerializeField] private List<Ability> _memorizedSpells = null;
        //[SerializeField] private List<Ability> _traits = null;
        
        public List<Ability> MemorizedPowers => _memorizedPowers;
        public List<Ability> MemorizedSpells => _memorizedSpells;

        public void Setup(RaceDefinition race, ProfessionDefinition profession, SkillsController skills)
        {
            FindStartingAbilities(race, profession, skills);
            LoadActionConfigs();
        }

        public void LoadData(AbilitySaveData saveData)
        {
            _memorizedPowers = saveData.MemorizedPowers;
            _memorizedSpells = saveData.MemorizedSpells;
        }
        
        private void FindStartingAbilities(RaceDefinition race, ProfessionDefinition profession, SkillsController skills)
        {
            foreach (var abilityKvp in Database.instance.Abilities.Abilities)
            {
                if (skills.ContainsSkills(abilityKvp.Value.Skill) && skills.GetSkill(abilityKvp.Value.Skill.Key).Current >= abilityKvp.Value.MinimumSkill)
                {
                    if (abilityKvp.Value.AbilityType == AbilityType.Power)
                    {
                        _memorizedPowers.Add(new Ability(abilityKvp.Value));
                    }
                    else if (abilityKvp.Value.AbilityType == AbilityType.Spell)
                    {
                        _memorizedSpells.Add(new Ability(abilityKvp.Value));
                    }
                }
            }
        }

        private void LoadActionConfigs()
        {
            for (int i = 0; i < _memorizedPowers.Count; i++)
            {
                AddAbility(_memorizedPowers[i]);
            }
            
            for (int i = 0; i < _memorizedSpells.Count; i++)
            {
                AddAbility(_memorizedSpells[i]);
            }
        }

        private void AddAbility(Ability ability)
        {
            //Debug.Log("Adding " + ability.Definition.Details.Name);
        }
    }

    [System.Serializable]
    public class AbilitySaveData
    {
        [SerializeField] private List<Ability> _memorizedPowers = null;
        [SerializeField] private List<Ability> _memorizedSpells = null;

        public List<Ability> MemorizedPowers => _memorizedPowers;
        public List<Ability> MemorizedSpells => _memorizedSpells;

        public AbilitySaveData(HeroUnit hero)
        {
            _memorizedPowers = new List<Ability>();
            _memorizedSpells = new List<Ability>();
            
            for (int i = 0; i < hero.Abilities.MemorizedPowers.Count; i++)
            {
                _memorizedPowers.Add(new Ability(hero.Abilities.MemorizedPowers[i]));
            }
            
            for (int i = 0; i < hero.Abilities.MemorizedSpells.Count; i++)
            {
                _memorizedSpells.Add(new Ability(hero.Abilities.MemorizedSpells[i]));
            }
        }
    }
}
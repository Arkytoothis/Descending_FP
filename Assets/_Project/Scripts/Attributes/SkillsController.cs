using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Units;
using UnityEngine;

namespace Descending.Attributes
{
    public class SkillsController : MonoBehaviour
    {
        [SerializeField] private SkillDictionary _skills = null;

        public SkillDictionary Skills => _skills;
        
        public void Setup(AttributesController attributes, RaceDefinition race, ProfessionDefinition profession)
        {
            _skills.Clear();
            
            foreach (var kvp in race.StartingSkills)
            {
                AddSkill(kvp.Value.Skill, 1);
            }
            
            foreach (var kvp in profession.StartingSkills)
            {
                AddSkill(kvp.Value.Skill, 1);
            }
            
            FindStartingAbilities();
        }

        public void LoadData(SkillsSaveData saveData)
        {
            _skills = Skill.LoadSkills(saveData.Skills);
        }
        
        public void AddSkill(SkillDefinition skill, int value)
        {
            if (_skills.ContainsKey(skill.Key) == false)
            {
                _skills.Add(skill.Key, new Skill(skill.Key, value));
            }
            else
            {
                _skills[skill.Key].Increase(1);
            }
        }

        public bool ContainsSkills(SkillDefinition skill)
        {
            return _skills.ContainsKey(skill.Key);
        }
        
        public Skill GetSkill(string key)
        {
            return _skills[key];
        }

        private void FindStartingAbilities()
        {
            foreach (var skillKvp in _skills)
            {
                SkillDefinition skillDefinition = Database.instance.Skills.GetSkill(skillKvp.Value.Key);
            }
        }
    }
    
    [System.Serializable]
    public class SkillsSaveData
    {
        [SerializeField] private List<Skill> _skills = null;
    
        public List<Skill> Skills => _skills;
    
        public SkillsSaveData(Hero hero)
        {
            _skills = Skill.SaveSkills(hero.Skills.Skills);
        }
    }
}
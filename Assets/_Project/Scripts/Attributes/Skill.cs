using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using UnityEngine;

namespace Descending.Attributes
{
    [System.Serializable]
    public class Skill
    {
        [SerializeField] private string _key = "";
        [SerializeField] private int _current = 0;
        [SerializeField] private int _maximum = 0;
        [SerializeField] private int _modifier = 0;
        [SerializeField] private int _spent = 0;

        public string Key => _key;
        public int Current { get => _current; }
        public int Maximum { get => _maximum; }
        public int Modifier { get => _modifier; }
        public int Spent { get => _spent; }
        
        public Skill(string key)
        {
            _key = key;
            _current = 0;
            _maximum = 0;
            _modifier = 0;
            _spent = 0;
        }
        
        public Skill(string key, int maximum)
        {
            _key = key;
            _current = maximum;
            _maximum = maximum;
            _modifier = 0;
            _spent = 0;
        }
        
        public Skill(StartingSkill startingSkill)
        {
            _key = startingSkill.Skill.Key;
            _current = startingSkill.MaximumValue;
            _maximum = startingSkill.MaximumValue;
            _modifier = 0;
            _spent = 0;
        }
        
        public void Setup(int maximum)
        {
            _current = maximum;
            _maximum = maximum;
            _modifier = 0;
            _spent = 0;
        }

        public void Damage(int amount)
        {
            _current -= amount;

            //if (_current < 0) _current = 0;
        }

        public void Restore(int amount)
        {
            _current += amount;

            if (_current > _maximum) _current = _maximum;
        }

        public void Increase(int amount)
        {
            _maximum += amount;
            _current += amount;
        }
        
        public static SkillDictionary LoadSkills(List<Skill> list)
        {
            SkillDictionary dictionary = new SkillDictionary();

            foreach (Skill skill in list)
            {
                dictionary.Add(skill.Key, skill);
            }

            return dictionary;
        }

        public static List<Skill>  SaveSkills(SkillDictionary dictionary)
        {
            List<Skill> list = new List<Skill>();

            foreach (var kvp in dictionary)
            {
                list.Add(kvp.Value);
            }

            return list;
        }
    }
}
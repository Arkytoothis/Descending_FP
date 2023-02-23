using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Descending.Core;
using UnityEngine;

namespace Descending.Attributes
{
    [CreateAssetMenu(fileName = "Skill Database", menuName = "Descending/Database/Skill Database")]
    public class SkillDatabase : ScriptableObject
	{
        [SerializeField] private SkillDefinitionDictionary _skills = null;
        [SerializeField] private List<Color> _skillCategoryColors = null;

        public List<Color> SkillCategoryColors { get => _skillCategoryColors; }

        public SkillDefinition GetSkill(string key)
        {
            if (_skills.ContainsKey(key) == false)
            {
                Debug.LogError("Key: " + key + " does not exist");
            }
            
            return _skills[key];
        }
    }
}
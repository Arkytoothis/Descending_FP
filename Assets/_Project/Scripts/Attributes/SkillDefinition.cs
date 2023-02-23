using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Abilities;
using UnityEngine;

namespace Descending.Attributes
{
    [CreateAssetMenu(fileName = "Skill Definition", menuName = "Descending/Definition/Skill Definition")]
    public class SkillDefinition : ScriptableObject
    {
        [HorizontalGroup("Split", 150)]

        [SerializeField, HideLabel, PreviewField(78), BoxGroup("Split/Icon")]
        private Sprite _icon = null;
        [SerializeField] private string _name = "";
        [SerializeField] private string _key = "";

        [SerializeField, BoxGroup("Split/Details")]
        private SkillCategory _skillCategory = SkillCategory.None;
        //[SerializeReference] private AbilityTree _tree = null;
        
        public string Name => _name;
        public string Key => _key;
        public Sprite Icon => _icon;
        public SkillCategory SkillCategory => _skillCategory;
    }
}
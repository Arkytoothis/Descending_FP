using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Units;
using UnityEngine;
using UnityEngine.Serialization;

namespace Descending.Gui
{
    public class HeroSkillsPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _skillWidgetPrefab = null;
        [SerializeField] private Transform _skillWidgetsParent = null;

        private List<SkillWidget> _widgets = null;

        public void Setup()
        {
            _widgets = new List<SkillWidget>();
        }
        
        public void DisplayHero(Hero hero)
        {
            _skillWidgetsParent.ClearTransform();
            _widgets.Clear();

            foreach (var skillKvp in hero.Skills.Skills)
            {
                GameObject clone = Instantiate(_skillWidgetPrefab, _skillWidgetsParent);
                SkillWidget widget = clone.GetComponent<SkillWidget>();
                widget.SetSkill(skillKvp.Value.Key, skillKvp.Value.Current, skillKvp.Value.Maximum);
            }
        }
    }
}
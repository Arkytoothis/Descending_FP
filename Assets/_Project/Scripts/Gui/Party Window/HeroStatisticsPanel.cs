using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using UnityEngine;

namespace Descending.Gui
{
    public class HeroStatisticsPanel : MonoBehaviour
    {
        [SerializeField] private StatisticWidget _attackWidget = null;
        [SerializeField] private StatisticWidget _accuracyWidget = null;
        [SerializeField] private StatisticWidget _focusWidget = null;
        [SerializeField] private StatisticWidget _mightModifierWidget = null;
        [SerializeField] private StatisticWidget _finesseModifierWidget = null;
        [SerializeField] private StatisticWidget _magicModifierWidget = null;
        [SerializeField] private StatisticWidget _blockWidget = null;
        [SerializeField] private StatisticWidget _dodgeWidget = null;
        [SerializeField] private StatisticWidget _willpowerWidget = null;
        [SerializeField] private StatisticWidget _initiativeWidget = null;
        [SerializeField] private StatisticWidget _perceptionWidget = null;
        [SerializeField] private StatisticWidget _criticalHitWidget = null;
        [SerializeField] private StatisticWidget _criticalDamageWidget = null;
        [SerializeField] private StatisticWidget _fumbleWidget = null;

        public void Setup()
        {
            
        }
        
        public void DisplayHero(Hero hero)
        {
            _attackWidget.SetAttributePercent(hero.Attributes.GetStatistic("Attack"));
            _accuracyWidget.SetAttributePercent(hero.Attributes.GetStatistic("Accuracy"));
            _focusWidget.SetAttributePercent(hero.Attributes.GetStatistic("Focus"));
            
            _mightModifierWidget.SetAttributeModifier(hero.Attributes.GetStatistic("Might Modifier"));
            _finesseModifierWidget.SetAttributeModifier(hero.Attributes.GetStatistic("Finesse Modifier"));
            _magicModifierWidget.SetAttributeModifier(hero.Attributes.GetStatistic("Magic Modifier"));
            
            _blockWidget.SetAttributePercent(hero.Attributes.GetStatistic("Block"));
            _dodgeWidget.SetAttributePercent(hero.Attributes.GetStatistic("Dodge"));
            _willpowerWidget.SetAttributePercent(hero.Attributes.GetStatistic("Willpower"));
            
            _perceptionWidget.SetAttributePercent(hero.Attributes.GetStatistic("Perception"));
            _initiativeWidget.SetAttribute(hero.Attributes.GetStatistic("Initiative"));
            
            _criticalHitWidget.SetAttributePercent(hero.Attributes.GetStatistic("Critical Hit"));
            _criticalDamageWidget.SetAttribute(hero.Attributes.GetStatistic("Critical Damage"));
            _fumbleWidget.SetAttributePercent(hero.Attributes.GetStatistic("Fumble"));
        }
    }
}
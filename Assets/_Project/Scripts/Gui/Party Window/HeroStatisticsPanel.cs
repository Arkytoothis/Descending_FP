using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using UnityEngine;
using UnityEngine.Serialization;

namespace Descending.Gui
{
    public class HeroStatisticsPanel : MonoBehaviour
    {
        [SerializeField] private StatisticWidget _finesseAttackWidget = null;
        [SerializeField] private StatisticWidget _mightAttackWidget = null;
        [SerializeField] private StatisticWidget _magicAttackWidget = null;
        [SerializeField] private StatisticWidget _mightModifierWidget = null;
        [SerializeField] private StatisticWidget _finesseModifierWidget = null;
        [SerializeField] private StatisticWidget _magicModifierWidget = null;
        [SerializeField] private StatisticWidget _blockWidget = null;
        [SerializeField] private StatisticWidget _dodgeWidget = null;
        [SerializeField] private StatisticWidget _willpowerWidget = null;
        [SerializeField] private StatisticWidget _movementWidget = null;
        [SerializeField] private StatisticWidget _perceptionWidget = null;
        [SerializeField] private StatisticWidget _criticalHitWidget = null;
        [SerializeField] private StatisticWidget _criticalDamageWidget = null;
        [SerializeField] private StatisticWidget _fumbleWidget = null;

        public void Setup()
        {
            
        }
        
        public void DisplayHero(Hero hero)
        {
            // _mightAttackWidget.SetAttributePercent(hero.Attributes.GetStatistic("Might Attack"));
            // _finesseAttackWidget.SetAttributePercent(hero.Attributes.GetStatistic("Finesse Attack"));
            // _magicAttackWidget.SetAttributePercent(hero.Attributes.GetStatistic("Magic Attack"));
            //
            // _mightModifierWidget.SetAttributeModifier(hero.Attributes.GetStatistic("Might Modifier"));
            // _finesseModifierWidget.SetAttributeModifier(hero.Attributes.GetStatistic("Finesse Modifier"));
            // _magicModifierWidget.SetAttributeModifier(hero.Attributes.GetStatistic("Magic Modifier"));
            //
            // _blockWidget.SetAttributePercent(hero.Attributes.GetStatistic("Block"));
            // _dodgeWidget.SetAttributePercent(hero.Attributes.GetStatistic("Dodge"));
            // _willpowerWidget.SetAttributePercent(hero.Attributes.GetStatistic("Willpower"));
            //
            // _perceptionWidget.SetAttributePercent(hero.Attributes.GetStatistic("Perception"));
            // _movementWidget.SetAttribute(hero.Attributes.GetStatistic("Movement"));
            //
            // _criticalHitWidget.SetAttributePercent(hero.Attributes.GetStatistic("Critical Hit"));
            // _criticalDamageWidget.SetAttribute(hero.Attributes.GetStatistic("Critical Damage"));
            // _fumbleWidget.SetAttributePercent(hero.Attributes.GetStatistic("Fumble"));
        }
    }
}
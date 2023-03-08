using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Gui
{
    public class PartyWindow : GameWindow
    {
        [SerializeField] private HeroListPanel _listPanel = null;
        [SerializeField] private HeroDetailsPanel _detailsPanel = null;
        [SerializeField] private HeroCharacteristicsPanel _characteristicsPanel = null;
        [SerializeField] private HeroVitalsPanel _vitalsPanel = null;
        [SerializeField] private HeroStatisticsPanel _statisticsPanel = null;
        [SerializeField] private HeroResistancesPanel _resistancesPanel = null;
        [SerializeField] private HeroSkillsPanel _skillsPanel = null;
        [SerializeField] private HeroEquipmentPanel _equipmentPanel = null;
        [SerializeField] private HeroAbilitiesPanel _abilitiesPanel = null;
        [SerializeField] private StockpilePanel _stockpilePanel = null;
        
        [SerializeField] private ItemEvent onDisplayItemTooltip = null;
        
        //[SoundGroup, SerializeField] private string _openSound;
        //[SoundGroup, SerializeField] private string _closeSound;
        
        public override void Setup(WindowManager manager)
        {
            _manager = manager;
            _listPanel.Setup(this);
            _detailsPanel.Setup();
            _characteristicsPanel.Setup();
            _vitalsPanel.Setup();
            _statisticsPanel.Setup();
            _resistancesPanel.Setup();
            _skillsPanel.Setup();
            _equipmentPanel.Setup();
            _abilitiesPanel.Setup();
            _stockpilePanel.Setup();
            
            Close();
        }

        public override void Open()
        {
            gameObject.SetActive(true);
            _isOpen = true;
            _listPanel.Setup(this);
            SelectHero(HeroManager.Instance.Heroes[0]);
            _stockpilePanel.UpdateStockpile();
            //MasterAudio.PlaySound(_openSound);
        }

        public override void Close()
        {
            gameObject.SetActive(false);
            //MasterAudio.PlaySound(_closeSound);
            _isOpen = false;
            onDisplayItemTooltip.Invoke(null);
        }

        public void SelectHero(Hero hero)
        {
            _detailsPanel.DisplayHero(hero);
            _characteristicsPanel.DisplayHero(hero);
            _vitalsPanel.DisplayHero(hero);
            _statisticsPanel.DisplayHero(hero);
            _resistancesPanel.DisplayHero(hero);
            _skillsPanel.DisplayHero(hero);
            _equipmentPanel.DisplayHero(hero);
            _abilitiesPanel.DisplayHero(hero);
        }

        public void OnSyncSelectedHero(bool b)
        {
            if (HeroManager.Instance.SelectedHero == null) return;
            
            SelectHero(HeroManager.Instance.SelectedHero);
        }
    }
}
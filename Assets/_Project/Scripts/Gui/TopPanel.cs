using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Descending.Gui
{
    public class TopPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _bronzeKeysLabel = null;
        [SerializeField] private TMP_Text _ironKeysLabel = null;
        [SerializeField] private TMP_Text _goldKeysLabel = null;
        
        [SerializeField] private TMP_Text _coinsLabel = null;
        [SerializeField] private TMP_Text _gemsLabel = null;
        [SerializeField] private TMP_Text _suppliesLabel = null;
        
        [SerializeField] private TMP_Text _weatherLabel = null;
        [SerializeField] private TMP_Text _moonPhaseLabel = null;
        [SerializeField] private TMP_Text _timeLabel = null;

        public void Setup()
        {
            _weatherLabel.SetText("Clear");
            _moonPhaseLabel.SetText("Waxing Gibous");
            _timeLabel.SetText("Late Morning, April 12th, 399pd");
        }
        
        public void OnSyncCoins(int coins)
        {
            _coinsLabel.SetText(coins.ToString());
        }
        
        public void OnSyncGems(int gems)
        {
            _gemsLabel.SetText(gems.ToString());
        }
        
        public void OnSyncSupplies(int supplies)
        {
            _suppliesLabel.SetText(supplies.ToString());
        }
        
        public void OnSyncBronzeKeys(int bronzeKeys)
        {
            _bronzeKeysLabel.SetText(bronzeKeys.ToString());
        }
        
        public void OnSyncIronKeys(int ironKeys)
        {
            _ironKeysLabel.SetText(ironKeys.ToString());
        }
        
        public void OnSyncGoldKeys(int goldKeys)
        {
            _goldKeysLabel.SetText(goldKeys.ToString());
        }
    }
}

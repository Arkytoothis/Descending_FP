using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using TMPro;
using UnityEngine;

namespace Descending.Gui
{
    public class StockpilePanel : MonoBehaviour
    {
        [SerializeField] private GameObject _stockpileWidgetPrefab = null;
        [SerializeField] private Transform _stockpileWidgetsParent = null;
        [SerializeField] private TMP_Text _coinsLabel = null;
        [SerializeField] private TMP_Text _suppliesLabel = null;
        [SerializeField] private TMP_Text _gemsLabel = null;

        private List<StockpileWidget> _widgets = null;

        public void Setup()
        {
            _widgets = new List<StockpileWidget>();
            
            for (int i = 0; i < StockpileManager.MAX_STOCKPILE_SLOTS; i++)
            {
                GameObject clone = Instantiate(_stockpileWidgetPrefab, _stockpileWidgetsParent);
                StockpileWidget widget = clone.GetComponent<StockpileWidget>();
                widget.Setup(i);
                _widgets.Add(widget);
            }
        }

        public void UpdateStockpile()
        {
            //Debug.Log("Syncing Stockpile");
            for (int i = 0; i < StockpileManager.MAX_STOCKPILE_SLOTS; i++)
            {
                _widgets[i].SetItem(StockpileManager.Instance.GetItem(i));
            }
            
            _coinsLabel.SetText("Coins: " + ResourcesManager.Instance.Coins);
            _suppliesLabel.SetText("Coins: " + ResourcesManager.Instance.Supplies);
            _gemsLabel.SetText("Coins: " + ResourcesManager.Instance.Gems);
        }

        public void OnSyncStockpile(bool b)
        {
            UpdateStockpile();
        }
    }
}
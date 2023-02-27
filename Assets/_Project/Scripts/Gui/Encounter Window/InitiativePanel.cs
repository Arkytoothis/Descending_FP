using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Encounters;
using TMPro;
using UnityEngine;

namespace Descending.Gui
{
    public class InitiativePanel : MonoBehaviour
    {
        [SerializeField] private GameObject _heroWidgetPrefab = null;
        [SerializeField] private GameObject _enemyWidgetPrefab = null;
        [SerializeField] private Transform _widgetsParent = null;
        [SerializeField] private TMP_Text _currenInitiativeLabel = null;
        [SerializeField] private TMP_Text _currenTurnLabel = null;

        private List<InitiativeWidget> _initiativeWidgets = null;
        private Encounter _encounter = null;
        
        public void Setup(Encounter encounter)
        {
            _encounter = encounter;
            _initiativeWidgets = new List<InitiativeWidget>();
            _widgetsParent.ClearTransform();

            for (int i = 0; i < _encounter.InitiativeDataList.Count; i++)
            {
                if (_encounter.InitiativeDataList[i].Hero != null)
                {
                    GameObject clone = Instantiate(_heroWidgetPrefab, _widgetsParent);
                    HeroInitiativeWidget initiativeWidget = clone.GetComponent<HeroInitiativeWidget>();
                    initiativeWidget.Setup(_encounter.InitiativeDataList[i].Hero, i, _encounter.InitiativeDataList[i].InitiativeRoll);
                    _initiativeWidgets.Add(initiativeWidget);
                }
                else if (_encounter.InitiativeDataList[i].Enemy != null)
                {
                    GameObject clone = Instantiate(_enemyWidgetPrefab, _widgetsParent);
                    EnemyInitiativeWidget initiativeWidget = clone.GetComponent<EnemyInitiativeWidget>();
                    initiativeWidget.Setup(_encounter.InitiativeDataList[i].Enemy, i, _encounter.InitiativeDataList[i].InitiativeRoll);
                    _initiativeWidgets.Add(initiativeWidget);
                }
            }
            
            _initiativeWidgets[0].Select();
            SyncEncounter();
        }

        public void SyncEncounter()
        {
            _currenTurnLabel.SetText("Turn " + EncounterManager.Instance.CurrentTurn);
            _currenInitiativeLabel.SetText("Initiative Index: " + EncounterManager.Instance.CurrentInitiativeIndex);

            foreach (InitiativeWidget widget in _initiativeWidgets)
            {
                widget.Sync();
            }
        }

        public void SelectInitiativeIndex(int index)
        {
            for (int i = 0; i < _initiativeWidgets.Count; i++)
            {
                if (i == index)
                {
                    _initiativeWidgets[i].Select();
                }
                else
                {
                    _initiativeWidgets[i].Deselect();
                }
            }
        }
    }
}

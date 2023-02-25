using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Encounters;
using Descending.Units;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Descending.Gui
{
    public class InitiativePanel : MonoBehaviour
    {
        [SerializeField] private GameObject _heroWidgetPrefab = null;
        [SerializeField] private GameObject _enemyWidgetPrefab = null;
        [SerializeField] private Transform _widgetsParent = null;

        private List<InitiativeWidget> _initiativeWidgets = null;
        private Encounter _encounter = null;
        
        public void Setup(Encounter encounter)
        {
            _encounter = encounter;
            _initiativeWidgets = new List<InitiativeWidget>();
            _widgetsParent.ClearTransform();
            List<InitiativeData> initiativeData = new List<InitiativeData>();
            
            for (int i = 0; i < encounter.Enemies.Count; i++)
            {
                int initiativeRoll = Random.Range(1, 101);
                initiativeData.Add(new InitiativeData(initiativeRoll, encounter.Enemies[i]));
            }

            for (int i = 0; i < HeroManager.Instance.Heroes.Count; i++)
            {
                int initiativeRoll = Random.Range(1, 101);
                initiativeData.Add(new InitiativeData(initiativeRoll, HeroManager.Instance.Heroes[i]));
            }
            
            initiativeData.Sort((x, y) => x.InitiativeRoll.CompareTo(y.InitiativeRoll));

            for (int i = 0; i < initiativeData.Count; i++)
            {
                if (initiativeData[i].Hero != null)
                {
                    GameObject clone = Instantiate(_heroWidgetPrefab, _widgetsParent);
                    HeroInitiativeWidget initiativeWidget = clone.GetComponent<HeroInitiativeWidget>();
                    initiativeWidget.Setup(initiativeData[i].Hero, i, initiativeData[i].InitiativeRoll);
                    _initiativeWidgets.Add(initiativeWidget);
                }
                else if (initiativeData[i].Enemy != null)
                {
                    GameObject clone = Instantiate(_enemyWidgetPrefab, _widgetsParent);
                    EnemyInitiativeWidget initiativeWidget = clone.GetComponent<EnemyInitiativeWidget>();
                    initiativeWidget.Setup(initiativeData[i].Enemy, i, initiativeData[i].InitiativeRoll);
                    _initiativeWidgets.Add(initiativeWidget);
                }
            }
        }
    }
}

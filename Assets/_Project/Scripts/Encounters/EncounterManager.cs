using System.Collections;
using System.Collections.Generic;
using Descending.Player;
using Descending.Units;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Encounters
{
    public class EncounterManager : MonoBehaviour
    {
        public static EncounterManager Instance { get; private set; }
        
        [SerializeField] private PlayerController _playerController = null;
        [SerializeField] private CombatRaycaster _combatRaycaster = null;
        [SerializeField] private List<Encounter> _encounters = null;
        [SerializeField] private float _enemyActionDelay = 2f;

        [SerializeField] private EncounterEvent onEncounterTriggered = null;
        [SerializeField] private BoolEvent onSyncEncounter = null;
        [SerializeField] private BoolEvent onEndEncounter = null;
        [SerializeField] private IntEvent onSelectInitiative = null;
        [SerializeField] private IntEvent onSelectPartyWidget = null;

        private Encounter _currentEncounter = null;
        private bool _waitForInput = false;
        private int _currentInitiativeIndex = -1;
        private int _currentTurn = 0;

        public int CurrentInitiativeIndex => _currentInitiativeIndex;
        public int CurrentTurn => _currentTurn;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("Multiple EncounterManagers " + transform + " - " + Instance);
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
            _encounters = new List<Encounter>();
        }

        public void Setup()
        {
            
        }

        private void Update()
        {
            if (_waitForInput == false) return;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _waitForInput = false;
                NextUnit(true);
            }
        }

        public void RegisterEncounter(Encounter encounter)
        {
            _encounters.Add(encounter);
            encounter.Setup(_playerController.transform);
        }

        public void TriggerEncounter(Encounter encounter)
        {
            _currentEncounter = encounter;
            _currentEncounter.Trigger();
            _playerController.SetCombatRaycastMode();
            _playerController.SetInCombat(true);
            onEncounterTriggered.Invoke(_currentEncounter);
        }

        public void EndEncounter()
        {
            _playerController.SetWorldRaycastMode();
            _playerController.SetInCombat(false);
            _playerController.SetLookMode();
            
            onEndEncounter.Invoke(true);
        }

        public void StartCombat()
        {
            _currentEncounter.RollInitiative();
            _currentEncounter.LookAtPlayer(_playerController.transform);
            _currentTurn = 0;
            _currentInitiativeIndex = -1;
            NextUnit(false);
        }

        private void NewTurn()
        {
            _currentTurn++;
            Debug.Log("New Turn: " + _currentTurn);
        }

        private void NextUnit(bool checkForNewTurn)
        {
            _currentInitiativeIndex++;
            if (_currentInitiativeIndex >= _currentEncounter.InitiativeDataList.Count)
                _currentInitiativeIndex = 0;

            if (checkForNewTurn && _currentInitiativeIndex == 0)
            {
                NewTurn();
            }
            
            ProcessCurrentInitiativeIndex();
            onSyncEncounter.Invoke(true);
        }

        private void ProcessCurrentInitiativeIndex()
        {
            onSelectInitiative.Invoke(_currentInitiativeIndex);
            
            if (_currentEncounter.InitiativeDataList[_currentInitiativeIndex].Hero != null)
            {
                ProcessHeroTurn(_currentEncounter.InitiativeDataList[_currentInitiativeIndex].Hero);
            }
            else if (_currentEncounter.InitiativeDataList[_currentInitiativeIndex].Enemy != null)
            {
                ProcessEnemyTurn(_currentEncounter.InitiativeDataList[_currentInitiativeIndex].Enemy);
            }
        }

        private void ProcessHeroTurn(Hero hero)
        {
            //Debug.Log(hero.GetShortName() + " acting - Press Space To Skip");
            HeroManager.Instance.SelectHero(hero);
            onSelectPartyWidget.Invoke(hero.HeroData.ListIndex);
            _combatRaycaster.SetCanRaycastForEnemy(true);
            _currentEncounter.DeselectEnemies();
            _waitForInput = true;
        }

        private void ProcessEnemyTurn(Enemy enemy)
        {
            //Debug.Log(enemy.GetShortName() + " acting");
            HeroManager.Instance.SelectHero(null);
            onSelectPartyWidget.Invoke(-1);
            _combatRaycaster.SetCanRaycastForEnemy(false);
            _waitForInput = false;
            _currentEncounter.SelectEnemy(enemy);
            StartCoroutine(EnemyAction_Coroutine());
        }

        private IEnumerator EnemyAction_Coroutine()
        {
            yield return new WaitForSeconds(_enemyActionDelay);
            
            NextUnit(true);
        }

        public void ProcessAttack(Unit attacker, Unit defender)
        {
            Debug.Log(attacker.GetShortName() + " is attacking " + defender.GetShortName());
        }
    }
}

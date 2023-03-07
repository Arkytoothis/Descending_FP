using System.Collections;
using System.Collections.Generic;
using Descending.Combat;
using Descending.Core;
using Descending.Equipment;
using Descending.Player;
using Descending.Treasure;
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
        [SerializeField] private float _enemyActionDelay = 0.5f;
        [SerializeField] private float _enemyTurnDelay = 2f;

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

            _currentEncounter.transform.LookAt(_playerController.transform);
            
            foreach (Enemy enemy in _currentEncounter.Enemies)
            {
                Utilities.PlaceOnGround(enemy.transform, 0f);
            }
            
            StartCombat();
            onEncounterTriggered.Invoke(_currentEncounter);
        }

        public void EndEncounter()
        {
            _playerController.SetWorldRaycastMode();
            _playerController.SetInCombat(false);
            _playerController.SetLookMode();
            onEndEncounter.Invoke(true);
            TreasureManager.Instance.SpawnTreasureChest(_currentEncounter.transform.position);
            HeroManager.Instance.RefreshHeroActions();
            
            RemoveEncounter(_currentEncounter);
            _currentEncounter = null;
        }

        public void StartCombat()
        {
            _currentEncounter.RollInitiative();
            _currentTurn = 0;
            _currentInitiativeIndex = -1;
            NextUnit(false);
        }

        private void NewTurn()
        {
            _currentTurn++;
            Debug.Log("New Turn: " + _currentTurn);
            
            HeroManager.Instance.RefreshHeroActions();
            _currentEncounter.RefreshEnemyActions();
        }

        private void NextUnit(bool checkForNewTurn)
        {
            if (_currentEncounter == null) return;
            
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
            else
            {
                StartCoroutine(Wait());
            }
        }

        public void RemoveEncounter(Encounter encounter)
        {
            if (_encounters.Contains(encounter))
            {
                _encounters.Remove(encounter);
                Destroy(encounter.gameObject);
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
            StartCoroutine(EnemyAction_Coroutine(enemy));
            StartCoroutine(Wait());
        }

        private IEnumerator EnemyAction_Coroutine(Enemy enemy)
        {
            int heroindex = Random.Range(0, 6);

            enemy.PerformAttack();
            ProcessAttack(enemy, HeroManager.Instance.Heroes[heroindex]);
            
            yield return new WaitForSeconds(_enemyTurnDelay);
            
            NextUnit(true);
        }

        private IEnumerator Wait()
        {
            yield return new WaitForSeconds(_enemyTurnDelay);
        }

        public void ProcessAttack(Unit attacker, Unit defender)
        {
            if (defender == null || defender.gameObject == null || defender.IsAlive == false) return;

            Item weapon = attacker.GetEquippedWeapon();
            WeaponData weaponData = weapon.GetWeaponData();

            if (attacker.Attributes.GetVital("Actions").Current < weaponData.Actions)
            {
                Debug.Log("Not Enough Actions");
                return;
            }

            attacker.SpendActionPoints(weaponData.Actions);
            
            if (weaponData.HasProjectile == false)
            {
                StartCoroutine(weapon.DelayedSpawnAttackEffect(attacker, defender));
                CombatCalculator.ProcessAttack(attacker, defender);
            }
            else
            {
                StartCoroutine(weapon.DelayedSpawnProjectile(attacker, defender));
            }
        }
    }
}
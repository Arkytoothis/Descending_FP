using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using UnityEngine;

namespace Descending.Core
{
    public enum GameTickModes { World, Combat, Number, None }
    
    public class GameTickManager : MonoBehaviour
    {
        public static GameTickManager Instance { get; private set; }

        [SerializeField] private float _gameTickDelay = 1f;
        [SerializeField] private float _recoveryDelay = 5f;
        [SerializeField] private GameTickModes _tickMode = GameTickModes.World;
        [SerializeField] private bool _processTick = true;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("Multiple GameTickManagers " + transform + " - " + Instance);
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
        }

        public void Setup()
        {
            SetProcessTick(true);
            SetTickMode(GameTickModes.World);
            
            StartCoroutine(GameTick_Coroutine());
            StartCoroutine(RecoveryTick_Coroutine());
        }

        public void GameTick()
        {
            foreach (Hero hero in HeroManager.Instance.Heroes)
            {
                hero.GameTick();
            }
        }
        
        private IEnumerator GameTick_Coroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(_gameTickDelay);

                if(_processTick == true && _tickMode == GameTickModes.World)
                {
                    GameTick();
                }
            }
        }

        public void RecoveryTick()
        {
            foreach (Hero hero in HeroManager.Instance.Heroes)
            {
                hero.RecoveryTick();
            }
        }
        
        private IEnumerator RecoveryTick_Coroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(_recoveryDelay);

                if (_processTick == true && _tickMode == GameTickModes.World)
                {
                    RecoveryTick();
                }
            }
        }

        public void SetTickMode(GameTickModes newMode)
        {
            _tickMode = newMode;
        }

        public void SetProcessTick(bool isActive)
        {
            _processTick = isActive;
        }
    }
}
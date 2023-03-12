using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Units;
using UnityEngine;

namespace Descending.Player
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance { get; private set; }
        
        [SerializeField] private GameScenes _currentScene = GameScenes.None;
        [SerializeField] private Transform _projectileSpawnLeft = null;
        [SerializeField] private Transform _projectileSpawnCenter = null;
        [SerializeField] private Transform _projectileSpawnRight = null;
        [SerializeField] private Transform _attackEffectSpawnLeft = null;
        [SerializeField] private Transform _attackEffectSpawnCenter = null;
        [SerializeField] private Transform _attackEffectSpawnRight = null;

        public GameScenes CurrentScene => _currentScene;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("Multiple PlayerManagers " + transform + " - " + Instance);
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
        }

        public void Setup(GameScenes currentScene)
        {
            _currentScene = currentScene;
        }

        public Transform GetProjectileSpawn(Hero hero)
        {
            if (hero.HeroData.ListIndex == 0 || hero.HeroData.ListIndex == 3)
            {
                return _projectileSpawnLeft;
            }
            else if (hero.HeroData.ListIndex == 1 || hero.HeroData.ListIndex == 4)
            {
                return _projectileSpawnCenter;
            }
            else if (hero.HeroData.ListIndex == 2 || hero.HeroData.ListIndex == 5)
            {
                return _projectileSpawnRight;
            }
            else
            {
                return null;
            }
        }

        public Transform GetAttackSpawn(Hero hero)
        {
            if (hero.HeroData.ListIndex == 0 || hero.HeroData.ListIndex == 3)
            {
                return _attackEffectSpawnLeft;
            }
            else if (hero.HeroData.ListIndex == 1 || hero.HeroData.ListIndex == 4)
            {
                return _attackEffectSpawnCenter;
            }
            else if (hero.HeroData.ListIndex == 2 || hero.HeroData.ListIndex == 5)
            {
                return _attackEffectSpawnRight;
            }
            else
            {
                return null;
            }
        }
    }
}

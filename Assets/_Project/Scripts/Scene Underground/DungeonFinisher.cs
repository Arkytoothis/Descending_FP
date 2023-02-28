using System.Collections;
using System.Collections.Generic;
using Descending.Player;
using DunGen;
using DunGen.Adapters;
using UnityEngine;

namespace Descending.Dungeons
{
    public class DungeonFinisher : BaseAdapter
    {
        [SerializeField] private PlayerController _playerController = null;

        public void OnRegisterPlayerSpawner(GameObject spawner)
        {
            _playerController.transform.position = spawner.transform.position;
        }
        
        protected override void Run(DungeonGenerator generator)
        {
            //Debug.Log("Finishing Dungeon");
            
            StartCoroutine(Finish_Coroutine());
        }

        private IEnumerator Finish_Coroutine()
        {
            yield return 0;
            
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Treasure
{
    public class TreasureSpawner : MonoBehaviour
    {
        private void Start()
        {
            TreasureManager.Instance.SpawnTreasureChest(transform.position);
        }
    }
}
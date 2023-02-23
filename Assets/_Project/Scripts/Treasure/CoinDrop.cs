using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Dropables
{
    public class CoinDrop : Dropable
    {
        [SerializeField] private float _velocityThreshold = 0.01f;
        [SerializeField] private int _coins = 1;
        
        private Rigidbody _rigidbody = null;
        private bool _stoppedMoving = false;

        public int Coins => _coins;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (_stoppedMoving == true) return;
            
            if (_rigidbody.velocity.magnitude < _velocityThreshold)
            {
                _stoppedMoving = true;
                // MapPosition mapPosition = MapManager.Instance.GetGridPosition(transform.position);
                // Tile tile = MapManager.Instance.GetTile(mapPosition);
                //
                // if (tile != null)
                // {
                //     tile.AddCoinDrop(this);
                // }
            }
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Dropables
{
    public class GemDrop : Dropable
    {
        [SerializeField] private float _velocityThreshold = 0.01f;
        [SerializeField] private int _gems = 1;
        
        private Rigidbody _rigidbody = null;
        private bool _stoppedMoving = false;

        public int Gems => _gems;

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
                //     tile.AddGemDrop(this);
                // }
            }
        }
    }
}
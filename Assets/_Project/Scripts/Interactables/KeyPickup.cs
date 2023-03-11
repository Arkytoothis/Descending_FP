using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using DG.Tweening;
using UnityEngine;

namespace Descending.Interactables
{
    public class KeyPickup : MonoBehaviour
    {
        [SerializeField] private Transform _modelTransform = null;
        [SerializeField] private float _rotateSpeed = 1f;
        [SerializeField] private float _verticalMovement = 1f;
        [SerializeField] private float _movementSpeed = 1f;
        [SerializeField] private KeyTypes _keyType = KeyTypes.None;
        
        private Tween _moveTween = null;
        private Tween _rotateTween = null;

        public KeyTypes KeyType => _keyType;

        private void Start()
        {
            _moveTween = _modelTransform.transform.DOLocalMoveY(_verticalMovement, _movementSpeed).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutCubic);
            _rotateTween = _modelTransform.transform.DORotate(new Vector3(0f,360f,0f), _rotateSpeed, RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);
        }
        
        private void OnDestroy()
        {
            _moveTween.Kill();
            _rotateTween.Kill();
        }
    }
}
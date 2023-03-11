using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Units;
using DG.Tweening;
using DunGen;
using UnityEngine;

namespace Descending.Interactables
{
    public class DoorSingle : MonoBehaviour, IInteractable, IKeyLock
    {
        [SerializeField] private GameObject _doorObject = null;
        [SerializeField] private float _rotateTo = 0f;
        [SerializeField] private float _rotateDuration = 1f;
        [SerializeField] private bool _isLocked = false;
        [SerializeField] private bool _isOpen = false;
        [SerializeField] private bool _isRotating = false;
        [SerializeField] private Key _key = null;

        private Tween _rotateTween = null;
        
        public void Interact(Unit actor)
        {
            if (_isRotating == true) return;
            
            if (_isLocked == true)
            {
                if (ResourcesManager.Instance.HasKey(_key))
                {
                    Unlock();
                }
                
                return;
            }
            
            if (_isOpen == false)
            {
                Open();
            }
            else
            {
                Close();
            }
        }

        private IEnumerator DelayedInteract(bool isOpen)
        {
            yield return new WaitForSeconds(_rotateDuration);
            _isOpen = isOpen;
            _isRotating = false;
        }

        private void Open()
        {
            _rotateTween = _doorObject.transform.DORotate(new Vector3(0f, _rotateTo, 0f), _rotateDuration, RotateMode.LocalAxisAdd);
            _isRotating = true;
            
            StartCoroutine(DelayedInteract(true));
            StartCoroutine(DelayedClose(5f));
        }

        private void Close()
        {
            _rotateTween = _doorObject.transform.DORotate(new Vector3(0f, -_rotateTo, 0f), _rotateDuration, RotateMode.LocalAxisAdd);
            _isRotating = true;
            StartCoroutine(DelayedInteract(false));
        }

        private IEnumerator DelayedClose(float delay)
        {
            yield return new WaitForSeconds(delay);
            
            Close();
        }

        public void Unlock()
        {
            Debug.Log("Unlocking Door: " + _key.Name + " used");
            _isLocked = false;
            ResourcesManager.Instance.UseKey(_key);
        }

        public void OnKeyAssigned(Key key, KeyManager manager)
        {
            _key = key;
        }

        private void OnDestroy()
        {
            _rotateTween.Kill();
        }
    }
}

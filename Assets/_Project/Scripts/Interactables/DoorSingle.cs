using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using DG.Tweening;
using UnityEngine;

namespace Descending.Interactables
{
    public class DoorSingle : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject _doorObject = null;
        [SerializeField] private float _rotateTo = 0f;
        [SerializeField] private float _rotateDuration = 1f;
        [SerializeField] private bool _isOpen = false;
        [SerializeField] private bool _isRotating = false;
        
        public void Interact(Unit interacter)
        {
            if (_isRotating == true) return;

            if (_isOpen == false)
            {
                _doorObject.transform.DORotate(new Vector3(0f, _rotateTo, 0f), _rotateDuration, RotateMode.LocalAxisAdd);
                _isRotating = true;
                StartCoroutine(DelayedInteract(true));
            }
            else
            {
                _doorObject.transform.DORotate(new Vector3(0f, -_rotateTo, 0f), _rotateDuration, RotateMode.LocalAxisAdd);
                _isRotating = true;
                StartCoroutine(DelayedInteract(false));
            }
        }

        private IEnumerator DelayedInteract(bool isOpen)
        {
            yield return new WaitForSeconds(_rotateDuration);
            _isOpen = isOpen;
            _isRotating = false;
        }
    }
}

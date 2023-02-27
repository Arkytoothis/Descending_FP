using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Equipment;
using Descending.Units;
using DG.Tweening;
using UnityEngine;

namespace Descending.Interactables
{
    public class TreasureChest : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject _doorObject = null;
        [SerializeField] private float _rotateTo = 0f;
        [SerializeField] private float _rotateDuration = 1f;
        [SerializeField] private bool _isOpen = false;
        [SerializeField] private bool _isRotating = false;

        private TreasureData _treasureData = null;
        
        public void Interact(Unit interacter)
        {
            if (_isRotating == true) return;

            if (_isOpen == false)
            {
                _doorObject.transform.DORotate(new Vector3(_rotateTo, 0f, 0f), _rotateDuration, RotateMode.LocalAxisAdd);
                _isRotating = true;
                StartCoroutine(DelayedInteract(true));
            }
            // else
            // {
            //     _doorObject.transform.DORotate(new Vector3(-_rotateTo, 0f, 0f), _rotateDuration, RotateMode.LocalAxisAdd);
            //     _isRotating = true;
            //     StartCoroutine(DelayedInteract(false));
            // }
        }

        private IEnumerator DelayedInteract(bool isOpen)
        {
            yield return new WaitForSeconds(_rotateDuration);
            _isOpen = isOpen;
            _isRotating = false;
            ResourcesManager.Instance.AddCoins(_treasureData.Coins);
            ResourcesManager.Instance.AddGems(_treasureData.Gems);
            ResourcesManager.Instance.AddSupplies(_treasureData.Supplies);

            foreach (Item item in _treasureData.Items)
            {
                StockpileManager.Instance.AddItem(item);
            }
            
            Destroy(gameObject);
        }

        public void SetTreasureData(TreasureData treasureData)
        {
            _treasureData = treasureData;
        }
    }
}

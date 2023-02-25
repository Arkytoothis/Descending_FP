using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using Descending.Attributes;
using UnityEngine;
using UnityEngine.Serialization;

namespace Descending.Core
{
    [System.Serializable]
    public class PortraitMount : MonoBehaviour
    {
        [SerializeField] private Transform _modelMount = null;
        [SerializeField] private GameObject _model = null;
        [SerializeField] private Camera _camClose = null;
        [SerializeField] private Camera _camFar = null;

        [SerializeField] RenderTexture _rtClose = null;
        [SerializeField] RenderTexture _rtFar = null;

        public RenderTexture RtClose => _rtClose;
        public RenderTexture RtFar => _rtFar;
        public GameObject Model => _model;

        public void Setup(Hero hero)
        {
            _rtClose = new RenderTexture(256, 256, 32);
            _camClose.targetTexture = _rtClose;
            _rtFar = new RenderTexture(2560, 3760, 32);
            _camFar.targetTexture = _rtFar;
            SetModel(hero);

            hero.PortraitRenderer.MountCloseCamera(_camClose);
            hero.PortraitRenderer.MountFarCamera(_camFar);

            //Refresh();
        }

        public void SetModel(Hero hero)
        {
            if (hero != null)
            {
                //_modelMount.ClearTransform();
                _model = hero.PortraitModel;
                hero.SetPortrait(this);
                hero.PortraitModel.transform.SetParent(_modelMount, false);
                hero.PortraitRenderer.MountCloseCamera(_camClose);
                hero.PortraitRenderer.MountFarCamera(_camFar);

                Refresh();
            }
        }

        public void DisableCloseCamera()
        {
            _camClose.gameObject.SetActive(false);
        }

        public void DisableFarCamera()
        {
            _camFar.gameObject.SetActive(false);
        }

        public void EnableCloseCamera()
        {
            _camClose.gameObject.SetActive(true);
        }

        public void EnableFarCamera()
        {
            _camFar.gameObject.SetActive(true);
        }

        public RenderTexture GetCloseRt()
        {
            StartCoroutine(RefreshWithDelay());
            return _camClose.targetTexture;
        }

        public RenderTexture GetFarRt()
        {
            StartCoroutine(RefreshWithDelayFar());
            return _camFar.targetTexture;
        }

        public void ClearMount()
        {
            _modelMount.ClearTransform();
            _model = null;
        }

        public void Refresh()
        {
            StartCoroutine(RefreshWithDelay());
            StartCoroutine(RefreshWithDelayFar());
        }

        private IEnumerator RefreshWithDelay()
        {
            EnableCloseCamera();

            yield return new WaitForSeconds(0.1f);

            DisableCloseCamera();
        }

        private IEnumerator RefreshWithDelayFar()
        {
            EnableFarCamera();

            yield return new WaitForSeconds(0.1f);

            DisableFarCamera();
        }
    }
}
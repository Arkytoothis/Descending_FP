using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using UnityEngine;

namespace Descending.Core
{
    public class ScreenShakeManager : MonoBehaviour
    {
        //[SerializeField] private float _defaultIntensity = 1f;
        //[SerializeField] private float _hitIntensity = 1f;
        [SerializeField] private float _bombIntensity = 5f;
        
        private void Start()
        {
            ThrowableProjectile.OnAnyThrowComplete += ThrowableProjectile_OnAnyThrowComplete;
        }

        private void ThrowableProjectile_OnAnyThrowComplete(object sender, EventArgs e)
        {
            ScreenShake.Instance.Shake(_bombIntensity);
        }
    }
}
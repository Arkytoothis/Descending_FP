using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Descending.Units
{
    public class SelectionArrow : MonoBehaviour
    {
        [SerializeField] private GameObject _indicatorObject;
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _height = 0.1f;
 
        void Update() 
        {
            Vector3 pos = _indicatorObject.transform.position;
            float newY = Mathf.Sin(Time.time * _speed);
            _indicatorObject.transform.position = new Vector3(pos.x, pos.y + newY * _height, pos.z);
        }
    }
}

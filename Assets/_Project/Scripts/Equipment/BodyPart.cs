using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Equipment
{
    public class BodyPart : MonoBehaviour
    {
        //[SerializeField] private SkinnedMeshRenderer _original = null;
        [SerializeField] private SkinnedMeshRenderer _prefab = null;
        [SerializeField] private Transform _rootBone = null;

        private void Start()
        {
            GameObject clone = Instantiate(_prefab.gameObject, transform);
            //_prefab.bones = _original.bones;
            _prefab.rootBone = _rootBone;
        }
    }
}
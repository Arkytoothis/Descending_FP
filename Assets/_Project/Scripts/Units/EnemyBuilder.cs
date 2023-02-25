using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Descending.Core
{
    public class EnemyBuilder : MonoBehaviour
    {
        [SerializeField] private Transform _root = null;

        private Enemy _enemy = null;
        private GameObject _leftHandMount = null;
        private GameObject _rightHandMount = null;
        
        private void SetupComponents()
        {
            _enemy = GetComponentInParent<Enemy>();
            _root = RecursiveFindChild(transform, "Root");
            
            Transform leftHandBone = RecursiveFindChild(_root, "Hand_L");

            if (leftHandBone != null)
            {
                Transform existingMount = RecursiveFindChild(_root, "Left Hand Mount");
                
                if (existingMount == null)
                {
                    _leftHandMount = new GameObject();
                    _leftHandMount.name = "Left Hand Mount";
                }
                
                _leftHandMount.transform.SetParent(leftHandBone, false);
            }

            _enemy.SetLeftHandMount(_leftHandMount.transform);
            
            Transform rightHandBone = RecursiveFindChild(_root, "Hand_R");
            if (rightHandBone != null)
            {
                Transform existingMount = RecursiveFindChild(_root, "Right Hand Mount");
                
                if (existingMount == null)
                {
                    _rightHandMount = new GameObject();
                    _rightHandMount.name = "Right Hand Mount";
                }
                
                _rightHandMount.transform.SetParent(rightHandBone, false);
            }
            
            _enemy.SetRightHandMount(_rightHandMount.transform);

        }

        [Button]
        public void Build()
        {
            SetupComponents();

            Debug.Log("Enemy Build Complete");
        }
        
        Transform RecursiveFindChild(Transform parent, string childName)
        {
            foreach (Transform child in parent)
            {
                if(child.name == childName)
                {
                    return child;
                }
                else
                {
                    Transform found = RecursiveFindChild(child, childName);
                    if (found != null)
                    {
                        return found;
                    }
                }
            }
            return null;
        }
    }
}
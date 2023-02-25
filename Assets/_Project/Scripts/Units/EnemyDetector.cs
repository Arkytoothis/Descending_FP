using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Units
{
    public class EnemyDetector : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                Enemy enemy = other.gameObject.GetComponent<Enemy>();

                if (enemy != null)
                {
                    if (enemy.IsActive == false)
                    {
                        //Debug.Log("Activating Enemy: " + enemyUnit.GetShortName());
                        enemy.Activate();
                    }
                }
            }
        }
    }
}
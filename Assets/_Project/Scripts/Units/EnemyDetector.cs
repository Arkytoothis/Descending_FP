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
                EnemyUnit enemyUnit = other.gameObject.GetComponent<EnemyUnit>();

                if (enemyUnit != null)
                {
                    if (enemyUnit.IsActive == false)
                    {
                        //Debug.Log("Activating Enemy: " + enemyUnit.GetShortName());
                        enemyUnit.Activate();
                    }
                }
            }
        }
    }
}
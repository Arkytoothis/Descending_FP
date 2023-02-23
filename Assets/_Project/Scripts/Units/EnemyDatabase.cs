using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using UnityEngine;

namespace Descending.Units
{
    [CreateAssetMenu(fileName = "Enemy Database", menuName = "Descending/Database/Enemy Database")]
    public class EnemyDatabase : ScriptableObject
    {
        [SerializeField] private EnemiesDictionary _data = null;
        public EnemiesDictionary Dictionary { get => _data; }

        public EnemyDefinition GetEnemy(string key)
        {
            if (Contains(key))
            {
                return _data[key];
            }
            else
            {
                Debug.Log("Enemy Key: (" + key + ") does not exist");
                return null;
            }
        }

        public string GetRandomItemKey()
        {
            return Utilities.RandomKey(_data);
        }

        public bool Contains(string key)
        {
            return _data.ContainsKey(key);
        }
    }
}
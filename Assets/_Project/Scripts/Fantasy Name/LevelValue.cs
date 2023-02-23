using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descension.Units
{
    [System.Serializable]
    public class LevelValue
    {
        [SerializeField] private int _value = 0;
        [SerializeField] private int _level = 0;

        public LevelValue()
        {
        }

        public LevelValue(int value, int level)
        {
            _value = value;
            _level = level;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using UnityEngine;

namespace Descending.Party
{
    [System.Serializable]
    public class PartySaveData
    {
        //[SerializeField] private Vector3 _worldPosition;
        [SerializeField] private HeroSaveData[] _heroes = null;

        //public Vector3 WorldPosition => _worldPosition;
        public HeroSaveData[] Heroes => _heroes;

        public PartySaveData()
        {
            _heroes = null;
            //_worldPosition = Vector3.zero;
        }

        public PartySaveData(List<Hero> heroList)
        {
            //_worldPosition = worldPosition;
            _heroes = new HeroSaveData[heroList.Count];
            
            for (int i = 0; i < heroList.Count; i++)
            {
                _heroes[i] = new HeroSaveData(heroList[i]);
            }
        }
    }
}
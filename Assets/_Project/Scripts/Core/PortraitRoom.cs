using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using UnityEngine;

namespace Descending.Core
{
    public class PortraitRoom : MonoBehaviour
    {
        [SerializeField] private GameObject _portraitMountPrefab = null;
        [SerializeField] private Transform _portraitMountsParent = null;

        private List<PortraitMount> _portraits = null;

        private void Awake()
        {
            _portraits = new List<PortraitMount>();
        }
        
         public void Setup(List<HeroUnit> heroes)
         {
             //Debug.Log("PortraitRoom.Setup");
             for (int i = 0; i < _portraits.Count; i++)
             {
                 _portraits[i].ClearMount();
             }

             for (int i = 0; i < heroes.Count; i++)
             {
                 GameObject clone = Instantiate(_portraitMountPrefab, _portraitMountsParent);
                 clone.transform.localPosition = new Vector3(i * 10f, 0, 0);
             
                 PortraitMount mount = clone.GetComponent<PortraitMount>();
                 mount.Setup(heroes[i]);
                 _portraits.Add(mount);
             }
             
             SyncParty(heroes);
         }

         public void SyncParty(List<HeroUnit> heroes)
         {
             if (_portraits == null) return;

             for (int i = 0; i < _portraits.Count; i++)
             {
                 _portraits[i].SetModel(heroes[i]);
                 _portraits[i].Refresh();
             }
         }

         public void RefreshCameras()
         {
             for (int i = 0; i < _portraits.Count; i++)
             {
                 _portraits[i].Refresh();
             }
         }
    }
}

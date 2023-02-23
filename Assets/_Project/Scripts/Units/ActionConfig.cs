using System.Collections;
using System.Collections.Generic;
using Descending.Abilities;
using Descending.Equipment;
using UnityEngine;

namespace Descending.Units
{
    [System.Serializable]
    public class ActionConfig
    {
        private Ability _ability = null;
        private Item _item = null;

        public Ability Ability => _ability;
        public Item Item => _item;

        public ActionConfig()
        {
            _ability = null;
            _item = null;
        }

        public ActionConfig(Ability ability)
        {
            _ability = ability;
            _item = null;
        }

        public ActionConfig(Item item)
        {
            _ability = null;
            _item = item;
        }
        
        public void SetAbility(Ability ability)
        {
            _ability = ability;
            _item = null;
        }

        public void SetItem(Item item)
        {
            _ability = null;
            _item = item;
        }
    }
}
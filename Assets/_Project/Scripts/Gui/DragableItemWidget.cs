using System.Collections;
using System.Collections.Generic;
using Descending.Equipment;
using UnityEngine;

namespace Descending.Gui
{
    public abstract class DragableItemWidget : MonoBehaviour
    {
        protected Item _item = null;
        protected int _index = -1;
        
        public Item Item => _item;
        public int Index => _index;

        public abstract void SetItem(Item item);
        public abstract void Clear();
    }
}
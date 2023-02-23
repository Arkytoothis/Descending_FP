using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Gui
{
    public enum GameWindows { Menu, Party, Village, Dungeon, Encounter, Number, None }
    
    public abstract class GameWindow : MonoBehaviour
    {
        //[SerializeField, SoundGroup] protected string _openSound = "";
        //[SerializeField, SoundGroup] protected string _closeSound = "";

        protected WindowManager _manager = null;
        protected bool _isOpen = false;

        public bool IsOpen => _isOpen;

        public abstract void Setup(WindowManager manager);
        public abstract void Open();
        public abstract void Close();
    }
}

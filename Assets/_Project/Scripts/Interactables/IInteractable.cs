using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using UnityEngine;

namespace Descending.Interactables
{
    public interface IInteractable
    {
        public abstract void Interact(Unit interacter);
    }
}

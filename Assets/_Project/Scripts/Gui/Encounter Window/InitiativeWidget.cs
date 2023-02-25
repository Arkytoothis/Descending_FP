using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using TMPro;
using UnityEngine;

namespace Descending.Gui
{
    public abstract class InitiativeWidget : MonoBehaviour
    {
        [SerializeField] protected TMP_Text _nameLabel = null;
        [SerializeField] protected TMP_Text _initiativeLabel = null;

        protected int _index = -1;
        protected int _initiativeRoll = 0;

        public int Index => _index;
        public int InitiativeRoll => _initiativeRoll;
    }
}

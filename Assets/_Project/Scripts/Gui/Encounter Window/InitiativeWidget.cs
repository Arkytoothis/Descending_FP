using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Descending.Gui
{
    public abstract class InitiativeWidget : MonoBehaviour
    {
        [SerializeField] protected Image _selectionBorder = null;
        [SerializeField] protected Image _deselectedImage = null;
        [SerializeField] protected TMP_Text _nameLabel = null;
        [SerializeField] protected Color _nameColor = Color.white;
        [SerializeField] protected TMP_Text _initiativeLabel = null;
        [SerializeField] protected VitalBar _lifeBar = null;

        protected int _index = -1;
        protected int _initiativeRoll = 0;

        public int Index => _index;
        public int InitiativeRoll => _initiativeRoll;

        public abstract void Select();
        public abstract void Deselect();
    }
}

using System.Collections;
using System.Collections.Generic;
using Descending.Encounters;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Gui
{
    public class EncounterWindow : GameWindow
    {
        [SerializeField] private InitiativePanel _initiativePanel = null;
        
        [SerializeField] private BoolEvent onEndEncounter = null;

        private Encounter _encounter = null;
        
        public override void Setup(WindowManager manager)
        {
            _manager = manager;
            Close();
        }

        public override void Open()
        {
            gameObject.SetActive(true);
            _isOpen = true;
        }

        public override void Close()
        {
            gameObject.SetActive(false);
            _isOpen = false;
        }

        public void EndEncounterButton_OnClick()
        {
            _manager.CloseAll();
            onEndEncounter.Invoke(true);
        }

        public void EncounterTriggered(Encounter encounter)
        {
            _encounter = encounter;
            _initiativePanel.Setup(encounter);
        }
    }
}
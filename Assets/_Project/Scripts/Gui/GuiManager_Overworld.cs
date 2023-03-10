using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Encounters;
using UnityEngine;

namespace Descending.Gui
{
    public class GuiManager_Overworld : MonoBehaviour
    {
        [SerializeField] private GameObject _topPanelPrefab = null;
        [SerializeField] private GameObject _partyPanelPrefab = null;
        [SerializeField] private GameObject _actionsPanelPrefab = null;
        [SerializeField] private GameObject _questPanelPrefab = null;
        [SerializeField] private GameObject _miniMapPanelPrefab = null;
        [SerializeField] private GameObject _tooltipPrefab = null;
        [SerializeField] private GameObject _dragCursorPrefab = null;
        
        [SerializeField] private WindowManager _windowManager = null;

        private Tooltip _tooltip = null;
        private PartyPanel _partyPanel = null;
        private ActionsPanel _actionsPanel = null;
        private TopPanel _topPanel = null;
        private MiniMapPanel _miniMapPanel = null;
        private GameObject _questPanel = null;
        
        private DragCursor _dragCursor = null;
        
        public void Setup()
        {
            SetupTopPanel();
            SetupPartyPanel();
            SetupActionsPanel();
            SetupQuestPanel();
            SetupMinimapPanel();
            
            _windowManager.Setup();
            
            SetupTooltip();
            SetupDragCursor();
        }

        private void SetupTopPanel()
        {
            GameObject clone = Instantiate(_topPanelPrefab, transform);
            _topPanel = clone.GetComponent<TopPanel>();
            _topPanel.Setup();
        }

        private void SetupPartyPanel()
        {
            GameObject clone = Instantiate(_partyPanelPrefab, transform);
            _partyPanel = clone.GetComponent<PartyPanel>();
            _partyPanel.Setup();
        }

        private void SetupActionsPanel()
        {
            GameObject clone = Instantiate(_actionsPanelPrefab, transform);
            _actionsPanel = clone.GetComponent<ActionsPanel>();
            _actionsPanel.Setup();
        }

        private void SetupQuestPanel()
        {
            GameObject clone = Instantiate(_questPanelPrefab, transform);
            _questPanel = clone;
        }

        private void SetupMinimapPanel()
        {
            GameObject clone = Instantiate(_miniMapPanelPrefab, transform);
            _miniMapPanel = clone.GetComponent<MiniMapPanel>();
            _miniMapPanel.Setup();
        }

        private void SetupTooltip()
        {
            GameObject clone = Instantiate(_tooltipPrefab, transform);
            _tooltip = clone.GetComponent<Tooltip>();
            _tooltip.Setup();
        }

        private void SetupDragCursor()
        {
            GameObject clone = Instantiate(_dragCursorPrefab, transform);
            _dragCursor = clone.GetComponent<DragCursor>();
            _dragCursor.Setup();
            _dragCursor.transform.SetAsLastSibling();
        }

        public void OnEncounterTriggered(Encounter encounter)
        {
            _topPanel.gameObject.SetActive(false);
            _miniMapPanel.gameObject.SetActive(false);
            _questPanel.SetActive(false);
            _partyPanel.SetMode(UiModes.Combat);
            _actionsPanel.SetMode(UiModes.Combat);
            _windowManager.EncounterTriggered(encounter);
            _windowManager.SetInCombat(true);
        }

        public void OnEndEncounter(bool b)
        {
            _topPanel.gameObject.SetActive(true);
            _miniMapPanel.gameObject.SetActive(true);
            _partyPanel.SetMode(UiModes.World);
            _actionsPanel.SetMode(UiModes.World);
            _questPanel.SetActive(true);
            _windowManager.SetInCombat(false);
        }
    }
}

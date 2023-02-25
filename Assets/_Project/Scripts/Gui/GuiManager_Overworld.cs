using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using UnityEditor;
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
    }
}

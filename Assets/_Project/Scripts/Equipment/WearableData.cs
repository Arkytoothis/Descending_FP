using System.Collections;
using System.Collections.Generic;
using System.Text;
using DarkTonic.MasterAudio;
using Descending.Core;
using UnityEngine;

namespace Descending.Equipment
{
    [System.Serializable]
    public class WearableData
    {
        [SerializeField] private bool _hasData;
        [SerializeField] private int _armor = 0;
        [SerializeField] private int _block = 0;
        [SerializeField] private int _dodge = 0;
        [SerializeField] private int _perceptionModifier = 0;
        [SerializeField] private WearableType _wearableType = WearableType.None;
        [SerializeField] private HeadCoverType _headCoverType = HeadCoverType.None;
        [SerializeField, SoundGroup] private List<string> _stepSounds = null;

        public bool HasData => _hasData;
        public int Armor => _armor;
        public int Block => _block;
        public int Dodge => _dodge;
        public int PerceptionModifier => _perceptionModifier;
        public WearableType WearableType => _wearableType;
        public HeadCoverType HeadCoverType => _headCoverType;

        public WearableData(WearableData wearableData)
        {
            _hasData = wearableData._hasData;
            _armor = wearableData._armor;
            _block = wearableData._block;
            _dodge = wearableData._dodge;
            _perceptionModifier = wearableData._perceptionModifier;
            _wearableType = wearableData._wearableType;
            _headCoverType = wearableData._headCoverType;
        }

        public string GetTooltipText()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Armor: ");
            sb.Append(_armor);
            sb.Append("\n");

            sb.Append("Block: ");
            sb.Append(_block);
            sb.Append("\n");

            sb.Append("Dodge: ");
            sb.Append(_dodge);
            sb.Append("\n");

            sb.Append("Perception Modifier: ");
            sb.Append(_perceptionModifier);
            sb.Append("\n");

            return sb.ToString();
        }

        public string GetItemWidgetText()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("A: ");
            sb.Append(_armor);
            sb.Append(" B: ");
            sb.Append(_block);
            sb.Append(" D: ");
            sb.Append(_dodge);
            sb.Append(" P: ");
            sb.Append(_perceptionModifier);

            return sb.ToString();
        }

         public string GetStepSound()
         {
             if (_stepSounds == null || _stepSounds.Count == 0)
             {
                 return "";
             }
             else
             {
                 return _stepSounds[Random.Range(0, _stepSounds.Count)];
             }
        }
    }
}
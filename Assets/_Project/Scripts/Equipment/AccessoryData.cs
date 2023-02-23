using System.Collections;
using System.Collections.Generic;
using System.Text;
using Descending.Core;
using UnityEngine;

namespace Descending.Equipment
{
    [System.Serializable]
    public class AccessoryData
    {
        [SerializeField] private bool _hasData = true;
        [SerializeField] private AccessoryType _accessoryType = AccessoryType.None;

        public bool HasData { get => _hasData; }
        public AccessoryType AccessoryType { get => _accessoryType; }

        public AccessoryData(AccessoryData accessoryData)
        {
            _hasData = accessoryData._hasData;
            _accessoryType = accessoryData._accessoryType;
        }

        public string GetTooltipText()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Type: ");
            sb.Append(AccessoryType);
            sb.Append("\n");

            if (AccessoryType == AccessoryType.Food)
            {
                sb.Append("Restores ");
            }
            else if (AccessoryType == AccessoryType.Drink)
            {
                sb.Append("Restores ");
            }
            else if (AccessoryType == AccessoryType.Potion)
            {
                sb.Append("Restores ");
            }
            else if (AccessoryType == AccessoryType.Scroll)
            {
                sb.Append("Casts ");
            }
            else if (AccessoryType == AccessoryType.Spellbook)
            {
                sb.Append("Teaches ");
            }
            else if (AccessoryType == AccessoryType.Bomb)
            {
            }

            return sb.ToString();
        }

        public string GetItemWidgetText()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Type: ");
            sb.Append(AccessoryType);
            sb.Append("\n");

            if (AccessoryType == AccessoryType.Food)
            {
                sb.Append("Restores ");
            }
            else if (AccessoryType == AccessoryType.Drink)
            {
                sb.Append("Restores ");
            }
            else if (AccessoryType == AccessoryType.Potion)
            {
                sb.Append("Restores ");
            }
            else if (AccessoryType == AccessoryType.Scroll)
            {
                sb.Append("Casts ");
            }
            else if (AccessoryType == AccessoryType.Spellbook)
            {
                sb.Append("Teaches ");
            }
            else if (AccessoryType == AccessoryType.Bomb)
            {
                sb.Append("Throw ");
            }

            return sb.ToString();
        }
    }
}
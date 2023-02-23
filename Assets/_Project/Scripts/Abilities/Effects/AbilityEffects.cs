using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Descending.Abilities
{
    [System.Serializable]
    public class AbilityEffects
    {
        [SerializeReference] private List<AbilityEffect> _data = null;

        public List<AbilityEffect> Data { get => _data; }

        public string GetTooltipText()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < _data.Count; i++)
            {
                sb.Append(_data[i].GetTooltipText());
            }

            return sb.ToString();
        }
    }
}
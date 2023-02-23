using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Descending.Equipment
{
    [CreateAssetMenu(fileName = "Encumbrance Database", menuName = "Descending/Database/Encumbrance Database")]
    public class EncumbranceLevelDatabase : ScriptableObject
    {
        [SerializeField] private List<EncumbranceLevel> _data = null;
        public List<EncumbranceLevel> Data { get => _data; }

        public EncumbranceLevel GetEncumbrance(int index)
        {
            return _data[index];
        }
    }
}
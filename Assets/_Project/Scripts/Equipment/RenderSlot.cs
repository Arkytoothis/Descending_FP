using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using UnityEngine;

namespace Descending.Equipment
{
    [System.Serializable]
    public class RenderSlot
    {
        [SerializeField] private BodyParts _bodyPart = BodyParts.None;
        [SerializeField] private int _index = -1;

        public BodyParts BodyPart => _bodyPart;

        public int Index => _index;

        public RenderSlot(BodyParts bodyPart, int index)
        {
            _bodyPart = bodyPart;
            _index = index;
        }
    }
}
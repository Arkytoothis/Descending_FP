using Descending.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Descending.Equipment
{
    public class ItemDetails : MonoBehaviour
    {
        [SerializeField] string key = "";
        [SerializeField] new string name = "";
        //[SerializeField] EquipmentSlot equipmentSlot = EquipmentSlot.None;
        //[SerializeField] BodyParts renderSlots = BodyParts.None;
        [SerializeField] int slotIndex = -1;

        public string Key { get => key; }
        public string Name { get => name; }
        //public EquipmentSlot EquipmentSlot { get => equipmentSlot; }
        //public BodyParts RenderSlots { get => renderSlots; }
        public int SlotIndex { get => slotIndex; }
    }
}
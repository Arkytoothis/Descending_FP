using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Equipment.Enchantments
{
    [System.Serializable]
    public class EnchantmentEffect
    {
        public virtual string GetTooltipText() { return ""; }
    }
}
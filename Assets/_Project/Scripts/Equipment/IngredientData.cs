using Descending.Core;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Descending.Equipment
{
    public enum IngredientTypes
    {
        Cloth, Crystal, Food, Leather, Metal, Stone, Wood, Organic,
        Number, None
    }
    
    [System.Serializable]
    public class IngredientData
    {
        [SerializeField] private bool _hasData = true;
        [SerializeField] private IngredientTypes _type = IngredientTypes.None;

        public bool HasData => _hasData;
        public IngredientTypes Type => _type;

        public IngredientData(IngredientData ingredientData)
        {
            _hasData = ingredientData._hasData;
        }

        public string GetTooltipText()
        {
            StringBuilder sb = new StringBuilder();

            // sb.Append("Speed: ");
            // sb.Append(_speed);
            // sb.Append("\n");

            return sb.ToString();
        }
    }
}
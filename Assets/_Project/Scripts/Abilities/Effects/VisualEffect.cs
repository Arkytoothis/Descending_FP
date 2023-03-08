using System.Collections.Generic;
using System.Text;
using Descending.Attributes;
using Descending.Core;
using Descending.Units;
using UnityEngine;

namespace Descending.Abilities
{
    [System.Serializable]
    public class VisualEffect : AbilityEffect
    {
        [SerializeField] private GameObject _effectPrefab = null;

        public override string GetTooltipText()
        {
            StringBuilder sb = new StringBuilder();

            //sb.Append("Restores ").Append(_minimumValue).Append(" - ").Append(_maximumValue).Append(" ").Append(_attribute.Name).Append("\n");

            return sb.ToString();
        }

        public override void Process(Ability ability, Unit user, List<Unit> targets)
        {
            //Debug.Log("Processing RestoreEffect");
            if (_affects == AbilityEffectAffects.User)
            {
                GameObject clone = GameObject.Instantiate(_effectPrefab, null);
                clone.transform.position = user.transform.position;
            }
            else if (_affects == AbilityEffectAffects.Target)
            {
                foreach (Unit target in targets)
                {
                    GameObject clone = GameObject.Instantiate(_effectPrefab, null);
                    clone.transform.position = target.transform.position;
                }
            }
        }
    }
}
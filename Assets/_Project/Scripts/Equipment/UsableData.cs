using System.Collections.Generic;
using System.Text;
using Descending.Abilities;
using Descending.Core;
using Descending.Units;
using UnityEngine;

namespace Descending.Equipment
{
    [System.Serializable]
    public class UsableData
    {
        [SerializeField] private bool _hasData = false;
        [SerializeField] private TargetTypes _targetType = TargetTypes.None;
        [SerializeField] private UsableTypes _usableType = UsableTypes.None;
        [SerializeField] private int _maxUses = 0;
        [SerializeField] private int _range = 0;
        [SerializeField] private float _cooldown = 0f;
        [SerializeField] private ProjectileDefinition _projectile = null;
        [SerializeReference] private AbilityEffects _effects = null;

        public bool HasData => _hasData;
        public int MaxUses => _maxUses;
        public int Range => _range;
        public TargetTypes TargetType => _targetType;
        public UsableTypes UsableType => _usableType;
        public AbilityEffects Effects => _effects;
        public float Cooldown => _cooldown;
        public ProjectileDefinition Projectile => _projectile;

        public UsableData(UsableData usableData)
        {
            _hasData = usableData._hasData;
            _targetType = usableData._targetType;
            _range = usableData._range;
            _maxUses = usableData.MaxUses;
            _effects = usableData.Effects;
            _cooldown = usableData.Cooldown;
        } 

        public void Use(Unit user, List<Unit> targets)
        {
            for (int i = 0; i < targets.Count; i++)
            {
                for (int j = 0; j < _effects.Data.Count; j++)
                {
                    _effects.Data[i].Process(user, targets);
                }
            }
        }

        public string GetTooltipText()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Append("Uses: ").Append(_maxUses).AppendLine();
            sb.Append(_effects.GetTooltipText());
            
            return sb.ToString();
        }

        public string GetItemWidgetText()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Uses: ").Append(_maxUses);

            return sb.ToString();
        }
    }
}
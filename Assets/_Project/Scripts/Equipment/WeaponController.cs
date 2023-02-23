using Descending.Core;
using UnityEngine;

namespace Descending.Equipment
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private ItemDefinition _itemDefinition;
        [SerializeField] private AnimatorOverrideController _override;
        [SerializeField] private Transform _hitTransform = null;
        [SerializeField] private string _hitSoundKey = "";
        [SerializeField] private GameObject _attackEffectPrefab = null;
        [SerializeField] private GameObject _model = null;

        private Item _item = null;
        public Item Item => _item;
        public Transform HitTransform => _hitTransform;
        public string HitSoundKey => _hitSoundKey;
        public AnimatorOverrideController Override => _override;
        public ItemDefinition ItemDefinition => _itemDefinition;

        public void Setup(Item item)
        {
            _item = item;
        }

        public void ScaleModel(float scale)
        {
            if (_model != null)
            {
                Debug.Log("Scaling Model: " + scale);
                _model.transform.localScale = new Vector3(scale, scale, scale);
            }
        }
        
        public void ProcessHit()
        {
            PlayHitEffect();
            PlayHitSound();
        }

        private void PlayHitEffect()
        {
            if (_attackEffectPrefab != null)
            {
                //PoolBoss.SpawnInPool(_attackEffectPrefab.transform, _hitTransform.position, _hitTransform.rotation);
            }

            //onSpawnHitEffect.Invoke(new EffectParameters(hitEffectKey, position));
        }

        private void PlayHitSound()
        {
            if (_hitSoundKey != "")
            {
                //MasterAudio.PlaySound3DAtTransform(_hitSoundKey, _hitTransform);
            }
        }
    }
}
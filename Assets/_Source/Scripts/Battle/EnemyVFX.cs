using _Source.Scripts.Projectiles;
using UnityEngine;

namespace _Source.Scripts.Battle
{
    public class EnemyVFX : MonoBehaviour
    {
        [SerializeField] private RewardEffect _rewardEffectPrefab;
        [SerializeField] private DamageTextEffect _damageTextEffectPrefab;

        public void PlayRewardEffect(Vector3 position, int reward)
        {
            var effect = Instantiate(_rewardEffectPrefab);
            effect.Play(position, reward);
        }

        public void PlayDamageEffect(Vector3 position, DamageDTO dto)
        {
            var effect = Instantiate(_damageTextEffectPrefab);
            effect.Play(position, dto);
        }
    }
}
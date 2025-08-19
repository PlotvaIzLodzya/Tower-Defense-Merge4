using _Source.Scripts.Battle;
using _Source.Scripts.Helpers;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{
    [CreateAssetMenu(fileName = nameof(OnStayOnEnemy), menuName = NamingConstant.ProjectilesBehaviour + "/" + NamingConstant.OnStay + "/" + nameof(OnStayOnEnemy))]
    public class OnStayOnEnemy : ScriptableObject
    {
        [SerializeField] private OnHitBehaviour _hitBehaviour;
        [SerializeField] private float _delay;

        public void OnStay(Enemy enemy, Projectile projectile, ref float elapsedTime)
        {
            if (elapsedTime > _delay)
            {
                _hitBehaviour.OnHit(enemy, projectile);
                elapsedTime = 0;
            }
            else
            {
                elapsedTime += Time.deltaTime;
            }
        }
    }
}
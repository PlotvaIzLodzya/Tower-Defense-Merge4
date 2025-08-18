using _Source.Scripts.Battle;
using _Source.Scripts.Buildings;
using System.Collections;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{
    [CreateAssetMenu(fileName = nameof(StraightMovement), menuName = NamingConstant.ProjectilesBehaviour + "/" + NamingConstant.ProjectilesMovement + "/" + nameof(StraightMovement))]
    public class StraightMovement : ProjectileMovement
    {
        [SerializeField] private float _lifeTime;
       
        public override IEnumerator Moving(Enemy enemy, Projectile projectile)
        {
            var elapsedTime = 0f;

            var direction = (enemy.transform.position - projectile.transform.position).normalized;

            while(elapsedTime < _lifeTime)
            {
                projectile.transform.position += direction * projectile.Stats.Speed * Time.deltaTime;
                yield return null;
            }
        }
    }
}
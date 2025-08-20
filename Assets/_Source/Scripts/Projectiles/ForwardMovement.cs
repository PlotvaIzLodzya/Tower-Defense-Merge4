using System.Collections;
using _Source.Scripts.Battle;
using _Source.Scripts.Helpers;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{
    [CreateAssetMenu(fileName = nameof(ForwardMovement), menuName = NamingConstant.ProjectilesBehaviour + "/" + NamingConstant.ProjectilesMovement + "/" + nameof(ForwardMovement))]
    public class ForwardMovement : ProjectileMovement
    {
        public override IEnumerator Moving(Enemy enemy, Projectile projectile)
        {
            var elapsedTime = 0f;
            while (elapsedTime < LifeTime)
            {
                elapsedTime += Time.deltaTime;
                projectile.transform.position += projectile.transform.forward * projectile.Stats.Speed * Time.deltaTime;
                yield return null;
            }
        }
    }
}
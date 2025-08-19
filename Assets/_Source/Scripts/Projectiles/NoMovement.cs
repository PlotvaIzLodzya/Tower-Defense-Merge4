using _Source.Scripts.Battle;
using _Source.Scripts.Helpers;
using System.Collections;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{
    [CreateAssetMenu(fileName = nameof(NoMovement), menuName = NamingConstant.ProjectilesBehaviour + "/" + NamingConstant.ProjectilesMovement + "/" + nameof(NoMovement))]
    public class NoMovement : ProjectileMovement
    {
        public override IEnumerator Moving(Enemy enemy, Projectile projectile)
        {
            var direction = projectile.transform.position.CalculateDirection90Degrees(enemy.transform.position);
            var rotation = Quaternion.LookRotation(direction);
            projectile.transform.rotation = rotation;
            yield return new WaitForSeconds(LifeTime);
        }
    }
}
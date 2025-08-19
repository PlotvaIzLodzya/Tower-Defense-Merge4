using _Source.Scripts.Battle;
using _Source.Scripts.Helpers;
using System.Collections;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{
    [CreateAssetMenu(fileName = nameof(LinearMovement), menuName = NamingConstant.ProjectilesBehaviour + "/" + NamingConstant.ProjectilesMovement + "/" + nameof(LinearMovement))]
    public class LinearMovement : ProjectileMovement
    {
        public override IEnumerator Moving(Enemy enemy, Projectile projectile)
        {
            var direction = projectile.transform.position.CalculateDirection90Degrees(enemy.transform.position);
            var elapsedTime = 0f;
            var rotation = Quaternion.LookRotation(direction);
            projectile.transform.rotation = rotation;

            while(elapsedTime < LifeTime)
            {
                elapsedTime += Time.deltaTime;  
                projectile.transform.position += direction * projectile.Stats.Speed * Time.deltaTime;
                yield return null;
            }
        }


    }
}
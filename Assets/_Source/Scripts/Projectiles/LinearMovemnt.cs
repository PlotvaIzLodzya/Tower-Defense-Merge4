using _Source.Scripts.Battle;
using _Source.Scripts.Helpers;
using System.Collections;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{
    [CreateAssetMenu(fileName = nameof(LinearMovemnt), menuName = NamingConstant.ProjectilesBehaviour + "/" + NamingConstant.ProjectilesMovement + "/" + nameof(LinearMovemnt))]
    public class LinearMovemnt : ProjectileMovement
    {
        public override IEnumerator Moving(Enemy enemy, Projectile projectile)
        {
            var directionToTarget = (enemy.transform.position - projectile.transform.position).normalized;   
            var direction = CalculateDirection(directionToTarget);
            var elapsedTime = 0f;
            projectile.transform.LookAt(enemy.transform);

            while(elapsedTime < LifeTime)
            {
                elapsedTime += Time.deltaTime;  
                projectile.transform.position += direction * projectile.Stats.Speed * Time.deltaTime;
                yield return null;
            }
        }

        private Vector3 CalculateDirection(Vector3 target)
        {
            var x = Mathf.Abs(target.x);
            var z = Mathf.Abs(target.z);

            if(x >= z)
                target.z = 0f;
            else
                target.x = 0f;

            return target.normalized;

        }
    }
}
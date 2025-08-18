using _Source.Scripts.Battle;
using _Source.Scripts.Buildings;
using System.Collections;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{

    [CreateAssetMenu(fileName = nameof(ToTargetMovement), menuName = NamingConstant.ProjectilesBehaviour + "/" + NamingConstant.ProjectilesMovement + "/" + nameof(ToTargetMovement))]
    public class ToTargetMovement : ProjectileMovement
    {
        public override IEnumerator Moving(Enemy enemy, Projectile projectile)
        {
            while (IsCloseEnough(enemy, projectile))
            {
                projectile.transform.position = Vector3.MoveTowards(projectile.transform.position, enemy.transform.position, projectile.Stats.Speed * Time.deltaTime);
                projectile.transform.LookAt(enemy.transform);
                yield return null;
            }
        }

        private bool IsCloseEnough(Enemy target, Projectile projectile)
        {
            return Vector3.Distance(target.transform.position, projectile.transform.position) > projectile.Stats.Speed * Time.deltaTime;
        }
    }
}
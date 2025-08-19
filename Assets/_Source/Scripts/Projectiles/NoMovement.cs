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
            yield return new WaitForSeconds(LifeTime);
        }
    }
}
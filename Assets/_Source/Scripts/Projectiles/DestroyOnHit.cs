using _Source.Scripts.Battle;
using _Source.Scripts.Helpers;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{
    [CreateAssetMenu(fileName = nameof(DestroyOnHit), menuName = NamingConstant.ProjectilesBehaviour + "/" + NamingConstant.OnHit + "/" + nameof(DestroyOnHit))]
    public class DestroyOnHit : OnHitBehaviour
    {
        public override void OnHit(Enemy enemy, Projectile projectile)
        {
            projectile.Destroy();
        }
    }
}
using _Source.Scripts.Battle;
using _Source.Scripts.Helpers;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{

    [CreateAssetMenu(fileName = nameof(DealDamageAndDestroy), menuName = NamingConstant.ProjectilesBehaviour + "/" + NamingConstant.OnMovementEnd + "/" + nameof(DealDamageAndDestroy))]
    public class DealDamageAndDestroy : OnMovementEnd
    {
        public override void OnEnd(Enemy enemy, Projectile projectile)
        {
            var dto = new DamageDTO()
            {
                Damage = projectile.TowerStats.Damage,
                Position = projectile.transform.position,
            };
            enemy?.TakeDamage(dto);
            projectile.Destroy();
        }
    }
}
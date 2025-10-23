using _Source.Scripts.Battle;
using _Source.Scripts.Helpers;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{

    [CreateAssetMenu(fileName = nameof(DealDamageOnHit), menuName = NamingConstant.ProjectilesBehaviour + "/" + NamingConstant.OnHit + "/" + nameof(DealDamageOnHit))]
    public class DealDamageOnHit : OnHitBehaviour
    {
        public override void OnHit(Enemy enemy, Projectile projectile)
        {
            var dto = new DamageDTO()
            {
                Damage = projectile.TowerStats.Damage,
                Position = projectile.transform.position,
            };
            enemy.TakeDamage(dto);
        }
    }
}
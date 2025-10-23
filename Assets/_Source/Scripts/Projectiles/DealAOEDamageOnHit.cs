using _Source.Scripts.Battle;
using _Source.Scripts.Helpers;
using _Source.Scripts.ReferencesAndSources;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{
    [CreateAssetMenu(fileName = nameof(DealAOEDamageOnHit), menuName = NamingConstant.ProjectilesBehaviour + "/" + NamingConstant.OnHit + "/" + nameof(DealAOEDamageOnHit))]
    public class DealAOEDamageOnHit : OnHitBehaviour
    {
        [SerializeField] private EnemyPoolReference _enemyPool;

        public override void OnHit(Enemy enemy, Projectile projectile)
        {
            var dto = new DamageDTO()
            {
                Damage = projectile.TowerStats.Damage,
                Position = projectile.transform.position,
            };

            _enemyPool.Value.GetEnemys(enemys =>
            {
                foreach (var e in enemys)
                {
                    if (Vector3.Distance(e.transform.position, enemy.transform.position) < projectile.Stats.AOERadius)
                    {
                        e.TakeDamage(dto);
                    }
                }
            });
        }
    }
}
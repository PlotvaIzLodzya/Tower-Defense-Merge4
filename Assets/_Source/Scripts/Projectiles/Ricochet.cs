using _Source.Scripts.Battle;
using _Source.Scripts.Helpers;
using _Source.Scripts.ReferencesAndSources;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{
    [CreateAssetMenu(fileName = nameof(Ricochet), menuName = NamingConstant.ProjectilesBehaviour + "/" + NamingConstant.OnHit + "/" + nameof(Ricochet))]
    public class Ricochet : OnHitBehaviour
    {
        [SerializeField] private float _radius;
        [SerializeField] private int _amount;
        [SerializeField] private EnemyPoolReference _enemyPool;

        public override void OnHit(Enemy enemy, Projectile projectile)
        {
            if(projectile.HitCount < _amount)
            {
                var newProjectile = Instantiate(projectile, enemy.transform.position, Quaternion.identity);
                newProjectile.CopyStats(projectile);
                var closestEnemy = _enemyPool.Value.GetClosestTo(enemy, _radius);
                newProjectile.Launch(closestEnemy, projectile.TowerStats);
            }
        }
    }
}
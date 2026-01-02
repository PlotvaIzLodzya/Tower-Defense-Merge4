using _Source.Scripts.Battle;
using _Source.Scripts.Helpers;
using _Source.Scripts.ReferencesAndSources;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{
    [CreateAssetMenu(fileName = nameof(Shrapnel), menuName = NamingConstant.ProjectilesBehaviour + "/" + NamingConstant.OnHit + "/" + nameof(Shrapnel))]
    public class Shrapnel : OnHitBehaviour
    {
        [SerializeField] private int _shrapnelAmount;
        [SerializeField] private Projectile _shrapnelProjectile;
        [SerializeField] private EnemyPoolReference _enemyPool;

        public override void OnHit(Enemy enemy, Projectile projectile)
        {
            var dirs = VectorExtensions.GetRandomDirections(Vector3.right, 15f, _shrapnelAmount);
            for (int i = 0; i < _shrapnelAmount; i++)
            {
                var rot = Quaternion.LookRotation(dirs[i]);
                var newProjectile = Instantiate(_shrapnelProjectile, enemy.transform.position, rot);
                newProjectile.Launch(enemy, projectile.TowerStats);
            }
        }
    }
}
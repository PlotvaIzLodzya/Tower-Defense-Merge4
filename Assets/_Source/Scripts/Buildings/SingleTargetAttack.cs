using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class SingleTargetAttack : IAttack
    {
        private TowerStats _towerStats;
        private ITargetSeek _targetSeek;
        private Projectile _projectilePrefab;
        private Transform _shootPoint;
        

        public SingleTargetAttack(ITargetSeek targetSeek, TowerStats towerStats, Projectile projectilePrefab, Transform shootPoint)
        {
            _targetSeek = targetSeek;
            _towerStats = towerStats;
            _projectilePrefab = projectilePrefab;
            _shootPoint = shootPoint;
        }

        public void Attack()
        {
            if (_targetSeek.TryGetTarget(out var enemy))
            {
                var projectile = Object.Instantiate(_projectilePrefab,_shootPoint.position, Quaternion.identity);
                projectile.Launch(enemy, _towerStats);
            }
        }
    }
}
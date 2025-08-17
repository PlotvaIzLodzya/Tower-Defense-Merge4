using System.Collections;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class SingleTargetAttack : IAttack
    {
        private ITargetSeek _targetSeek;
        private TowerStats _towerStats;
        private Projectile _projectilePrefab;
        private Transform _shootPoint;
        
        public SingleTargetAttack(ITargetSeek targetSeek, TowerStats towerStats, Projectile projectilePrefab, Transform shootPoint)
        {
            _targetSeek = targetSeek;
            _towerStats = towerStats;
            _projectilePrefab = projectilePrefab;
            _shootPoint = shootPoint;
        }

        public IEnumerator Attack()
        {

            while (true)
            {
                var attackDelay = Mathf.Lerp(1, 0.2f, _towerStats.AttackSpeed / GameConfig.MaxAttackSpeed);

                if (_targetSeek.TryGetTarget(out var enemy))
                {
                    var projectile = Object.Instantiate(_projectilePrefab, _shootPoint.position, Quaternion.identity);
                    projectile.Launch(enemy, _towerStats);
                }

                yield return new WaitForSeconds(attackDelay);
            }

        }
    }
}
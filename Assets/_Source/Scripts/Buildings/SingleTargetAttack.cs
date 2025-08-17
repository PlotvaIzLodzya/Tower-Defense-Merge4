using System.Collections;
using UnityEngine;

namespace _Source.Scripts.Buildings
{

    public class SingleTargetAttack : IAttack
    {
        private FirstAtPath _targetSeek;
        private TowerStats _towerStats;
        private Projectile _projectilePrefab;
        private Transform _shootPoint;
        private AttackSpeed _attackSpeed;
        
        public SingleTargetAttack(FirstAtPath targetSeek, TowerStats towerStats, Projectile projectilePrefab, Transform shootPoint)
        {
            _targetSeek = targetSeek;
            _towerStats = towerStats;
            _projectilePrefab = projectilePrefab;
            _shootPoint = shootPoint;
            _attackSpeed = new ();
        }

        public IEnumerator Attack()
        {
            while (true)
            {
                var attackDelay = _attackSpeed.CalculateAttackDelay(_towerStats.AttackSpeed);

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
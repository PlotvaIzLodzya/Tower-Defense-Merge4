using _Source.Scripts.Buildings;
using _Source.Scripts.Projectiles;
using System.Collections;
using UnityEngine;

namespace _Source.Scripts.AttackBehaviours
{
    public class SingleTargetAttack : IAttack
    {
        public Tags Tags { get; private set; }
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
            Tags = Tags.SingleTarget | Tags.Homing | Tags.Linear | Tags.Forward | Tags.Damage | Tags.AOE |
                   Tags.Duration | Tags.Straight;
        }

        public IEnumerator Perform()
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
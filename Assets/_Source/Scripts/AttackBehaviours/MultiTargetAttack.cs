using _Source.Scripts.Battle;
using _Source.Scripts.Buildings;
using _Source.Scripts.Projectiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Source.Scripts.AttackBehaviours
{
    public class MultiTargetAttack : IAttack
    {
        private readonly int _targetCount;
        private TowerStats _towerStats;
        private Projectile _projectilePrefab;
        private Transform _shootPoint;
        private MultiAtPath _multiAtPath;
        private List<Enemy> _targets;
        private AttackSpeed _attackSpeed;

        public MultiTargetAttack(MultiAtPath multiAtPath, TowerStats towerStats, Projectile projectilePrefab, Transform shootPoint)
        {
            _towerStats = towerStats;
            _projectilePrefab = projectilePrefab;
            _shootPoint = shootPoint;
            _multiAtPath = multiAtPath;
            _targetCount = 2;
            _attackSpeed = new();
            _targets = new ();
        }

        public IEnumerator Attack()
        {
            while (true)
            {
                var attackDelay = _attackSpeed.CalculateAttackDelay(_towerStats.AttackSpeed);

                if (_multiAtPath.TryGetTargets(_targets, _targetCount))
                {
                    foreach (Enemy target in _targets)
                    {
                        var projectile = Object.Instantiate(_projectilePrefab, _shootPoint.position, Quaternion.identity);
                        projectile.Launch(target, _towerStats);
                    }
                }

                yield return new WaitForSeconds(attackDelay);
            }
        }
    }
}
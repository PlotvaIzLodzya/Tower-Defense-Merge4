using System.Collections;
using _Source.Scripts.Battle;
using _Source.Scripts.Buildings;
using _Source.Scripts.Helpers;
using _Source.Scripts.Projectiles;
using UnityEngine;

namespace _Source.Scripts.AttackBehaviours
{
    public class ShotgunAttack : IAttack
    {
        private int _projectileCount;
        private TowerStats _towerStats;
        private Projectile _projectilePrefab;
        private Transform _shootPoint;
        private RandomEnemyAtPath _randomEnemyAtPath;
        private AttackSpeed _attackSpeed;

        public ShotgunAttack(RandomEnemyAtPath randomEnemyAtPath, TowerStats towerStats, Projectile projectilePrefab, Transform shootPoint)
        {
            _randomEnemyAtPath = randomEnemyAtPath;
            _towerStats = towerStats;
            _projectilePrefab = projectilePrefab;
            _shootPoint = shootPoint;
            _projectileCount = 5;
            _attackSpeed = new ();
        }
        
        public IEnumerator Attack()
        {
            while (true)
            {
                if (_randomEnemyAtPath.TryGetTarget(out Enemy enemy))
                {
                    var enemyDirection = _shootPoint.position.CalculateDirection90Degrees(enemy.transform.position);
                    var directions = VectorExtensions.GenerateDirections(enemyDirection, 2, _projectileCount);
                    
                    foreach (var direction in directions)
                    {
                        var projectile = Object.Instantiate(_projectilePrefab, _shootPoint.position, Quaternion.identity);
                        projectile.transform.rotation = Quaternion.LookRotation(direction);
                        projectile.Launch(enemy, _towerStats);
                    }
                }
                var delay = _attackSpeed.CalculateAttackDelay(_towerStats.AttackSpeed);

                yield return new WaitForSeconds(delay);
            }    
        }
    }
}
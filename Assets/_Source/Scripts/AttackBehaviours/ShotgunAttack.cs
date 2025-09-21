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
        public Tags Tags { get; private set; }
        
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
            _projectileCount = 3;
            _attackSpeed = new ();
            Tags = Tags.Linear | Tags.Forward | Tags.Damage | Tags.AOE |
                   Tags.Duration;
        }
        
        public IEnumerator Perform()
        {
            while (true)
            {
                if (_randomEnemyAtPath.TryGetTarget(out Enemy enemy))
                {
                    var enemyDirection = _shootPoint.position.CalculateDirection90Degrees(enemy.transform.position);
                    var directions = VectorExtensions.GenerateDirections(enemyDirection, 5, _projectileCount);
                    foreach (var direction in directions)
                    {
                        var rotation = Quaternion.LookRotation(direction);
                        var projectile = Object.Instantiate(_projectilePrefab, _shootPoint.position, rotation);
                        
                        projectile.Launch(enemy, _towerStats);
                    }
                }
                var delay = _attackSpeed.CalculateAttackDelay(_towerStats.AttackSpeed);

                yield return new WaitForSeconds(delay);
            }    
        }
    }
}
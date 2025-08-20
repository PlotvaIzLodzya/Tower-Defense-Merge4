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
            _projectileCount = 3;
            _attackSpeed = new AttackSpeed();
        }
        
        public IEnumerator Attack()
        {
            
            while (true)
            {
                if (_randomEnemyAtPath.TryGetTarget(out Enemy enemy))
                {
                    var forwardDirection = _shootPoint.position.CalculateDirection90Degrees(enemy.transform.position);
                    
                    
                }

                yield return _attackSpeed.CalculateAttackDelay(_towerStats.AttackSpeed);
            }    
        }
    }
}
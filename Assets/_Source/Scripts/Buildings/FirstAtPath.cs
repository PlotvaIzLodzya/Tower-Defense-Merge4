using System.Collections.Generic;
using System.Linq;
using _Source.Scripts.Battle;
using _Source.Scripts.Buildings;
using UnityEngine;

namespace _Source.Scripts.AttackBehaviours
{

    public class FirstAtPath : ITargetSeek
    {
        private EnemyPool _enemiesPool;
        private Transform _shootPoint;
        private Enemy _current;
        private TowerStats _stats;
        private bool _lockIn;

        public FirstAtPath(EnemyPool enemiesPool, Transform shootPoint, TowerStats stats, bool lockIn)
        {
            _stats = stats;
            _shootPoint = shootPoint;
            _enemiesPool = enemiesPool;
            _lockIn = lockIn;
        }

        public bool TryGetTarget(out Enemy enemy)
        {
            enemy = null;
            
            if (_enemiesPool.HaveEnemy == false)
                return false;
            
            if (_lockIn && _current != null && _current.IsDead == false)
            {
                enemy = _current;
                
                return true;
            }

            enemy = _enemiesPool.GetEnemy(ChooseTarget);
            if(enemy == null)
                return false;
            
            _current = enemy;
            return enemy;
        }

        private Enemy ChooseTarget(List<Enemy> enemies)
        {
            var enemyInRange = enemies.FirstOrDefault(e => IsInAttackRadius(e.transform.position));

            return enemyInRange;
        }

        private bool IsInAttackRadius(Vector3 target)
        {
            return Vector3.Distance(_shootPoint.position, target) <= _stats.AttackRadius;
        }
    }
}
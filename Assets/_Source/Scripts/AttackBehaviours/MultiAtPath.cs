using System.Collections.Generic;
using System.Linq;
using _Source.Scripts.Battle;
using _Source.Scripts.Buildings;
using UnityEngine;

namespace _Source.Scripts.AttackBehaviours
{
    public class MultiAtPath : IMutipleTargetSeek
    {
        private EnemyPool _enemiesPool;
        private Transform _shootPoint;
        private TowerStats _stats;
        private List<Enemy> _currentTargets;

        public MultiAtPath(EnemyPool enemiesPoolPool, Transform shootPoint, TowerStats stats)
        {
            _enemiesPool = enemiesPoolPool;
            _shootPoint = shootPoint;
            _stats = stats;
            _currentTargets = new ();
        }

        public bool TryGetTargets(List<Enemy> enemies, int maxAmount)
        {
            enemies.Clear();
            _currentTargets.Clear();
            for (int i = 0; i < maxAmount; i++)
            {
                var target = _enemiesPool.GetEnemy(ChooseTarget);

                if(target != null)
                {
                    enemies.Add(target);
                    _currentTargets.Add(target);
                }
            }

            return _currentTargets.Count > 0;
        }

        private Enemy ChooseTarget(List<Enemy> enemies)
        {
            var validTargets = enemies.Except(_currentTargets);

            var enemyInRange = validTargets.FirstOrDefault(e => IsInAttackRadius(e.transform.position));

            return enemyInRange;
        }

        private bool IsInAttackRadius(Vector3 target)
        {
            return Vector3.Distance(_shootPoint.position, target) <= _stats.AttackRadius;
        }
    }
}
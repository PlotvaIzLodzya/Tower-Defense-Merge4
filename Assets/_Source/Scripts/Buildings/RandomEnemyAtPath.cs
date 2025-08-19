using System.Collections.Generic;
using _Source.Scripts.Battle;
using UnityEngine;

namespace _Source.Scripts.AttackBehaviours
{
    public class RandomEnemyAtPath : ITargetSeek
    {
        private EnemyPool _enemiesPool;

        public RandomEnemyAtPath(EnemyPool enemiesPool)
        {
            _enemiesPool = enemiesPool;
        }

        public bool TryGetTarget(out Enemy enemy)
        {
            enemy = _enemiesPool.GetEnemy(GetRandomEnemy);

            return enemy != null;
        }

        private Enemy GetRandomEnemy(List<Enemy> enemies)
        {
            var randomIndex = Random.Range(0, enemies.Count);
            return enemies[randomIndex];
        }
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Source.Scripts.Battle
{
    public class EnemyPool : MonoBehaviour
    {
        private List<Enemy> _enemies;
        
        public bool HaveEnemy => _enemies.Count > 0;

        private void Awake()
        {
            _enemies = new();
        }

        private void Update()
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                if (_enemies[i].IsDead)
                {
                    _enemies.RemoveAt(i);
                }
            }
        }
        
        public Enemy GetEnemy(Func<List<Enemy>, Enemy> chooseFrom)
        {
            return chooseFrom(_enemies);
        }
        
        public void Add(Enemy enemy)
        {
            _enemies.Add(enemy);
        }

        public void Remove(Enemy enemy)
        {
            _enemies.Remove(enemy);
        }


    }
}
using System;
using System.Collections.Generic;
using _Source.Scripts.ReferencesAndSources;
using _Source.Scripts.Trade;
using JetBrains.Annotations;
using UnityEngine;

namespace _Source.Scripts.Battle
{
    public class EnemyPool : MonoBehaviour
    {
        [SerializeField] private WalletReference _walletReference;
        
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

        [CanBeNull]
        public Enemy GetClosestTo(Enemy enemy, float radius)
        {
            Enemy nearestEnemy = null;
            var minDist = float.MaxValue;

            foreach (var e in _enemies)
            {
                if (e == enemy || e.IsDead)
                    continue;

                var dist = Vector3.Distance(enemy.transform.position, e.transform.position);
                if (dist < radius && dist < minDist)
                {
                    nearestEnemy = e;
                    minDist = dist;
                }
            }

            return nearestEnemy;
        }
        
        public Enemy GetEnemy(Func<List<Enemy>, Enemy> chooseFrom)
        {
            return chooseFrom(_enemies);
        }

        public void GetEnemys(Action<List<Enemy>> chooseFrom)
        {
           chooseFrom(_enemies);
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
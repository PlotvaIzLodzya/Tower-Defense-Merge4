using System;
using System.Collections.Generic;
using _Source.Scripts.ReferencesAndSources;
using _Source.Scripts.Trade;
using UnityEngine;

namespace _Source.Scripts.Battle
{
    public class EnemyPool : MonoBehaviour
    {
        [SerializeField] private WalletReference _walletReference;
        
        private List<Enemy> _enemies;
        private Wallet _wallet;
        
        public bool HaveEnemy => _enemies.Count > 0;

        private void Awake()
        {
            _wallet = _walletReference.Value;
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
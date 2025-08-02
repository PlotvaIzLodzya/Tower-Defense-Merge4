using System.Collections.Generic;
using System.Linq;
using _Source.Scripts.Battle;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class FirstAtPath : ITargetSeek
    {
        private List<Enemy> _enemies;
        private Enemy _current;
        private bool _lockIn;

        public FirstAtPath(List<Enemy> enemies, bool lockIn)
        {
            _enemies = enemies;
            _lockIn = lockIn;
        }

        public bool TryGetTarget(out Enemy enemy)
        {
            enemy = null;
            
            if (_enemies.Count == 0)
                return false;
            
            if (_lockIn && _current != null && _current.IsDead == false)
            {
                enemy = _current;
                
                return true;
            }

            enemy = _enemies[0];
            _current = enemy;
            return enemy;
        }
    }
}
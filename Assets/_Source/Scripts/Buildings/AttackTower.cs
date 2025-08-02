using System.Collections;
using System.Collections.Generic;
using _Source.Scripts.Battle;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class AttackTower : Tower
    {
        [SerializeField] private SphereCollider _enemyTrigger;
        
        private List<Enemy> _enemies;
        private IAttack _attackBehaviour;

        private void Awake()
        {
            _enemies = new();
            var seekTarget = new FirstAtPath(_enemies, lockIn: true);
            _attackBehaviour = new SingleTargetAttack(seekTarget, Stats);
        }

        private void Start()
        {
            StartCoroutine(Attacking());
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out Enemy enemy) && _enemies.Contains(enemy) == false)
            {
                _enemies.Add(enemy);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Enemy enemy) && _enemies.Contains(enemy))
            {
                _enemies.Remove(enemy);
            }
        }

        private IEnumerator Attacking()
        {
            while (true)
            {
                _enemyTrigger.radius = Stats.AttackRadius;
                ClearFromDeadEnemies();
                var attackDelay = Mathf.Lerp(1, 0.2f, Stats.AttackSpeed / 700);
                yield return new WaitForSeconds(attackDelay);
                _attackBehaviour.Attack();
            }
        }

        private void ClearFromDeadEnemies()
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                if (_enemies[i].IsDead || _enemies[i] == null)
                    _enemies.Remove(_enemies[i]);
            }
        }
    }
}
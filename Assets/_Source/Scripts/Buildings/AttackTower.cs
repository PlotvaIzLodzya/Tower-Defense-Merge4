using System.Collections;
using System.Collections.Generic;
using _Source.Scripts.Battle;
using _Source.Scripts.ReferencesAndSources;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class AttackTower : Tower
    {
        [SerializeField] private SphereCollider _enemyTrigger;
        [SerializeField] private Projectile _projectile;
        [SerializeField] private EnemyPoolReference _enemyPoolReference;
        
        private List<Enemy> _enemies;
        private IAttack _attackBehaviour;

        private void Awake()
        {
            _enemies = new();
            var seekTarget = new FirstAtPath(_enemyPoolReference.Value, transform, Stats, lockIn: true);
            _attackBehaviour = new SingleTargetAttack(seekTarget, Stats,_projectile, transform);
        }

        private void Start()
        {
            StartCoroutine(Attacking());
        }

        private IEnumerator Attacking()
        {
            while (true)
            {
                _enemyTrigger.radius = Stats.AttackRadius;
                var attackDelay = Mathf.Lerp(1, 0.2f, Stats.AttackSpeed / 700);
                _attackBehaviour.Attack();
                yield return new WaitForSeconds(attackDelay);
            }
        }
    }
}
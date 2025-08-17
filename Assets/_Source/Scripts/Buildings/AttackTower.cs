using _Source.Scripts.ReferencesAndSources;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class AttackTower : Tower
    {
        [SerializeField] private Projectile _projectile;
        [SerializeField] private EnemyPoolReference _enemyPoolReference;
        
        private IAttack _attackBehaviour;

        private void Awake()
        {
            var seekTarget = new FirstAtPath(_enemyPoolReference.Value, transform, Stats, lockIn: true);
            _attackBehaviour = new SingleTargetAttack(seekTarget, Stats, _projectile, transform);
        }

        private void Start()
        {
            StartCoroutine(_attackBehaviour.Attack());
        }
    }
}
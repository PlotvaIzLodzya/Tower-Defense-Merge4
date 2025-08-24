using _Source.Scripts.AttackBehaviours;
using _Source.Scripts.Projectiles;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class AttackTower : Tower, ITagUser
    {
        [SerializeField] private AttackBehaviour _defaultAttack;
        [SerializeField] private Projectile _projectilePrefab;

        private Coroutine _attackCoroutine;
        private Attack _attack;
        public Tags Tags => _attack.Tags;

        private void Awake()
        {
            _attack = new Attack(_defaultAttack, this, _projectilePrefab);
        }

        private void Start()
        {
            RestartAttack();
        }

        public void UpdateProjectile(Projectile projectile)
        {
            _attack.UpdateProjectile(projectile);
            RestartAttack();
        }

        public void UpdateAttackBehaviour(AttackBehaviour attackBehaviour)
        {
            _attack.UpdateAttackBehaviour(attackBehaviour);
            RestartAttack();
        }

        private void RestartAttack()
        {
            if(_attackCoroutine != null)
                StopCoroutine(_attackCoroutine);
            
            _attackCoroutine = StartCoroutine(_attack.Perform());
        }
    }
}
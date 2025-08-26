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
        public Transform AttackPoint => transform;

        private void Awake()
        {
            _attack = new Attack(_defaultAttack, this, _projectilePrefab);
        }

        private void Start()
        {
            RestartAttack();
        }

        public void SetAttack(Attack attack)
        {
            _attack = attack;
            RestartAttack();
        }

        public void UpgradeProjectile(ProjectileDTO dto)
        {
            _attack.UpgradeProjectile(dto);
        }

        public void SetProjectile(Projectile projectile)
        {
            _attack.SetProjectile(projectile);
            RestartAttack();
        }

        public void SetAttackBehaviour(AttackBehaviour attackBehaviour)
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
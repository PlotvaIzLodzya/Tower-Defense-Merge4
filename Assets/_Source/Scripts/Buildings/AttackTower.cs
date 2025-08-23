using _Source.Scripts.AttackBehaviours;
using _Source.Scripts.Projectiles;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class AttackTower : Tower, ITagUser
    {
        [SerializeField] private AttackBehaviour _defaultAttack;
        [SerializeField] private Projectile _projectilePrefab;
        
        private Attack _attack;
        public Tags Tags => _attack.Tags;

        private void Awake()
        {
            _attack = new Attack(_defaultAttack, this, _projectilePrefab);
        }

        private void Start()
        {
            StartCoroutine(_attack.Perform());
        }

        public void UpdateProjectile(Projectile projectile)
        {
            _attack.UpdateProjectile(projectile);
        }

        public void UpdateAttackBehaviour(AttackBehaviour attackBehaviour)
        {
            _attack.UpdateAttackBehaviour(attackBehaviour);
        }

    }
}
using System.Collections;
using _Source.Scripts.Buildings;
using _Source.Scripts.Projectiles;

namespace _Source.Scripts.AttackBehaviours
{
    public class Attack : IAttack, ITagUser
    {
        private IAttack _attack;
        private AttackBehaviour _attackBehaviour;
        private Projectile _projectile;
        private Tower _tower;
        
        public Tags Tags { get; private set; }
        
        public Attack(AttackBehaviour attackBehaviour, Tower tower,  Projectile projectile)
        {
            _attack = attackBehaviour.GetBehaviour(tower, projectile);
            _attackBehaviour = attackBehaviour;
            _projectile = projectile;
            _tower = tower;
        }
        
        public IEnumerator Perform()
        {
            yield return _attack.Perform();
        }

        public void UpdateProjectile(Projectile projectile)
        {
            _projectile = projectile;
            UpdateAttackBehaviour(_attackBehaviour);
            UpdateTags();
        }

        public void UpdateAttackBehaviour(AttackBehaviour attackBehaviour)
        {
            _attack = attackBehaviour.GetBehaviour(_tower, _projectile);
            UpdateTags();
        }

        private void UpdateTags()
        {
            Tags |= _projectile.Tags;
            Tags |= _attack.Tags;
        }
    }
}
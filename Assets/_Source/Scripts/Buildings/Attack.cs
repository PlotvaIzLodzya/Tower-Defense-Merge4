using System.Collections;
using _Source.Scripts.Buildings;
using _Source.Scripts.Projectiles;
using UnityEngine;

namespace _Source.Scripts.AttackBehaviours
{
    public class Attack : IAttack
    {
        private IAttack _attack;
        private AttackBehaviour _attackBehaviour;
        private Projectile _projectile;
        private Tower _tower;
        
        public Tags Tags { get; private set; }
        
        public Attack(AttackBehaviour attackBehaviour, Tower tower,  Projectile projectile)
        {
            _attackBehaviour = attackBehaviour;
            _tower = tower;
            RecreateProjectileDummy(projectile);
            _attack = attackBehaviour.GetBehaviour(tower, _projectile);
        }
        
        public IEnumerator Perform()
        {
            yield return _attack.Perform();
        }

        public void UpgradeProjectile(ProjectileDTO dto)
        {
            _projectile.Upgrade(dto);
        }

        public void SetProjectile(Projectile projectile)
        {
            RecreateProjectileDummy(projectile);
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

        private void RecreateProjectileDummy(Projectile projectile)
        {
            _projectile?.Destroy();
            _projectile = Object.Instantiate(projectile, _tower.transform);
            _projectile.transform.localPosition = Vector3.forward * 5f;
        }
    }
}
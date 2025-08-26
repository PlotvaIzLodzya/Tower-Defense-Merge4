using _Source.Scripts.Buildings;
using _Source.Scripts.Helpers;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{
    [CreateAssetMenu(fileName = nameof(OnHitBehaviourUpgrade),  menuName = NamingConstant.ProjectilesBehaviour + "/" + NamingConstant.Upgrades + "/" + nameof(OnHitBehaviourUpgrade))]
    public class OnHitBehaviourUpgrade : ProjectileBehaviourUpgrade
    {
        [SerializeField] private OnHitBehaviour _onHit;
        [SerializeField] private ProjectileMovement _projectileMovement;
        
        public override Tags Tags => _onHit.Tags;
        
        public override void Upgrade(AttackTower tower)
        {
            var dto = new ProjectileDTO()
            {
                HitBehaviour = _onHit,
                Movement = _projectileMovement,
            };
            tower.UpgradeProjectile(dto);
        }
    }
}
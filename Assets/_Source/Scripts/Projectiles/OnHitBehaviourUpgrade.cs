using _Source.Scripts.Buildings;
using _Source.Scripts.Helpers;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{
    [CreateAssetMenu(fileName = nameof(OnHitBehaviourUpgrade),  menuName = NamingConstant.ProjectilesBehaviour + "/" + NamingConstant.Upgrades + "/" + nameof(OnHitBehaviourUpgrade))]
    public class OnHitBehaviourUpgrade : BehaviourUpgrade
    {
        [SerializeField] private OnHitBehaviour _onHit;
        [SerializeField] private ProjectileMovement _projectileMovement;
        [SerializeField] private OnMovementEnd _onEnd;
        [SerializeField] private OnStayOnEnemy _onStay;
        
        [field: SerializeField] public override string Name { get; protected set; }
        
        public override Tags Tags => _onHit.Tags;
        
        public override void Upgrade(AttackTower tower)
        {
            var dto = new ProjectileDTO()
            {
                HitBehaviour = _onHit,
                Movement = _projectileMovement,
                StayOnEnemy = _onStay,
                MovementEnd = _onEnd
            };
            tower.UpgradeProjectile(dto);
        }
    }
}
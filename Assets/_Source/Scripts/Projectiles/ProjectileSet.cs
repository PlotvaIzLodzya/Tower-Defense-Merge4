using _Source.Scripts.Buildings;
using _Source.Scripts.Helpers;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{
    [CreateAssetMenu(fileName = nameof(ProjectileSet),  menuName = NamingConstant.ProjectilesBehaviour + "/" + NamingConstant.Upgrades + "/" + nameof(ProjectileSet))]
    public class ProjectileSet : BehaviourUpgrade
    {
        [SerializeField] private Projectile _projectile;
        
        [field: SerializeField] public override string Name { get; protected set; }

        public override Tags Tags => _projectile.Tags;
        
        public override void Upgrade(AttackTower tower)
        {
            tower.SetProjectile(_projectile);
        }
    }
}
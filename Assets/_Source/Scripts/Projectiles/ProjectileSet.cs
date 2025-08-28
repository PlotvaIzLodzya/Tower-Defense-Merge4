using _Source.Scripts.Buildings;
using _Source.Scripts.Helpers;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{
    [CreateAssetMenu(fileName = nameof(ProjectileSet),  menuName = NamingConstant.ProjectilesBehaviour + "/" + NamingConstant.Upgrades + "/" + nameof(ProjectileSet))]
    public class ProjectileSet : ProjectileBehaviourUpgrade
    {
        [SerializeField] private Projectile _projectile;

        public override Tags Tags => _projectile.Tags;
        
        public override void Upgrade(AttackTower tower)
        {
            tower.SetProjectile(_projectile);
        }
    }
}
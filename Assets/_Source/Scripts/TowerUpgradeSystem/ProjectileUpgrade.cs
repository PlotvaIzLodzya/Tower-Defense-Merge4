using _Source.Scripts.Buildings;
using _Source.Scripts.Projectiles;
using UnityEngine;

namespace _Source.Scripts.TowerUpgradeSystem
{
    public class ProjectileUpgrade : AttackTowerUpgrade
    {
        [SerializeField] private ProjectileBehaviourUpgrade _upgradeBehaviour;
        
        public override Tags Tags => _upgradeBehaviour.Tags;

        protected override void OnUpgrade(AttackTower tower)
        {
            _upgradeBehaviour.Upgrade(tower);
        }
    }
}
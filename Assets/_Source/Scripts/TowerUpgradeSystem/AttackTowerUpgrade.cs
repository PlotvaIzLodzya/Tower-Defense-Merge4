using _Source.Scripts.Buildings;
using _Source.Scripts.Projectiles;
using UnityEngine;

namespace _Source.Scripts.TowerUpgradeSystem
{
    public class AttackTowerUpgrade : TowerUpgrade
    {
        [SerializeField] private BehaviourUpgrade _upgradeBehaviour;
        
        private AttackTower _attackTower;
        public override Tags Tags => _upgradeBehaviour.Tags;

        public override void SetTower(Tower tower)
        {
            if (tower is AttackTower attackTower)
                _attackTower = attackTower;
        }

        protected override void OnUpgrade()
        {
            _upgradeBehaviour.Upgrade(_attackTower);
        }
    }
}
using _Source.Scripts.Buildings;
using _Source.Scripts.Projectiles;
using _Source.Scripts.UI;
using TMPro;
using UnityEngine;

namespace _Source.Scripts.TowerUpgradeSystem
{
    public class AttackTowerUpgrade : TowerUpgrade
    {
        [SerializeField] private BehaviourUpgrade _upgradeBehaviour;
        [SerializeField] private TMP_Text _name;
        
        private AttackTower _attackTower;
        public override Tags Tags => _upgradeBehaviour.Tags;

        public override void Initialize(Panel upgradePanel, BehaviourUpgrade behaviourUpgrade)
        {
            base.Initialize(upgradePanel, behaviourUpgrade);
            _name.text = behaviourUpgrade.Name;
            _upgradeBehaviour = behaviourUpgrade;
        }

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
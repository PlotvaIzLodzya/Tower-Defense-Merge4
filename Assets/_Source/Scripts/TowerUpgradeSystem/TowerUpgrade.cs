using System;
using _Source.Scripts.Buildings;
using _Source.Scripts.Projectiles;
using _Source.Scripts.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.Scripts.TowerUpgradeSystem
{
    public class ProjectileUpgrade : AttackTowerUpgrade
    {
        [SerializeField] private ProjectileDTO _dto;
        
        public override Tags Tags { get; }

        protected override void OnUpgrade(AttackTower tower)
        {
            tower.UpgradeProjectile(_dto);
        }
    }
    
    public abstract class TowerUpgrade : Panel
    {
        [SerializeField] private Button _upgradeButton;
        
        private Panel _upgradePanel;
        
        public abstract Tags Tags { get; }
        
        private void Awake()
        {
            _upgradeButton.onClick.AddListener(OnUpgradeButtonClick);
        }

        private void OnDestroy()
        {
            _upgradeButton.onClick.RemoveListener(OnUpgradeButtonClick);       
        }

        public virtual void Initialize(Panel upgradePanel)
        {
            _upgradePanel = upgradePanel;
        }

        public abstract void SetTower(Tower tower);
        protected abstract void OnUpgrade();

        
        private void OnUpgradeButtonClick()
        {
            _upgradePanel.Hide();
            OnUpgrade();
        }
    }
}
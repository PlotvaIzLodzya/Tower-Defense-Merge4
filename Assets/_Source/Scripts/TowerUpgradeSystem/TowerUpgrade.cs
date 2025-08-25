using System;
using _Source.Scripts.Buildings;
using _Source.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.Scripts.TowerUpgradeSystem
{
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
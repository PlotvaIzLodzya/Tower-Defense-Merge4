using System;
using _Source.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.Scripts.TowerUpgradeSystem
{
    public class TowerUpgradeView : Panel
    {
        [SerializeField] private Button _upgradeButton;
        
        public event Action<TowerUpgradeView> OnUpgrade;

        private void Awake()
        {
            _upgradeButton.onClick.AddListener(OnUpgradeButtonClick);
        }

        private void OnDestroy()
        {
            _upgradeButton.onClick.RemoveListener(OnUpgradeButtonClick);       
        }

        private void OnUpgradeButtonClick()
        {
            OnUpgrade?.Invoke(this);
        }
    }
}
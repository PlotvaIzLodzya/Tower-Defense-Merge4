using _Source.Scripts.Buildings;
using _Source.Scripts.Projectiles;
using _Source.Scripts.UI;
using UnityEngine;

namespace _Source.Scripts.TowerUpgradeSystem
{
    public class TowerUpgradePanel : Panel
    {
        
        private TowerUpgrade[] _upgradeViews;
        
        private void Awake()
        {
            _upgradeViews = GetComponentsInChildren<TowerUpgrade>();
            foreach (var view in _upgradeViews)
            {
                view.Initialize(this);
            }
            
            Hide();
            
        }

        public void OnTowerMerge(Tower tower)
        {
            Show();
            foreach (var view in _upgradeViews)
            {
                view.SetTower(tower);
            }
        }
    }
}
using _Source.Scripts.Buildings;
using _Source.Scripts.Projectiles;
using _Source.Scripts.UI;
using UnityEngine;

namespace _Source.Scripts.TowerUpgradeSystem
{
    public class TowerUpgradePanel : Panel
    {
        [SerializeField] private TowerUpgrade[] _upgradeViews;
        [SerializeField] private Projectile _projectile;
        
        private void Awake()
        {
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
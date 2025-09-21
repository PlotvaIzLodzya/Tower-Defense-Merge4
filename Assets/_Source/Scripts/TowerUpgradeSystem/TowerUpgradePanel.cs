using _Source.Scripts.Buildings;
using _Source.Scripts.UI;
using UnityEngine;

namespace _Source.Scripts.TowerUpgradeSystem
{
    public class TowerUpgradePanel : Panel
    {
        [SerializeField] private UpgradeList _upgradeList;
        
        private TowerUpgrade[] _upgradeViews;
        
        private void Awake()
        {
            _upgradeViews = GetComponentsInChildren<TowerUpgrade>();

            
            Hide();
            
        }

        public void OnTowerMerge(Tower tower)
        {
            Show();
            var upgrades = _upgradeList.GetBehaviourUpgrades((tower.Tags & Tags.Damage), _upgradeViews.Length);
            for (int i = 0; i < _upgradeViews.Length; i++)
            {
                _upgradeViews[i].Initialize(this, upgrades[i]);
            }
            
            foreach (var view in _upgradeViews)
            {
                view.SetTower(tower);
            }
        }
    }
}
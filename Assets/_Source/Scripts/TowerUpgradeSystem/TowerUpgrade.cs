using System;
using System.Collections.Generic;
using _Source.Scripts.AttackBehaviours;
using _Source.Scripts.Buildings;
using _Source.Scripts.Projectiles;
using _Source.Scripts.UI;
using UnityEngine;

namespace _Source.Scripts.TowerUpgradeSystem
{
    public class TowerUpgrade : Panel
    {
        [SerializeField] private TowerUpgradeView[] _upgradeViews;
        [SerializeField] private AttackBehaviour[] _attackBehaviours;
        [SerializeField] private Projectile _projectile;

        private AttackTower _attackTower;
        private Dictionary<TowerUpgradeView, AttackBehaviour> _bindViewToUpgrade;
        
        private void Awake()
        {
            _bindViewToUpgrade = new();
            for (int i = 0; i < _upgradeViews.Length; i++)
            {
                _bindViewToUpgrade.Add(_upgradeViews[i], _attackBehaviours[i]);
                _upgradeViews[i].OnUpgrade += OnUpgradeBuy;
            }
            
            Hide();
            
        }

        private void OnDestroy()
        {
            for (int i = 0; i < _upgradeViews.Length; i++)
            {
                _upgradeViews[i].OnUpgrade -= OnUpgradeBuy;
            }
        }


        public void OnTowerMerge(Tower tower)
        {
            Show();
            if (tower is AttackTower attackTower)
            {
                _attackTower = attackTower;
            }
        }

        public void OnUpgradeBuy(TowerUpgradeView view)
        {
            _attackTower.UpdateProjectile(_projectile);
            _attackTower.UpdateAttackBehaviour(_bindViewToUpgrade[view]);
            Hide();
        }
    }
}
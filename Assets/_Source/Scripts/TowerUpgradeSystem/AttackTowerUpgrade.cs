using _Source.Scripts.Buildings;

namespace _Source.Scripts.TowerUpgradeSystem
{
    public abstract class AttackTowerUpgrade : TowerUpgrade
    {
        private AttackTower _attackTower;
        
        public override void SetTower(Tower tower)
        {
            if (tower is AttackTower attackTower)
                _attackTower = attackTower;
        }

        protected override void OnUpgrade()
        {
            OnUpgrade(_attackTower);
        }
        
        protected abstract void OnUpgrade(AttackTower tower);
    }
}
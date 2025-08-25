using _Source.Scripts.AttackBehaviours;
using _Source.Scripts.Buildings;
using UnityEngine;

namespace _Source.Scripts.TowerUpgradeSystem
{
    public class ArchetypeUpgrade : TowerUpgrade
    {
        [SerializeField] private AttackArchetypeBuilder _archetypeBuilder;

        private AttackTower _attackTower;
        
        public override void SetTower(Tower tower)
        {
            if (tower is AttackTower attackTower)
            {
                _attackTower = attackTower;
            }
        }

        protected override void OnUpgrade()
        {
            _archetypeBuilder.BuildIn(_attackTower);
        }
    }
}
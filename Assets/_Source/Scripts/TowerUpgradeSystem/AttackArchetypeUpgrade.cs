using _Source.Scripts.AttackBehaviours;
using _Source.Scripts.Buildings;
using UnityEngine;

namespace _Source.Scripts.TowerUpgradeSystem
{
    public class AttackArchetypeUpgrade : AttackTowerUpgrade
    {
        [SerializeField] private AttackArchetypeBuilder _archetypeBuilder;
        
        public override Tags Tags => _archetypeBuilder.Tags;

        protected override void OnUpgrade(AttackTower tower)
        {
            _archetypeBuilder.BuildIn(tower);
        }
    }
}
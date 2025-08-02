using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class SingleTargetAttack : IAttack
    {
        private TowerStats _towerStats;
        private ITargetSeek _targetSeek;

        public SingleTargetAttack(ITargetSeek targetSeek, TowerStats towerStats)
        {
            _targetSeek = targetSeek;
            _towerStats = towerStats;
        }

        public void Attack()
        {
            if (_targetSeek.TryGetTarget(out var enemy))
            {
                enemy.DealDamage(_towerStats.Damage);
            }
        }
    }
}
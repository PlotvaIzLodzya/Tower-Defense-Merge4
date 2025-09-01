using _Source.Scripts.Buildings;
using _Source.Scripts.Helpers;
using _Source.Scripts.Projectiles;
using UnityEngine;

namespace _Source.Scripts.AttackBehaviours
{
    [CreateAssetMenu(fileName = nameof(AttackArchetypeBuilder), menuName = NamingConstant.AttackBehaviour + "/" + nameof(AttackArchetypeBuilder))]
    public class AttackArchetypeBuilder : BehaviourUpgrade, ITagUser
    {
        [SerializeField] private Projectile _projectile;
        [SerializeField] private AttackBehaviour _attackBehaviour;

        public override Tags Tags => _projectile.Tags | _attackBehaviour.Tags;

        public override void Upgrade(AttackTower tower)
        {
            var attack = new Attack(_attackBehaviour, tower, _projectile);
            tower.SetAttack(attack);
        }

    }
}
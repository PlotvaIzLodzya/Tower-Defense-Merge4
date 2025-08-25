using _Source.Scripts.Buildings;
using _Source.Scripts.Helpers;
using _Source.Scripts.Projectiles;
using UnityEngine;

namespace _Source.Scripts.AttackBehaviours
{
    [CreateAssetMenu(fileName = nameof(AttackArchetypeBuilder), menuName = NamingConstant.AttackBehaviour + "/" + nameof(AttackArchetypeBuilder))]
    public class AttackArchetypeBuilder : ScriptableObject, ITagUser
    {
        [SerializeField] private Projectile _projectile;
        [SerializeField] private AttackBehaviour _attackBehaviour;

        public Tags Tags => _projectile.Tags;

        public Attack BuildIn(AttackTower tower)
        {
            var attack = new Attack(_attackBehaviour, tower, _projectile);
            tower.SetAttack(attack);
            return attack;
        }

    }
}
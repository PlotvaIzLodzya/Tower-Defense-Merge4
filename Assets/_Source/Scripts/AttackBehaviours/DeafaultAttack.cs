using _Source.Scripts.Buildings;
using _Source.Scripts.Helpers;
using _Source.Scripts.Projectiles;
using UnityEngine;

namespace _Source.Scripts.AttackBehaviours
{
    [CreateAssetMenu(fileName = nameof(DefaultAttackBehaviour), menuName = NamingConstant.AttackBehaviour + "/" + nameof(DefaultAttackBehaviour))] 
    public class DefaultAttackBehaviour : AttackBehaviour
    {
        public Tags Tags {get; private set;}
        
        public override IAttack GetBehaviour(Tower tower, Projectile projectilePrefab)
        {
            var seekTarget = new FirstAtPath(EnemyPoolReference.Value, tower.transform, tower.Stats, lockIn: true);
            var defaultAttack = new SingleTargetAttack(seekTarget, tower.Stats, projectilePrefab, tower.transform);

            return defaultAttack;
        }
    }
}
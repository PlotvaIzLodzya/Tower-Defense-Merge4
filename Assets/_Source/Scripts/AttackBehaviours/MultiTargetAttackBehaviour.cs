using _Source.Scripts.Buildings;
using _Source.Scripts.Helpers;
using _Source.Scripts.Projectiles;
using UnityEngine;

namespace _Source.Scripts.AttackBehaviours
{
    [CreateAssetMenu(fileName = nameof(MultiTargetAttackBehaviour), menuName = NamingConstant.AttackBehaviour + "/" + nameof(MultiTargetAttackBehaviour))]
    public class MultiTargetAttackBehaviour : AttackBehaviour
    {
        public override IAttack GetBehaviour(Tower tower, Projectile projectilePrefab)
        {
            var multiTargetSeek = new MultiAtPath(EnemyPoolReference.Value, tower.transform, tower.Stats);
            var multiTargetAttack = new MultiTargetAttack(multiTargetSeek, tower.Stats, projectilePrefab, tower.transform);

            return multiTargetAttack;
        }
    }
}
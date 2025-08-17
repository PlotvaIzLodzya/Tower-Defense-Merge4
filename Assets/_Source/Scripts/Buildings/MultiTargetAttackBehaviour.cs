using _Source.Scripts.ReferencesAndSources;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    [CreateAssetMenu(fileName = nameof(MultiTargetAttackBehaviour), menuName = NamingConstant.AttackBehaviours + "/" + nameof(MultiTargetAttackBehaviour))]
    public class MultiTargetAttackBehaviour : AttackBehaviour
    {
        public override IAttack GetBehaviour(Tower tower)
        {
            var multiTargetSeek = new MultiAtPath(EnemyPoolReference.Value, tower.transform, tower.Stats);
            var multiTargetAttack = new MultiTargetAttack(multiTargetSeek, tower.Stats, Projectile, tower.transform);

            return multiTargetAttack;
        }
    }
}
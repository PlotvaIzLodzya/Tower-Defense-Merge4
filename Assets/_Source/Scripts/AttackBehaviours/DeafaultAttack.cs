using _Source.Scripts.Buildings;
using _Source.Scripts.ReferencesAndSources;
using UnityEngine;

namespace _Source.Scripts.AttackBehaviours
{

    [CreateAssetMenu(fileName = nameof(DeafaultAttackBehaviour), menuName = NamingConstant.AttackBehaviour + "/" + nameof(DeafaultAttackBehaviour))] 
    public class DeafaultAttackBehaviour : AttackBehaviour
    {
        public override IAttack GetBehaviour(Tower tower)
        {
            var seekTarget = new FirstAtPath(EnemyPoolReference.Value, tower.transform, tower.Stats, lockIn: true);
            var defaultAttack = new SingleTargetAttack(seekTarget, tower.Stats, Projectile, tower.transform);

            return defaultAttack;
        }
    }
}
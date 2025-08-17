using _Source.Scripts.ReferencesAndSources;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    [CreateAssetMenu(fileName = nameof(DeafaultAttack), menuName = "Attack behaviours/" + nameof(DeafaultAttack))]
    public class DeafaultAttack : AttackBehaviour
    {
        public override IAttack GetAttackBehaviour(Tower tower)
        {
            var seekTarget = new FirstAtPath(EnemyPoolReference.Value, tower.transform, tower.Stats, lockIn: true);
            var defaultAttack = new SingleTargetAttack(seekTarget, tower.Stats, Projectile, tower.transform);

            return defaultAttack;
        }
    }
}
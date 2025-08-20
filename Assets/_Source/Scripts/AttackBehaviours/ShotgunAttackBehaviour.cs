using _Source.Scripts.Buildings;
using _Source.Scripts.Helpers;
using UnityEngine;

namespace _Source.Scripts.AttackBehaviours
{
    [CreateAssetMenu(fileName = nameof(ShotgunAttackBehaviour), menuName = NamingConstant.AttackBehaviour + "/" + nameof(ShotgunAttackBehaviour))]
    public class ShotgunAttackBehaviour : AttackBehaviour
    {
        public override IAttack GetBehaviour(Tower tower)
        {
            var randomTargetSeek = new RandomEnemyAtPath(EnemyPoolReference.Value);
            var shotgunAttack = new ShotgunAttack(randomTargetSeek, tower.Stats, Projectile, tower.transform);

            return shotgunAttack;
        }
    }
}
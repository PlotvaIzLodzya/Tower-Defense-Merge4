using _Source.Scripts.Buildings;
using _Source.Scripts.Helpers;
using _Source.Scripts.Projectiles;
using UnityEngine;

namespace _Source.Scripts.AttackBehaviours
{
    [CreateAssetMenu(fileName = nameof(ShotgunAttackBehaviour), menuName = NamingConstant.AttackBehaviour + "/" + nameof(ShotgunAttackBehaviour))]
    public class ShotgunAttackBehaviour : AttackBehaviour
    {
        public override Tags Tags => TagsMapper.GetTags<ShotgunAttack>();

        public override IAttack GetBehaviour(Tower tower, Projectile projectilePrefab)
        {
            var randomTargetSeek = new RandomEnemyAtPath(EnemyPoolReference.Value);
            var shotgunAttack = new ShotgunAttack(randomTargetSeek, tower.Stats, projectilePrefab, tower.transform);

            return shotgunAttack;
        }
    }
}
using _Source.Scripts.Battle;
using _Source.Scripts.Buildings;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{

    [CreateAssetMenu(fileName = nameof(DealDamageAndDestroy), menuName = NamingConstant.ProjectilesBehaviours + "/" + NamingConstant.OnMovementEnd + "/" + nameof(DealDamageAndDestroy))]
    public class DealDamageAndDestroy : OnMovementEndBehaviour
    {
        public override void OnEnd(Enemy enemy, Projectile projectile)
        {
            enemy.TakeDamage(projectile.TowerStats.Damage);
            projectile.Destroy();
        }
    }
}
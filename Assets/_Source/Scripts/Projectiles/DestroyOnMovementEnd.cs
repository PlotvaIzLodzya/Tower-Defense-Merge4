using _Source.Scripts.Battle;
using _Source.Scripts.Buildings;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{
    [CreateAssetMenu(fileName = nameof(DestroyOnMovementEnd), menuName = NamingConstant.ProjectilesBehaviour + "/" + NamingConstant.OnMovementEnd + "/" + nameof(DestroyOnMovementEnd))]
    public class DestroyOnMovementEnd : OnMovementEnd
    {
        public override void OnEnd(Enemy enemy, Projectile projectile)
        {
            projectile.Destroy();
        }
    }
}
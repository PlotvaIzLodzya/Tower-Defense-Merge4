using _Source.Scripts.Buildings;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{

    [CreateAssetMenu(fileName = nameof(ToTargetMovement), menuName = NamingConstant.ProjectilesBehaviours + "/" + NamingConstant.ProjectilesMovements + "/" + nameof(ToTargetMovement))]
    public class ToTargetMovementBehaviour : ProjectileMovementBehaviour
    {
        public override IProjectileMovement GetMovement(Projectile projectile)
        {
            var toTargetMovemnt = new ToTargetMovement(projectile.Stats.Speed, projectile.transform);

            return toTargetMovemnt;
        }
    }
}
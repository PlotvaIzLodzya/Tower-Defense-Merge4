using UnityEngine;

namespace _Source.Scripts.Projectiles
{
    public abstract class ProjectileMovementBehaviour : ScriptableObject
    {
        public abstract IProjectileMovement GetMovement(Projectile projectile);
    }
}
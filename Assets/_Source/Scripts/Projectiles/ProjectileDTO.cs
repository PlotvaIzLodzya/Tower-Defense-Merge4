using System;

namespace _Source.Scripts.Projectiles
{
    [Serializable]
    public class ProjectileDTO
    {
        public ProjectileMovement Movement;
        public OnMovementEnd MovementEnd;
        public OnHitBehaviour  HitBehaviour;
        public OnStayOnEnemy StayOnEnemy;
    }
}
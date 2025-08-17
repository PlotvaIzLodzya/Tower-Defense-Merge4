using _Source.Scripts.Battle;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{
    public abstract class OnHitBehaviour : ScriptableObject
    {
        public abstract void OnHit(Enemy enemy, Projectile projectile);
    }
}
using _Source.Scripts.Battle;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{
    public abstract class OnMovementEndBehaviour : ScriptableObject
    {
        public abstract void OnEnd(Enemy enemy, Projectile projectile);
    }
}
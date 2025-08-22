using _Source.Scripts.Battle;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{
    public abstract class OnHitBehaviour : ScriptableObject, ITagUser
    {
        [field: SerializeField] public Tags Tags { get; private set; }
        public abstract void OnHit(Enemy enemy, Projectile projectile);
    }
}
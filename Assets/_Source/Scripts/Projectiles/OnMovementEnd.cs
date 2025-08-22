using _Source.Scripts.Battle;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{
    public abstract class OnMovementEnd : ScriptableObject, ITagUser
    {
        [field: SerializeField] public Tags Tags { get; private set; }
        
        public abstract void OnEnd(Enemy enemy, Projectile projectile);
    }
}
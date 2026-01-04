using _Source.Scripts.Battle;
using System.Collections;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{
    public abstract class ProjectileMovement : ScriptableObject, IProjectileMovement, ITagUser
    {
        [field: SerializeField] public Tags Tags { get; private set; }

        public abstract IEnumerator Moving(Enemy enemy, Projectile projectile);
    }
}
using _Source.Scripts.Battle;
using System.Collections;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{
    public abstract class ProjectileMovement : ScriptableObject, IProjectileMovement
    {
        public abstract IEnumerator Moving(Enemy enemy, Projectile projectile);
    }
}
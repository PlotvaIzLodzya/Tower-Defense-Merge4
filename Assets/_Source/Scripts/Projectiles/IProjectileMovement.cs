using _Source.Scripts.Battle;
using System.Collections;

namespace _Source.Scripts.Projectiles
{

    public interface IProjectileMovement
    {
        IEnumerator Moving(Enemy enemy, Projectile projectile);
    }
}
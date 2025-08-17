using _Source.Scripts.Battle;
using System.Collections;

namespace _Source.Scripts.Buildings
{
    public interface IProjectileMovement
    {
        IEnumerator Moving(Enemy enemy);
    }
}
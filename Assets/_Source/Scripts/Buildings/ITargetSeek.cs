using _Source.Scripts.Battle;

namespace _Source.Scripts.Buildings
{
    public interface ITargetSeek
    {
        bool TryGetTarget(out Enemy enemy);
    }
}
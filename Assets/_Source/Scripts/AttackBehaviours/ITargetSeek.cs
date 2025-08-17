using _Source.Scripts.Battle;
using System.Collections.Generic;

namespace _Source.Scripts.AttackBehaviours
{
    public interface IMutipleTargetSeek
    {
        bool TryGetTargets(List<Enemy> enemies, int maxAmount);
    }

    public interface ITargetSeek
    {
        bool TryGetTarget(out Enemy enemy);
    }
}
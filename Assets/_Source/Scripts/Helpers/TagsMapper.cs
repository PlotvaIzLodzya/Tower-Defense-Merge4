using System;
using _Source.Scripts.AttackBehaviours;

namespace _Source.Scripts.Helpers
{
    public static class TagsMapper
    {
        public static Tags GetTags<T>() where T : ITagUser
        {
            var type = typeof(T);

            return type switch
            {
                var t when t == typeof(SingleTargetAttack) => Tags.SingleTarget | Tags.Homing | Tags.Linear | Tags.Forward | Tags.Damage | Tags.AOE |
                                                              Tags.Duration,
                var t when t == typeof(MultiTargetAttack) => Tags.MultiTarget | Tags.Homing | Tags.Linear | Tags.Forward | Tags.Damage | Tags.AOE |
                                                             Tags.Duration,
                var t when t == typeof(ShotgunAttack) => Tags.Linear | Tags.Forward | Tags.Damage | Tags.AOE |
                                                         Tags.Duration,
                _ => throw new Exception($"No pattern match for {type}")
            };
        }
    }
}
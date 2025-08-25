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
                                                              Tags.Duration | Tags.Straight,
                var t when t == typeof(MultiTargetAttack) => Tags.MultiTarget | Tags.Homing | Tags.Linear | Tags.Forward | Tags.Damage | Tags.AOE |
                                                             Tags.Duration | Tags.Straight,
                var t when t == typeof(ShotgunAttack) => Tags.Linear | Tags.Forward | Tags.Damage | Tags.AOE |
                                                            Tags.Duration | Tags.Straight,
                _ => throw new Exception($"No pattern match for {type}")
            };
        }
    }
    
    public static class NamingConstant
    {
        public const string AttackBehaviour = "Attack behaviour";
        public const string ProjectilesBehaviour = "Projectiles behaviour";
        public const string Upgrades = "Upgrades";
        public const string ProjectilesMovement = "Movement";
        public const string OnMovementEnd = "On movement end";
        public const string OnHit = "On enemy hit";
        public const string OnStay = "On enemy stay";
    }
}
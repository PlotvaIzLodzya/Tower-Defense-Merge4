using System;

[Flags]
public enum Tags
{
    None = 0,
    SingleTarget = 1 << 0,
    MultiTarget = SingleTarget*2,
    Shotgun = MultiTarget*2,
    Homing = Shotgun*2,
    Linear = Homing*2,
    Forward = Linear*2,
    Damage = Forward*2,
    AOE = Damage*2,
    Duration = AOE*2,
    Ricochet = Duration * 2,
}

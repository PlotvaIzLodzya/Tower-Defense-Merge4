using _Source.Scripts.Battle;
using _Source.Scripts.Helpers;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{
    [CreateAssetMenu(fileName = nameof(DoNothingOnMovementEnd), menuName = NamingConstant.ProjectilesBehaviour + "/" + NamingConstant.OnMovementEnd + "/" + nameof(DoNothingOnMovementEnd))]
    public class DoNothingOnMovementEnd : OnMovementEnd
    {
        public override void OnEnd(Enemy enemy, Projectile projectile)
        {
            
        }
    }
}
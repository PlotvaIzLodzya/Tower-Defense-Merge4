using _Source.Scripts.Battle;
using _Source.Scripts.Helpers;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{

    [CreateAssetMenu(fileName = nameof(DoNothingOnHit), menuName = NamingConstant.ProjectilesBehaviour + "/" + NamingConstant.OnHit + "/" + nameof(DoNothingOnHit))]
    public class DoNothingOnHit : OnHitBehaviour
    {
        public override void OnHit(Enemy enemy, Projectile projectile)
        {
            
        }
    }
}
using _Source.Scripts.Buildings;
using _Source.Scripts.Projectiles;
using _Source.Scripts.ReferencesAndSources;
using UnityEngine;

namespace _Source.Scripts.AttackBehaviours
{
    public abstract class AttackBehaviour : ScriptableObject
    {
        [field: SerializeField] protected EnemyPoolReference EnemyPoolReference {get ; private set; }

        public abstract IAttack GetBehaviour(Tower tower, Projectile projectilePrefab);
    }
}
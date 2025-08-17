using _Source.Scripts.ReferencesAndSources;
using UnityEngine;

namespace _Source.Scripts.Buildings
{

    public abstract class AttackBehaviour : ScriptableObject
    {
        [field: SerializeField] protected Projectile Projectile { get; private set; }
        [field: SerializeField] protected EnemyPoolReference EnemyPoolReference {get ; private set; }

        public abstract IAttack GetAttackBehaviour(Tower tower);
    }
}
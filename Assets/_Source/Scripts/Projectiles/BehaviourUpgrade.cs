using _Source.Scripts.Buildings;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{
    public abstract class BehaviourUpgrade : ScriptableObject
    {
        public abstract string Name { get; protected set; }
        public abstract Tags Tags { get; }
        public abstract void Upgrade(AttackTower tower);
    }
}
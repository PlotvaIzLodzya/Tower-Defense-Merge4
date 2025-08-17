using _Source.Scripts.Battle;
using _Source.Scripts.Buildings;
using System.Collections;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        [field: SerializeField] public ProjectileStats Stats { get; private set; }

        [SerializeField] private ProjectileMovementBehaviour _movementBehaviour;
        [SerializeField] private OnMovementEndBehaviour _onMovementEndBehaviour;
        [SerializeField] private OnHitBehaviour _onHitBehaviour;

        private IProjectileMovement _movement;

        public TowerStats TowerStats { get; private set; }

        public void Launch(Enemy enemy, TowerStats stats)
        {
            TowerStats = stats;
            _movement = _movementBehaviour.GetMovement(this);
            StartCoroutine(MovingTowards(enemy));
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Enemy enemy))
                _onHitBehaviour.OnHit(enemy, this);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        private IEnumerator MovingTowards(Enemy enemy)
        {
            var speed = Stats.Speed;
            yield return _movement.Moving(enemy);

            _onMovementEndBehaviour.OnEnd(enemy, this);
        }
    }
}
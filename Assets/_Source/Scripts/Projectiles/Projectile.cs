using _Source.Scripts.Battle;
using _Source.Scripts.Buildings;
using System.Collections;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        [field: SerializeField] public ProjectileStats Stats { get; private set; }

        [SerializeField] private ProjectileMovement _movement;
        [SerializeField] private OnMovementEnd _onMovementEndBehaviour;
        [SerializeField] private OnHitBehaviour _onHitBehaviour;

        public TowerStats TowerStats { get; private set; }

        public void Launch(Enemy enemy, TowerStats stats)
        {
            TowerStats = stats;
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
            yield return _movement.Moving(enemy, this);

            _onMovementEndBehaviour.OnEnd(enemy, this);
        }
    }
}
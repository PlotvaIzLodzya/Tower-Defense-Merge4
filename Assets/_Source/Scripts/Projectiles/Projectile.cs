using System;
using _Source.Scripts.Battle;
using _Source.Scripts.Buildings;
using System.Collections;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{
    [Serializable]
    public class ProjectileDTO
    {
        public ProjectileMovement Movement;
        public OnMovementEnd MovementEnd;
        public OnHitBehaviour  HitBehaviour;
        public OnStayOnEnemy StayOnEnemy;
    }
    
    public class Projectile : MonoBehaviour, ITagUser
    {
        [field: SerializeField] public ProjectileStats Stats { get; private set; }
        [field: SerializeField] public Tags Tags { get; private set; }
        
        [SerializeField] private ProjectileMovement _movement;
        [SerializeField] private OnMovementEnd _onMovementEndBehaviour;
        [SerializeField] private OnHitBehaviour _onHitBehaviour;
        [SerializeField] private OnStayOnEnemy _onStayOnEnemyBehaviour;

        private float _enemyStayedElapsedTime;

        public TowerStats TowerStats { get; private set; }
        
        [ContextMenu(nameof(UpdateTags))]
        private void UpdateTags()
        {
            if(_movement != null)
                Tags |= _movement.Tags;
            if(_onHitBehaviour != null)
                Tags |= _onHitBehaviour.Tags;
            if(_onMovementEndBehaviour != null)
                Tags |= _onMovementEndBehaviour.Tags;
            if(_onStayOnEnemyBehaviour != null)
                Tags |= _onStayOnEnemyBehaviour.Tags;
        }

        public void Upgrade(ProjectileDTO dto)
        {
            _movement = dto.Movement ?? _movement;
            _onMovementEndBehaviour = dto.MovementEnd ?? _onMovementEndBehaviour;
            _onHitBehaviour = dto.HitBehaviour ?? _onHitBehaviour;
            _onStayOnEnemyBehaviour = dto.StayOnEnemy ?? _onStayOnEnemyBehaviour;
        }

        public void Launch(Enemy enemy, TowerStats stats)
        {
            TowerStats = stats;
            StartCoroutine(MovingTowards(enemy));
            StartCoroutine(DestroyAfter(5f, _movement.LifeTime));
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Enemy enemy))
                _onHitBehaviour?.OnHit(enemy, this);
        }

        private void OnTriggerStay(Collider other)
        {
            if(other.TryGetComponent(out Enemy enemy))
                _onStayOnEnemyBehaviour?.OnStay(enemy, this, ref _enemyStayedElapsedTime);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        private IEnumerator MovingTowards(Enemy enemy)
        {
            yield return _movement?.Moving(enemy, this);

            _onMovementEndBehaviour?.OnEnd(enemy, this);
        }

        private IEnumerator DestroyAfter(float time, float lifeTime)
        {
            var delay = Mathf.Max(time, lifeTime);
            yield return new WaitForSeconds(delay);
            Destroy();
        }
    }
}
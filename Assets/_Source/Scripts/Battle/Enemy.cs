using System;
using System.Collections;
using _Source.Scripts.Buildings;
using _Source.Scripts.Grid;
using _Source.Scripts.ReferencesAndSources;
using UnityEngine;

namespace _Source.Scripts.Battle
{
    [Serializable]
    public class EnemyConfig
    {
        public int Damage = 50;
        public int Health = 100;
        public int Reward = 10;
        public float Speed = 100f;
    }
    
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private CellGridReference _cellGridReference;
        [SerializeField] private EnemyConfig _config;

        private int _damage;
        private float _speed;
        private Health _health;
        private CellGrid _cellGrid;
        private Path[] _paths;
        
        public int Reward { get; private set; }
        public bool IsDead { get; private set; }

        private void Awake()
        {
            _health = new(_config.Health);
            _speed = _config.Speed;
            _damage = _config.Damage;
            Reward = _config.Reward;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Gates gates))
            {
                gates.TakeDamage(_damage);
                Die();
            }
        }

        public void StartMoving(Path[] paths)
        {
            _paths = paths;
            StartCoroutine(MovingByPath());
        }

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
            if (_health.IsEmpty)
            {
                Die();
            }
        }

        private void Die()
        {
            IsDead = true;
            gameObject.SetActive(false);
        }

        private IEnumerator MovingByPath()
        {
            foreach (var path in _paths)
            {
                yield return MovingToNextPoint(path);
            }
        }

        private IEnumerator MovingToNextPoint(Path path)
        {
            var startPos = transform.position.ToGrid();
            var dist = Vector3Int.Distance(startPos, path.GridPosition);
            var time = dist / _speed;
            var elapsedTime = 0f;
            while (elapsedTime < time)
            {
                elapsedTime += Time.deltaTime;
                transform.position = Vector3.Lerp(startPos, path.GridPosition, elapsedTime/time);
                yield return null;
            }
            transform.position = path.GridPosition.ToWorld();
        }
    }
}

using System;
using System.Collections;
using _Source.Scripts.Grid;
using _Source.Scripts.ReferencesAndSources;
using UnityEngine;

namespace _Source.Scripts.Battle
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private CellGridReference _cellGridReference;
        [SerializeField] private float _speed;

        private int _health;
        private CellGrid _cellGrid;
        private Path[] _paths;
        
        public bool IsDead { get; private set; }

        private void Awake()
        {
            _health = 100;
        }

        public void StartMoving(Path[] paths)
        {
            _paths = paths;
            StartCoroutine(MovingByPath());
        }

        public void DealDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
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

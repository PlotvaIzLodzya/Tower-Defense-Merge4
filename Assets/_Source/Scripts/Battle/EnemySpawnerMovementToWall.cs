using System;
using System.Collections;
using System.Linq;
using _Source.Scripts.Buildings;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Source.Scripts.Battle
{
    public class EnemySpawnerMovementToWall : MonoBehaviour
    {
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private Gates[] _targetGates;
        [SerializeField] private SpawnPoint[] _spawnPoints;
        [SerializeField] private int _amount;
        [SerializeField] private float _delay;

        private void Start()
        {
            StartCoroutine(Spawning());
        }
        
        private IEnumerator Spawning()
        {
            for (int i = 0; i < _amount; i++)
            {
                var targetGate = _targetGates[Random.Range(0, _targetGates.Length)];
                var spawnPoint = _spawnPoints.First(p => p.GridPosition.z == targetGate.GridPosition.z);
                var randomDelta = Random.Range(-0.5f, 0.5f);
                randomDelta = (float)Math.Round(randomDelta, 1);
                var spawnPosition = spawnPoint.transform.position + Vector3.forward * randomDelta;
                var enemy = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
                enemy.StartMoving(targetGate);
                _enemyPool.Add(enemy);
                yield return new WaitForSeconds(_delay);
            }
        }
    }
}
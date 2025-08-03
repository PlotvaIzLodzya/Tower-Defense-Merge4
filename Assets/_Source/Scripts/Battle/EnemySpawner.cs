using System.Collections;
using _Source.Scripts.Grid;
using UnityEngine;

namespace _Source.Scripts.Battle
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private Path[] _paths;
        [SerializeField] private Enemy _enemyPrefab;
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
                var enemy = Instantiate(_enemyPrefab, _paths[0].transform.position, Quaternion.identity);
                enemy.transform.SetParent(transform);
                enemy.StartMoving(_paths);
                _enemyPool.Add(enemy);
                yield return new WaitForSeconds(_delay);
            }
        }
    }
}
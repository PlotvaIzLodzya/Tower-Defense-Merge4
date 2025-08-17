using _Source.Scripts.Battle;
using System.Collections;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private ProjectileStats _stats;

        private TowerStats _towerStats;

        public void Launch(Enemy enemy, TowerStats stats)
        {
            _towerStats = stats;
            StartCoroutine(MovingToTarget(enemy));
        }

        private IEnumerator MovingToTarget(Enemy enemy)
        {
            var speed = _stats.Speed;
            while (IsCloseEnough(enemy))
            {
                transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, speed * Time.deltaTime);
                transform.LookAt(enemy.transform);
                yield return null;
            }
            
            enemy.TakeDamage(_towerStats.Damage);
            DestroyProjectile();
        }

        private void DestroyProjectile()
        {
            Destroy(gameObject);
        }

        private bool IsCloseEnough(Enemy target)
        {
            Debug.Log(target == null);
            return Vector3.Distance(target.transform.position, transform.position) > _stats.Speed * Time.deltaTime;
        }
    }
}
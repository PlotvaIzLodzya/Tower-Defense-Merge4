using System.Collections;
using _Source.Scripts.Battle;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class Projectile : MonoBehaviour
    {
        private TowerStats _stats;

        public void Launch(Enemy enemy, TowerStats stats)
        {
            _stats = stats;
            StartCoroutine(MovingToTarget(enemy));
        }

        private IEnumerator MovingToTarget(Enemy enemy)
        {
            var speed = _stats.ProjectileStats.Speed;
            while (IsCloseEnough(enemy.transform.position))
            {
                transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, speed * Time.deltaTime);
                transform.LookAt(enemy.transform);
                yield return null;
            }
            
            enemy.TakeDamage(_stats.Damage);
            DestroyProjectile();
        }

        private void DestroyProjectile()
        {
            Destroy(gameObject);
        }

        private bool IsCloseEnough(Vector3 target)
        {
            return Vector3.Distance(target, transform.position) > _stats.ProjectileStats.Speed * Time.deltaTime;
        }
    }
}
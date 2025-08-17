using _Source.Scripts.Battle;
using System.Collections;
using UnityEngine;

namespace _Source.Scripts.Projectiles
{

    public class ToTargetMovement : IProjectileMovement
    {
        private float _speed;
        private Transform _transform;

        public ToTargetMovement(float speed, Transform transform)
        {
            _speed = speed;
            _transform = transform;
        }

        public IEnumerator Moving(Enemy enemy)
        {
            while (IsCloseEnough(enemy))
            {
                _transform.position = Vector3.MoveTowards(_transform.position, enemy.transform.position, _speed * Time.deltaTime);
                _transform.LookAt(enemy.transform);
                yield return null;
            }
        }

        private bool IsCloseEnough(Enemy target)
        {
            return Vector3.Distance(target.transform.position, _transform.position) > _speed * Time.deltaTime;
        }
    }
}
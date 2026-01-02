using System.Collections.Generic;
using UnityEngine;

namespace _Source.Scripts.Helpers
{
    public static class VectorExtensions
    {
        public static Vector3 CalculateDirection90Degrees(this Vector3 start, Vector3 end)
        {
            var direction = (end - start).normalized;
            return direction.CalculateDirection90Degrees();
        }
        
        public static Vector3 CalculateDirection90Degrees(this Vector3 direction)
        {
            var x = Mathf.Abs(direction.x);
            var z = Mathf.Abs(direction.z);

            if(x >= z)
                direction.z = 0f;
            else
                direction.x = 0f;

            return direction.normalized;

        }


        //Some ai genereated shit
        /// <summary>
        /// Возвращает список случайных направлений в конусе вокруг direction
        /// </summary>
        /// <param name="direction">Центральное направление</param>
        /// <param name="angle">Угол конуса в градусах</param>
        /// <param name="count">Количество направлений</param>
        public static List<Vector3> GetRandomDirections(Vector3 direction, float angle, int count)
        {
            List<Vector3> result = new List<Vector3>(count);

            direction = direction.normalized;
            float halfAngle = angle * 0.5f;

            for (int i = 0; i < count; i++)
            {
                float randomAngle = Random.Range(0f, halfAngle);
                Vector3 randomAxis = Random.onUnitSphere;

                Quaternion rotation = Quaternion.AngleAxis(randomAngle, randomAxis);
                Vector3 randomDirection = rotation * direction;

                result.Add(randomDirection.normalized);
            }

            return result;
        }

        /// <summary>
        /// Generate directions around given <paramref name="direction"></paramref> with <paramref name="angle"></paramref> step and <paramref name="count"></paramref>
        /// 
        /// </summary>
        /// <param name="direction"> Around this will be generate others direction, it's centeral </param>
        /// <param name="angle">Angle between two directions</param>
        /// <param name="count">Amount of directions genterated</param>
        /// <returns></returns>
        //Some ai genereated shit
        public static List<Vector3> GenerateDirections(Vector3 direction, float angle, int count)
        {
            List<Vector3> directions = new List<Vector3>();
            
            Vector3 normalizedDirection = direction.normalized;
            
            if (count == 1 || Mathf.Approximately(angle, 0f))
            {
                directions.Add(normalizedDirection);
                return directions;
            }
            
            bool isEvenCount = count % 2 == 0;
            int halfCount = count / 2;
            
            if (isEvenCount)
            {
                for (int i = 0; i < count; i++)
                {
                    float currentAngle = (-halfCount + i + 0.5f) * angle;
                    Vector3 rotatedDirection = Quaternion.AngleAxis(currentAngle, Vector3.up) * normalizedDirection;
                    directions.Add(rotatedDirection.normalized);
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    float currentAngle = (-halfCount + i) * angle;
                    Vector3 rotatedDirection = Quaternion.AngleAxis(currentAngle, Vector3.up) * normalizedDirection;
                    directions.Add(rotatedDirection.normalized);
                }
            }
        
            return directions;
        }
        
    }
}

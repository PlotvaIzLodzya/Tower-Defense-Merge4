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

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
        
    }
}

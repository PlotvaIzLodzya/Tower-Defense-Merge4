using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class Health
    {
        public int Current { get; private set; }
        public int Max { get; private set; }
        
        public bool IsEmpty => Current <= 0;

        public Health(int max)
        {
            Current = max;
            Max = max;
        }

        public void TakeDamage(int amount)
        {
            ChangeAmount(-amount);
        }

        private void ChangeAmount(int amount)
        {
            Current += amount;
            Current = Mathf.Clamp(Current, 0, Max);
        }
    }
}
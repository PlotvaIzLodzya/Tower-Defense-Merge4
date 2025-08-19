using _Source.Scripts.Helpers;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class AttackSpeed
    {
        private float _maxValue;
        private float _minValue;

        public AttackSpeed() 
        {
            _maxValue = GameConfig.MaxAttackDelay;
            _minValue = GameConfig.MinAttackDelay;
        }

        public AttackSpeed(float maxValue, float minValue)
        {
            _maxValue = maxValue;
            _minValue = minValue;
        }

        public float CalculateAttackDelay(float attackSpeed)
        {
            return Mathf.Lerp(_maxValue, _minValue, attackSpeed / GameConfig.MaxAttackSpeed);
        }
    }
}
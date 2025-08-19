using _Source.Scripts.Grid;
using _Source.Scripts.Helpers;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class Gates : MonoBehaviour, ICell
    {
        private Health _health;
        
        public Vector3Int GridPosition => transform.position.ToGrid();

        private void Awake()
        {
            _health = new(GameConfig.GateHealth);
        }

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
            
            if(_health.IsEmpty)
                Die();
        }

        private void Die()
        {
            gameObject.SetActive(false);
        }
    }
}
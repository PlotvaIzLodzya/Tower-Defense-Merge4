using _Source.Scripts.Buildings;
using UnityEngine;

namespace _Source.Scripts.Grid
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private bool _highlighted;
        
        public Building Building { get; private set; }
        
        public Vector3Int GridPosition => transform.position.ToGrid();
        public virtual bool CanPaceBuilding => true;
        public virtual bool HaveBuilding => Building is null;
        
        public void SetBuilding(Building building)
        {
            Building = building;
        }

        public BuildingConfig DestroyBuilding()
        {
            var config = Building.Config;
            Building.Destroy();
            Building = null;
            
            return config;
        }

        public void Highlight()
        {
            if(_spriteRenderer == null)
                return;
            
            _highlighted = !_highlighted;
            if(_highlighted)
                _spriteRenderer.color *= 2f;
            else
                Unhighlight();
        }

        public void Unhighlight()
        {
            _spriteRenderer.color /= 2f;
        }
    }
}
using _Source.Scripts.Grid;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class BuildingCell : MonoBehaviour, ICell
    {
        public Tower Tower { get; private set; }
        public Vector3Int GridPosition => transform.position.ToGrid();
        public bool HaveBuilding => Tower != null;

        public void SetBuilding(Tower tower)
        {
            Tower = tower;
        }
        
        public TowerStats DestroyBuilding()
        {
            var config = Tower.Stats;
            Tower.Destroy();
            Tower = null;
            
            return config;
        }
    }
}
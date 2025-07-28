using _Source.Scripts.Grid;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class BuildingCell : MonoBehaviour, ICell
    {
        public Building Building { get; private set; }
        public Vector3Int GridPosition => transform.position.ToGrid();
        public bool HaveBuilding => Building != null;

        public void SetBuilding(Building building)
        {
            Building = building;
        }
        
        public BuildingStats DestroyBuilding()
        {
            var config = Building.Stats;
            Building.Destroy();
            Building = null;
            
            return config;
        }
    }
}
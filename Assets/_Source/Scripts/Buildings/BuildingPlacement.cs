using System.Collections.Generic;
using System.Linq;
using _Source.Scripts.Grid;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class BuildingPlacement : MonoBehaviour
    {
        [SerializeField] private CellGrid _cellGrid;
        [SerializeField] private Building _buildingPrefab;
        
        private List<BuildingCell> _buildingCells;
        private BuildingMerge _buildingMerge;
        private Camera _camera;

        private void Awake()
        {
            _buildingCells = new();
            _buildingMerge = new(_cellGrid);
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit) && _cellGrid.HasCell<BuildingCell>(hit.point))
                {
                    _buildingCells.Clear();
                    if (TryGetCellsBy(_buildingPrefab, hit.point, _buildingCells))
                    {
                        var canPlace = _buildingCells.All(c => c.HaveBuilding == false);
                    
                        if (canPlace)
                        {
                            PlaceBuilding(_buildingCells, _buildingPrefab);
                            _buildingMerge.TryMerge(_buildingCells);
                        }
                    }
                }
            }
        }

        private bool TryGetCellsBy(Building building, Vector3 point, List<BuildingCell> cellsToPlace)
        {
            foreach (var offset in building.Form)
            {
                var cellPos = point - offset;
                if (_cellGrid.TryGetCell<BuildingCell>(cellPos, out var cell))
                    cellsToPlace.Add(cell);
                else
                    return false;
            }
            
            return true;
        }

        private void PlaceBuilding(List<BuildingCell> cellsToPlace, Building buildingPrefab)
        {
            foreach (var cell in cellsToPlace)
            {
                var building = Instantiate(buildingPrefab, cell.transform);
                cell.SetBuilding(building);                
            }
        }
    }
}
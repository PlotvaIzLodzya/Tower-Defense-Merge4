using System.Collections.Generic;
using System.Linq;
using _Source.Scripts.Grid;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class BuildPlacement : MonoBehaviour
    {
        [SerializeField] private CellGrid _cellGrid;
        [SerializeField] private Building _buildingPrefab;
        
        private List<Cell> _pacementCells;
        private BuildingMerge _buildingMerge;
        private Camera _camera;

        private void Awake()
        {
            _pacementCells = new();
            _buildingMerge = new(_cellGrid);
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit) && _cellGrid.HasCellAt(hit.point))
                {
                    _pacementCells.Clear();
                    if (TryGetCellsBy(_buildingPrefab, hit.point, _pacementCells))
                    {
                        var canPlace = _pacementCells.All(c => c.HaveBuilding);
                    
                        if (canPlace)
                        {
                            PlaceBuilding(_pacementCells, _buildingPrefab);
                            _buildingMerge.TryMerge(_pacementCells);
                        }
                    }
                }
            }
        }

        private bool TryGetCellsBy(Building building, Vector3 point, List<Cell> cellsToPlace)
        {
            foreach (var offset in building.Form)
            {
                var cellPos = point - offset;
                if (_cellGrid.TryGetCellAt(cellPos, out var cell))
                    cellsToPlace.Add(cell);
                else
                    return false;
            }
            
            return true;
        }

        private void PlaceBuilding(List<Cell> cellsToPlace, Building buildingPrefab)
        {
            foreach (var cell in cellsToPlace)
            {
                var building = Instantiate(buildingPrefab, cell.transform);
                cell.SetBuilding(building);                
            }
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using _Source.Scripts.Grid;
using _Source.Scripts.ReferencesAndSources;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class BindBuildingToCell
    {
        public BuildingCell Cell;
        public Building Building;

        public void Build()
        {
            var building = Object.Instantiate(Building, Cell.transform);
            building.OnBuild();
            Cell.SetBuilding(building);   
        }
    }

    public class BuildingPlacement : MonoBehaviour
    {
        [SerializeField] private BuildingPresets _presets;
        [SerializeField] private CellGridReference _cellGridReference;
        [SerializeField] private BuildingBlock _buildingBlockPrefab;
        
        private List<BindBuildingToCell> _buildingCells;
        private BuildingMerge _buildingMerge;
        private Camera _camera;
        private CellGrid _cellGrid;

        private void Start()
        {
            _cellGrid = _cellGridReference.Value;
            _buildingCells = new();
            _buildingMerge = new(_cellGrid);
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
                Place();
        }

        public void CreateBuilding(BuildingBlockBlueprint blueprint)
        {
            if(_presets.TryGetPreset(blueprint, out var prefab))
                _buildingBlockPrefab = prefab;
        }

        private void Place()
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit) && _cellGrid.HasCell<BuildingCell>(hit.point))
            {
                _buildingCells.Clear();
                if (TryGetCellsBy(_buildingBlockPrefab, hit.point, _buildingCells))
                {
                    var canPlace = _buildingCells.All(bind => bind.Cell.HaveBuilding == false);
                    
                    if (canPlace)
                    {
                        PlaceBuilding(_buildingCells);
                        _buildingMerge.TryMerge(_buildingCells);
                    }
                }
            }
        }

        private bool TryGetCellsBy(BuildingBlock building, Vector3 point, List<BindBuildingToCell> bindings)
        {
            foreach (var piece in building.Form)
            {
                var cellPos = point - piece.Offset;
                if (_cellGrid.TryGetCell<BuildingCell>(cellPos, out var cell))
                    bindings.Add(new BindBuildingToCell { Cell = cell, Building = piece.Building });
                else
                    return false;
            }
            
            return true;
        }

        private void PlaceBuilding(List<BindBuildingToCell> binds)
        {
            foreach (var bind in binds)
            {
                bind.Build();
            }
        }
    }
}
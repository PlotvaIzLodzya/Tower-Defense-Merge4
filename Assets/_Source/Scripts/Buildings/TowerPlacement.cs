using System.Collections.Generic;
using System.Linq;
using _Source.Scripts.Grid;
using _Source.Scripts.ReferencesAndSources;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class BindTowerToCell
    {
        public BuildingCell Cell;
        public Tower Tower;

        public void Build()
        {
            var building = Object.Instantiate(Tower, Cell.transform);
            building.OnBuild();
            Cell.SetBuilding(building);   
        }
    }

    public class TowerPlacement : MonoBehaviour
    {
        [SerializeField] private LevelConfigProvider _levelConfigProvider;
        [SerializeField] private CellGridReference _cellGridReference;
        [SerializeField] private TowerBlockPreset _towerBlockPresetPrefab;
        
        private List<BindTowerToCell> _binds;
        private TowerMerge _towerMerge;
        private Camera _camera;
        private CellGrid _cellGrid;
        private LevelConfig _levelConfig;

        private void Start()
        {
            _levelConfig = _levelConfigProvider.LevelConfig;
            _cellGrid = _cellGridReference.Value;
            _binds = new();
            _towerMerge = new(_cellGrid);
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
                Place();
        }

        public void CreateBuilding(TowersBlockBlueprint blueprint)
        {
            if(_levelConfig.Presets.TryGetPreset(blueprint, out var prefab))
                _towerBlockPresetPrefab = prefab;
        }

        private void Place()
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit) && _cellGrid.HasCell<BuildingCell>(hit.point))
            {
                _binds.Clear();
                if (TryGetCellsBy(_towerBlockPresetPrefab, hit.point, _binds))
                {
                    var canPlace = _binds.All(bind => bind.Cell.HaveBuilding == false);
                    
                    if (canPlace)
                    {
                        PlaceTower(_binds);
                        _towerMerge.TryMerge(_binds);
                    }
                }
            }
        }

        private bool TryGetCellsBy(TowerBlockPreset towersBlock, Vector3 point, List<BindTowerToCell> bindings)
        {
            foreach (var blueprint in towersBlock.Blueprints)
            {
                var cellPos = point - blueprint.Offset;
                if (_cellGrid.TryGetCell<BuildingCell>(cellPos, out var cell))
                {
                    bindings.Add(new BindTowerToCell { Cell = cell, Tower = _levelConfig.TowerPrefab });
                }
                else
                {
                    return false;
                }
            }
            
            return true;
        }

        private void PlaceTower(List<BindTowerToCell> binds)
        {
            foreach (var bind in binds)
            {
                bind.Build();
            }
        }
    }
}
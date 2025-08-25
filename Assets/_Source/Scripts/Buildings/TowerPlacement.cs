using System;
using System.Collections.Generic;
using System.Linq;
using _Source.Scripts.Controls;
using _Source.Scripts.Grid;
using _Source.Scripts.ReferencesAndSources;
using _Source.Scripts.TowerUpgradeSystem;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Source.Scripts.Buildings
{
    public class BindTowerToCell
    {
        public BuildingCell Cell;
        public Tower Tower;
        public TowerStats Stats;

        public void Build()
        {
            var building = Object.Instantiate(Tower, Cell.transform);
            building.OnBuild();
            building.SetStats(Stats);
            Cell.SetBuilding(building);   
        }
    }


    public class TowerPlacement : MonoBehaviour
    {
        [SerializeField] private InputReference _inputReference;
        [SerializeField] private TowerPlacementPreview _towerPreview;
        [SerializeField] private LevelConfigProvider _levelConfigProvider;
        [SerializeField] private CellGridReference _cellGridReference;
        [SerializeField] private MergeEffect _mergeEffect;
        [SerializeField] private TowerUpgradePanel _towerUpgradePanel;
        
        private IInput _input;
        private TowerMerge _towerMerge;
        private Camera _camera;
        private CellGrid _cellGrid;
        private LevelConfig _levelConfig;
        private TowerBlockPreset _towerBlockPresetPrefab;
        private SortedSet<BindTowerToCell> _bindsSorted;
        private List<BindTowerToCell> _binds;
        private Action _onPlacement;

        private void Start()
        {
            _input = _inputReference.Value;
            _levelConfig = _levelConfigProvider.LevelConfig;
            _cellGrid = _cellGridReference.Value;
            _binds = new();
            _towerMerge = new(_cellGrid, _mergeEffect, _towerUpgradePanel);
            _camera = Camera.main;
        }

        private void Update()
        {
            if (_input.PointerUp)
                Place();
        }

        public void SetPresetPrefab(BlockPlacementDto placementDto)
        {
            _towerBlockPresetPrefab = placementDto.Prefab;
            _onPlacement = placementDto.OnPlacement;
            _towerPreview.SetTowerBlockPreset(placementDto.Prefab);
        }

        public void DeleteCurrent()
        {
            _towerBlockPresetPrefab = null;
            _towerPreview.DeletePreview();
        }

        private void Place()
        {
            if(_towerBlockPresetPrefab == null)
                return;
            
            var ray = _camera.ScreenPointToRay(_input.PointerPosition);
            if (Physics.Raycast(ray, out var hit) && _cellGrid.HasCell<BuildingCell>(hit.point))
            {
                _binds.Clear();
                if (TryGetCellsBy(_towerBlockPresetPrefab, hit.point, _binds))
                {
                    var canPlace = _binds.All(bind => bind.Cell.HaveBuilding == false);
                    
                    if (canPlace)
                    {
                        PlaceTower(_binds);
                        StartCoroutine(_towerMerge.TryMerge(_binds));
                        _towerPreview.DeletePreview();
                        _onPlacement?.Invoke();
                    }
                }
            }
            
            _towerBlockPresetPrefab = null;
            _towerPreview.DeletePreview();
            
        }

        private bool TryGetCellsBy(TowerBlockPreset towersBlock, Vector3 point, List<BindTowerToCell> bindings)
        {
            foreach (var blueprint in towersBlock.Blueprints)
            {
                var cellPos = point + blueprint.Offset;
                if (_cellGrid.TryGetCell<BuildingCell>(cellPos, out var cell))
                {
                    var towerPrefab = _levelConfig.TowerPrefab;
                    var bind = new BindTowerToCell { Cell = cell, Tower = towerPrefab, Stats = blueprint.Stats};
                    bindings.Add(bind);
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
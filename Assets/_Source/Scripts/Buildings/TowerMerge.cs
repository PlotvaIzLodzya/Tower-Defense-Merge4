using System.Collections.Generic;
using System.Linq;
using _Source.Scripts.Grid;
using UnityEngine;

namespace _Source.Scripts.Buildings
{

    public class MergeData
    {
        public List<BuildingCell> CellsToMerge;

        public TowerStats Config;
    }
    
    public class TowerMerge
    {
        private CellGrid _cellGrid;
        private List<BuildingCell> _squareCell;

        public TowerMerge(CellGrid cellGrid)
        {
            _squareCell = new List<BuildingCell>(4);
            _cellGrid = cellGrid;
        }

        public void TryMerge(List<BindTowerToCell> bindings)
        {
            bindings = bindings.OrderByDescending(b=>b.Cell.GridPosition.x)
                .ThenBy(b =>b.Cell.GridPosition.z)
                .ToList();
            var mergeData = new List<MergeData>();
            foreach (var bind in bindings)
            {
                _squareCell.Clear();
                if (_cellGrid.SquareCheck(bind.Cell, _squareCell, IsCellValid))
                {
                    // SquareMerge(bind.Cell, _squareCell);
                    AddMergeData(bind.Cell, _squareCell, mergeData);
                }        
            }

            foreach (var data in mergeData)
            {
                var cellToMerge = data.CellsToMerge;
                var cellMergeTo = cellToMerge[0];
                for (int i = 1; i < cellToMerge.Count; i++)
                {
                    // var config = cellToMerge[i].DestroyBuilding();
                
                    cellToMerge[i].SetWillBeMerged(false);
                    cellToMerge[i].MergeTo(cellMergeTo.Tower);
                }
                cellMergeTo.SetWillBeMerged(false);
                cellMergeTo.Tower.SetStats(data.Config);
            }
        }
        
        private void AddMergeData(BuildingCell cell, List<BuildingCell> squareCell, List<MergeData> mergeData)
        {
            squareCell.Clear();
            while (_cellGrid.SquareCheck(cell, squareCell, IsCellValid))
            {
                mergeData.Add(CreateMergeData(squareCell));
            }
        }

        private MergeData CreateMergeData(List<BuildingCell> cellToMerge)
        {
            cellToMerge = cellToMerge.OrderByDescending(c => c.GridPosition.x)
                .ThenBy(c => c.GridPosition.z)
                .ToList();
            
            var cellMergeTo = cellToMerge.First();
            var mergeConfig = new TowerStats();
            foreach (var cell in cellToMerge)
            {
                mergeConfig.Add(cell.Tower.Stats);
                cell.SetWillBeMerged(true);
            }

            var mergeData = new MergeData()
            {
                CellsToMerge = cellToMerge,
                Config = mergeConfig,
            };
            
            return mergeData;
        }
        

        private void SquareMerge(BuildingCell cell, List<BuildingCell> squareCell)
        {
            squareCell.Clear();
            while (_cellGrid.SquareCheck(cell, squareCell, IsCellValid))
            {
                cell = Merge(squareCell);
            }
        }

        private bool IsCellValid(BuildingCell cell)
        {
            return cell.HaveBuilding && cell.WillBeMerged == false;
        }

        private BuildingCell Merge(List<BuildingCell> cellToMerge)
        {
            cellToMerge = cellToMerge.OrderByDescending(c => c.GridPosition.x)
                                     .ThenBy(c => c.GridPosition.z)
                                     .ToList();
            
            var cellMergeTo = cellToMerge.First();
            var mergeConfig = new TowerStats();
            mergeConfig.Add(cellMergeTo.Tower.Stats);
            
            for (int i = 1; i < cellToMerge.Count; i++)
            {
                var config = cellToMerge[i].DestroyBuilding();
                
                // cellToMerge[i].SetWillBeMerged(true);
                cellToMerge[i].MergeTo(cellMergeTo.Tower);
                mergeConfig.Add(config);
            }
            
            cellMergeTo.Tower.SetStats(mergeConfig);
            return cellMergeTo;
        }
    }
}
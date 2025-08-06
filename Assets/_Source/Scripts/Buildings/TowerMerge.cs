using System.Collections.Generic;
using System.Linq;
using _Source.Scripts.Grid;

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
        private MergeEffect _mergeEffect;

        public TowerMerge(CellGrid cellGrid, MergeEffect mergeEffect)
        {
            _squareCell = new List<BuildingCell>(4);
            _cellGrid = cellGrid;
            _mergeEffect = mergeEffect;
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
                    AddMergeData(bind.Cell, _squareCell, mergeData);
            }
            
            _mergeEffect.Play(mergeData);
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
            
            var mergeConfig = new TowerStats();
            foreach (var cell in cellToMerge)
            {
                mergeConfig.Add(cell.Tower.Stats);
                cell.MarkToMerge(true);
            }

            var mergeData = new MergeData()
            {
                CellsToMerge = cellToMerge,
                Config = mergeConfig,
            };
            
            return mergeData;
        }
        

        private bool IsCellValid(BuildingCell cell)
        {
            return cell.HaveBuilding && cell.IsInMerge == false;
        }
        
    }
}
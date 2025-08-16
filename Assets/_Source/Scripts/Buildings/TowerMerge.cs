using _Source.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _Source.Scripts.Buildings
{
    public class MergeData
    {
        public List<BuildingCell> CellsToMerge;
        public BuildingCell CellMergeTo;
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

        public IEnumerator TryMerge(List<BindTowerToCell> bindings)
        {
            bindings = bindings.OrderBy(b=>b.Cell.GridPosition.x)
                               .ThenBy(b =>b.Cell.GridPosition.z)
                               .ToList();
            
            foreach (var bind in bindings)
            {
                _squareCell.Clear();

                if (_cellGrid.SquareCheck(bind.Cell, _squareCell, IsCellValid))
                    yield return SquareChecking(bind.Cell, _squareCell);
            }
        }

        private IEnumerator SquareChecking(BuildingCell cell, List<BuildingCell> squareCell)
        {
            squareCell.Clear();
            while (_cellGrid.SquareCheck(cell, squareCell, IsCellValid))
            {
                yield return Merging(squareCell);
            }
        }

        private IEnumerator Merging(List<BuildingCell> cellToMerge)
        {
            var mergeData = CreateMergeData(cellToMerge);
            
            yield return _mergeEffect.Play(mergeData, Merge);
        }

        private void Merge(MergeData mergeData)
        {
            mergeData.CellMergeTo.Tower.SetStats(mergeData.Config);
        }

        private MergeData CreateMergeData(List<BuildingCell> cellsToMerge)
        {
            cellsToMerge = cellsToMerge.OrderByDescending(c => c.GridPosition.x)
                                     .ThenBy(c => c.GridPosition.z)
                                     .ToList();
            
            var mergeConfig = new TowerStats();
            foreach (var cell in cellsToMerge)
            {
                mergeConfig.Upgrade(cell.Tower.Stats);
            }

            var mergeData = new MergeData()
            {
                CellsToMerge = cellsToMerge,
                CellMergeTo = cellsToMerge[0],
                Config = mergeConfig,
            };
            
           
            return mergeData;
        }

        private bool IsCellValid(BuildingCell cell)
        {
            return cell.HaveBuilding;
        }
    }
}
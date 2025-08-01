using System.Collections.Generic;
using System.Linq;
using _Source.Scripts.Grid;

namespace _Source.Scripts.Buildings
{
    public class TowerMerge
    {
        private CellGrid _cellGrid;
        private List<BuildingCell> _squareCell;

        public TowerMerge(CellGrid cellGrid)
        {
            _squareCell = new List<BuildingCell>(4);
            _cellGrid = cellGrid;
        }

        public void TryMerge(List<BindTowerToCell> bindBuildingsToCells)
        {
            foreach (var bind in bindBuildingsToCells)
            {
                _squareCell.Clear();
                if (_cellGrid.SquareCheck(bind.Cell, _squareCell, IsCellValid))
                {
                    SquareMerge(bind.Cell, _squareCell);
                }        
            }
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
            return cell.HaveBuilding;
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
                mergeConfig.Add(config);
            }
            
            cellMergeTo.Tower.Merge(mergeConfig);
            return cellMergeTo;
        }
    }
}
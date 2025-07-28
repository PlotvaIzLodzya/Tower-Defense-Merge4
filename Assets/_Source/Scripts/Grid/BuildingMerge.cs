using System.Collections.Generic;
using System.Linq;
using _Source.Scripts.Grid;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class BuildingMerge
    {
        private CellGrid _cellGrid;
        private List<Cell> _squareCell;

        public BuildingMerge(CellGrid cellGrid)
        {
            _squareCell = new List<Cell>(4);
            _cellGrid = cellGrid;
        }

        public void TryMerge(List<Cell> cellsBeenPlacingOn)
        {
            foreach (var cell in cellsBeenPlacingOn)
            {
                _squareCell.Clear();
                if (_cellGrid.SquareCheck(cell, _squareCell, IsCellValid))
                {
                    SquareMerge(cell, _squareCell);
                    
                    break;
                }        
            }
        }

        private void SquareMerge(Cell cell, List<Cell> squareCell)
        {
            squareCell.Clear();
            while (_cellGrid.SquareCheck(cell, squareCell, IsCellValid))
            {
                cell = Merge(squareCell);
            }
        }

        private bool IsCellValid(Cell cell)
        {
            return cell.CanPaceBuilding && cell.HaveBuilding;
        }

        private Cell Merge(List<Cell> cellToMerge)
        {
            cellToMerge = cellToMerge.OrderBy(c => c.GridPosition.x)
                                     .ThenByDescending(c => c.GridPosition.z)
                                     .ToList();
            
            var cellMergeTo = cellToMerge.First();
            var mergeConfig = new BuildingConfig();
            mergeConfig.Add(cellMergeTo.Building.Config);
            
            for (int i = 1; i < cellToMerge.Count; i++)
            {
                var config = cellToMerge[i].DestroyBuilding();
                mergeConfig.Add(config);
            }
            
            cellMergeTo.Building.Merge(mergeConfig);
            return cellMergeTo;
        }
    }
}
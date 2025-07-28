using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using _Source.Scripts.Buildings;
using UnityEngine;

namespace _Source.Scripts.Grid
{
    public class CellGrid : MonoBehaviour
    {
        public const float CellSize = 1f;

        private Dictionary<Vector3Int, Cell> _cells;

        private void Awake()
        {
            var cells = GetComponentsInChildren<Cell>();
            _cells = cells.ToDictionary(c => c.GridPosition, c => c);
        }

        public bool HasCellAt(Vector3 position)
        {
            var gridPosition = position.ToGrid();
            return _cells.ContainsKey(gridPosition);
        }

        public void AddCell(Cell cell)
        {
            _cells.Add(cell.GridPosition, cell);
        }

        public bool TryGetCellAt(Vector3 position, out Cell cell)
        {
            if (HasCellAt(position))
            {
                cell = GetCellAt(position);
                return true;
            }

            cell = null;
            return false;
        }

        public Cell GetCellAt(Vector3 position)
        {
            var gridPosition = position.ToGrid();
            var cell = _cells[gridPosition];

            return cell;
        }

        public bool TryGetCellNeighbors(Vector3 position, List<Cell> cellNeighbors)
        {
            if (TryGetCellAt(position, out var cell))
            {
                return TryGetCellNeighbors(cell, cellNeighbors);
            }

            return false;
        }

        public bool TryGetCellNeighbors(Cell cell, List<Cell> cellNeighbors)
        {
            foreach (var offset in Helper.NeighborDirections)
            {
                if (TryGetCellAt(cell.GridPosition - offset, out var cellNeighbor))
                    cellNeighbors.Add(cellNeighbor);
            }

            return cellNeighbors.Count > 0;
        }

        public bool SquareCheck(Vector3 position, List<Cell> cells, Func<Cell, bool> isValid)
        {
            if (TryGetCellAt(position, out var cell))
            {
                return SquareCheck(cell, cells, isValid);
            }

            return false;
        }

        public bool SquareCheck(Cell cell, List<Cell> cells, Func<Cell, bool> isValid)
        {
            foreach (var boxCheck in Helper.BoxChecks)
            {
                cells.Clear();
                foreach (var offset in boxCheck)
                {
                    if (TryGetCellAt(cell.GridPosition - offset, out var cellNeighbor) && isValid(cellNeighbor))
                    {
                        cells.Add(cellNeighbor);
                        if (cells.Count == 4)
                        {
                            return true;
                        }
                    }
                }
            }
            
            return cells.Count == 4;
        }
    }
}

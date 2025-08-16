using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Source.Scripts.Grid
{
    public class CellGrid : MonoBehaviour
    {
        public const float CellSize = 1f;

        private Dictionary<Vector3Int, ICell> _cells;

        private void Awake()
        {
            var cells = GetComponentsInChildren<ICell>();
            _cells = cells.ToDictionary(c => c.GridPosition, c => c);
        }

        public bool HasCell<T>(Vector3 position) where T : ICell
        {
            var gridPosition = position.ToGrid();
            return _cells.ContainsKey(gridPosition) && _cells[gridPosition] is T;
        }

        public void AddCell(ICell cell)
        {
            _cells.Add(cell.GridPosition, cell);
        }

        public T[] GetAllCells<T>() where T : ICell
        {
            return _cells.Values.OfType<T>().ToArray();
        }

        public bool TryGetCell<T>(Vector3 position, out T cell)  where T : ICell
        {
            if (HasCell<T>(position))
            {
                cell = GetCell<T>(position);
                
                return true;
            }
            
            cell = default;
            return false;
        }

        public T GetCell<T>(Vector3 position) where T : ICell
        {
            var gridPosition = position.ToGrid();
            var cell = _cells[gridPosition];

            return (T)cell;
        }

        public bool TryGetCellNeighbors<T>(Vector3 position, List<T> cellNeighbors) where T : ICell
        {
            if (TryGetCell<T>(position, out var cell))
            {
                return TryGetCellNeighbors(cell, cellNeighbors);
            }

            return false;
        }

        public bool TryGetCellNeighbors<T>(ICell cell, List<T> cellNeighbors) where T : ICell
        {
            foreach (var offset in Helper.NeighborDirections)
            {
                if (TryGetCell<T>(cell.GridPosition - offset, out var cellNeighbor))
                    cellNeighbors.Add(cellNeighbor);
            }

            return cellNeighbors.Count > 0;
        }

        public bool SquareCheck<T>(Vector3 position, List<T> cells, Func<T, bool> isValid) where T : ICell
        {
            if (TryGetCell<T>(position, out var cell))
            {
                return SquareCheck(cell, cells, isValid);
            }

            return false;
        }

        public bool SquareCheck<T>(ICell cell, List<T> cells, Func<T, bool> isValid) where T : ICell
        {
            foreach (var boxCheck in Helper.BoxChecks)
            {
                cells.Clear();
                foreach (var offset in boxCheck)
                {
                    var neigbourPos = cell.GridPosition + offset;
                    if (TryGetCell<T>(neigbourPos, out var cellNeighbor) && isValid(cellNeighbor))
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

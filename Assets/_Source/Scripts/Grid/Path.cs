using _Source.Scripts.Grid;
using UnityEngine;

namespace _Source.Scripts.Grid
{
    public class Path :  MonoBehaviour, ICell
    {
        [field: SerializeField] public Transform[] PossiblePaths { get; private set; }
        public Vector3Int GridPosition => transform.position.ToGrid();
    }
}
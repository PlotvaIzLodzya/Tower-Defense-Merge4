using _Source.Scripts.Grid;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class Path :  MonoBehaviour, ICell
    {
        public Vector3Int GridPosition => transform.position.ToGrid();
    }
}
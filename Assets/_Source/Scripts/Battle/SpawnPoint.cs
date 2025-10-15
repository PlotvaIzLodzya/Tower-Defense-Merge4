using _Source.Scripts.Grid;
using UnityEngine;

namespace _Source.Scripts.Battle
{
    public class SpawnPoint : MonoBehaviour, ICell
    {
        public Vector3Int GridPosition => transform.position.ToGrid();
    }
}
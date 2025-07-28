using _Source.Scripts.Buildings;
using UnityEngine;

namespace _Source.Scripts.Grid
{
	public interface ICell
	{
		public Vector3Int GridPosition { get; }
    }
}
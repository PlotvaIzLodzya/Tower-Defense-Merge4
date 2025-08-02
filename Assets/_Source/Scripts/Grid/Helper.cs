using _Source.Scripts.Grid;
using UnityEngine;


public static class Helper
{
    public static readonly Vector3Int[] NeighborDirections = new Vector3Int[]
    {
        new Vector3Int(-1, 0, 1),
        new Vector3Int( 0, 0, 1),
        new Vector3Int( 1, 0, 1),
        new Vector3Int(-1, 0, 0),
        new Vector3Int( 0, 0, 0),
        new Vector3Int( 1, 0, 0),
        new Vector3Int(-1, 0,-1),
        new Vector3Int( 0, 0,-1),
        new Vector3Int( 1, 0,-1),
    };

    public static readonly Vector3Int[] LeftUpSquare = new Vector3Int[]
    {
        new Vector3Int(-1, 0, 1),
        new Vector3Int( 0, 0, 1),
        new Vector3Int(-1, 0, 0),
        new Vector3Int( 0, 0, 0),
    };
    
    public static readonly Vector3Int[] RightUpSquare = new Vector3Int[]
    {
        new Vector3Int( 1, 0, 1),
        new Vector3Int( 0, 0, 1),
        new Vector3Int( 1, 0, 0),
        new Vector3Int( 0, 0, 0),
    };
    
    public static readonly Vector3Int[] LeftDownSquare = new Vector3Int[]
    {
        new Vector3Int(-1, 0,-1),
        new Vector3Int( 0, 0,-1),
        new Vector3Int(-1, 0, 0),
        new Vector3Int( 0, 0, 0),
    };
    
    public static readonly Vector3Int[] RightDownSquare = new Vector3Int[]
    {
        new Vector3Int( 1, 0,-1),
        new Vector3Int( 0, 0,-1),
        new Vector3Int( 1, 0, 0),
        new Vector3Int( 0, 0, 0),
    };
    
    public static readonly Vector3Int[][] BoxChecks = new Vector3Int[][]
    {
        LeftUpSquare,
        RightUpSquare,
        LeftDownSquare,
        RightDownSquare,
    };

    public static Vector3Int ToGrid(this Vector3 position, float cellSize = CellGrid.CellSize)
    {
        int x = Mathf.RoundToInt(position.x / cellSize);
        int y = Mathf.RoundToInt(position.y / cellSize);
        int z = Mathf.RoundToInt(position.z / cellSize);

        return new Vector3Int(x, y, z);
    }

    public static Vector3 ToWorld(this Vector3Int position, float cellSize = CellGrid.CellSize)
    {
        float x = position.x * cellSize;
        float y = position.y * cellSize;
        float z = position.z * cellSize;

        return new Vector3(x, y, z);
    }

    public static void ThrowIfNull<T>(this T obj) where T : class
    {
        if (obj == null)
        {
            throw new System.Exception($"{typeof(T).Name} is not set");
        }
    }
}
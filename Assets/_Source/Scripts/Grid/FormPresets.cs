using System.Collections.Generic;
using _Source.Scripts.Buildings;
using UnityEngine;

public static class FormPresets
{
    public static readonly Vector3Int[] Single = 
    {
        new (0, 0, 0),
    };

    public static readonly Vector3Int[] DoubleVert =
    {
        new ( 0, 0, 0),
        new ( 0, 0, 1),
    };
    
    public static readonly Vector3Int[] DoubleHor =
    {
        new ( 0, 0, 0),
        new ( 1, 0, 0),
    };
    
    public static readonly Vector3Int[] LineVert = 
    {
        new ( 0, 0, 1),
        new ( 0, 0, 0),
        new ( 0, 0,-1),
    };
    
    public static readonly Vector3Int[] LineHor = 
    {
        new ( 1, 0, 0),
        new ( 0, 0, 0),
        new (-1, 0, 0),
    };
    
    public static readonly Vector3Int[] SquiggleVert = 
    {
        new (-1, 0, 1),
        new (-1, 0, 0),
        new ( 0, 0, 0),
        new ( 0, 0,-1),
    };
    
    public static readonly Vector3Int[] SquiggleHor = 
    {
        new ( 1, 0, 1),
        new ( 0, 0, 1),
        new ( 0, 0, 0),
        new (-1, 0, 0),
    };

    public static readonly Vector3Int[][] Presets =
    {
        Single,
        DoubleVert,
        DoubleHor,
        LineVert,
        LineHor,
        SquiggleVert,
        SquiggleHor,
    };

    public static TowerBlueprint[] GenerateTowerBlueprints(int levelRangeExclusive = 2)
    {
        var towersBlueprints = new List<TowerBlueprint>();
        var index = Random.Range(0, Presets.Length);
        var preset = Presets[index];
        
        foreach (var offset in preset)
        {
            var level = Random.Range(1, levelRangeExclusive);
            towersBlueprints.Add(new TowerBlueprint()
            {
                Offset = offset,
                Stats = new()
                {
                    Level = level
                }
            });
        }
        return towersBlueprints.ToArray();
    }
}
using System;
using UnityEditor;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    [Serializable]
    public class BuildingBlockPiece
    {
        public Vector3Int Offset;
        public Building Building;
    }

    [Serializable]
    public class BuildingBlueprint
    {
        public Vector3Int Offset;
        public BuildingStats Stats;
    }

    public class BuildingBlockBlueprint
    {
        public BuildingBlueprint[] BuildingBlueprints;
    }
    
    public class BuildingBlock : MonoBehaviour
    {
        public BuildingBlockPiece[] Form;

        [ContextMenu("Setup form")]
        public void UpdateForm()
        {
            var buildings = GetComponentsInChildren<Building>();
            Form = new BuildingBlockPiece[buildings.Length];
            for (int i = 0; i < buildings.Length; i++)
            {
                var building = buildings[i];
                Form[i] = new BuildingBlockPiece()
                {
                    Building = building,
                    Offset = building.transform.localPosition.ToGrid(),
                };
            }
#if UNITY_EDITOR
            EditorUtility.SetDirty(gameObject);
#endif
        }
    }
}
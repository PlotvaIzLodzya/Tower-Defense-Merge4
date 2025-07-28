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
    
    public class BuildingBlock : MonoBehaviour
    {
        public Building[] Buildings;

        public BuildingBlockPiece[] Form;
        public Vector3Int GridPosition => Buildings[0].GridPosition;

        [ContextMenu("Setup form")]
        public void UpdateForm()
        {
            Buildings = GetComponentsInChildren<Building>();
            Form = new BuildingBlockPiece[Buildings.Length];
            for (int i = 0; i < Buildings.Length; i++)
            {
                var building = Buildings[i];
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
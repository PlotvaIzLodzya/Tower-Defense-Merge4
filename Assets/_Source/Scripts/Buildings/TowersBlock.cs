using System;
using UnityEditor;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    [Serializable]
    public class TowerBlockPiece
    {
        public Vector3Int Offset;
        public Tower Tower;
    }

    [Serializable]
    public class TowerBlueprint
    {
        public Vector3Int Offset;
        public TowerStats Stats;
    }

    public class TowersBlockBlueprint
    {
        public TowerBlueprint[] BuildingBlueprints;
    }
    
    public class TowersBlock : MonoBehaviour
    {
        public TowerBlockPiece[] Form;

        [ContextMenu("Setup form")]
        public void UpdateForm()
        {
            var towers = GetComponentsInChildren<Tower>();
            Form = new TowerBlockPiece[towers.Length];
            for (int i = 0; i < towers.Length; i++)
            {
                var tower = towers[i];
                Form[i] = new TowerBlockPiece()
                {
                    Tower = tower,
                    Offset = tower.transform.localPosition.ToGrid(),
                };
            }
#if UNITY_EDITOR
            EditorUtility.SetDirty(gameObject);
#endif
        }
    }
}
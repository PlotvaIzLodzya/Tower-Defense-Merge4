using System;
using System.Collections;
using System.Collections.Generic;
using _Source.Scripts.Grid;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class BuildingCell : MonoBehaviour, ICell
    {
        public Tower Tower { get; private set; }
        public Vector3Int GridPosition => transform.position.ToGrid();
        public bool HaveBuilding => Tower != null;
        public bool IsInMerge { get; private set; }

        public void SetBuilding(Tower tower)
        {
            Tower = tower;
        }
        
        public void MarkToMerge(bool value)
        {
            IsInMerge = value;
        }
        
        public void DestroyBuilding()
        {
            Tower.Destroy();
            Tower = null;
        }
    }
}
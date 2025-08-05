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
        public bool WillBeMerged { get; private set; }

        public void SetBuilding(Tower tower)
        {
            Tower = tower;
        }

        private void Update()
        {
            if(WillBeMerged)
                Debug.Log(transform.name );
        }

        public void SetWillBeMerged(bool value)
        {
            WillBeMerged = value;
        }
        
        public TowerStats DestroyBuilding()
        {
            var config = Tower.Stats;
            Tower.Destroy();
            Tower = null;
            
            return config;
        }

        public void MergeTo(Tower tower)
        {
            StartCoroutine(MergingTo(tower));
        }

        private IEnumerator MergingTo(Tower tower)
        {
            yield return Tower.MergingEffect(tower);
            
            DestroyBuilding();
        }
    }
}
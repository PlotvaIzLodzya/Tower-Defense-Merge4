using System;
using System.Collections.Generic;
using System.Linq;
using _Source.Scripts.Buildings;
using UnityEngine;

namespace _Source.Scripts.UI
{
    public class BuildingBlockPreview : Panel
    {
        [SerializeField] private TowerPreview[] _towerPreviews;
        
        private int _gridSize;

        private void Awake()
        {
            foreach (var towerPreview in _towerPreviews)
            {
                towerPreview.Hide();
            }

            _gridSize = 3;
        }

        public void Consruct(BuildingBlockBlueprint blueprint)
        {
            var centerIndex = _towerPreviews.Length / 2;
            var centerGridPos = GetByIndex(centerIndex, _gridSize);
            for (int i = 0; i < _towerPreviews.Length; i++)
            {
                var gridPos = GetByIndex(i, _gridSize);
                var offset = gridPos - centerGridPos;
                
                var towerBlueprint = blueprint.BuildingBlueprints.FirstOrDefault(b => b.Offset == offset);
                if (towerBlueprint != null)
                {
                    _towerPreviews[i].UpdateView(towerBlueprint.Stats);
                    _towerPreviews[i].Show();
                }
                else
                {
                    _towerPreviews[i].Hide();
                }
            }
        }

        private Vector3Int GetByIndex(int index, int gridSize)
        {
            var x = index % gridSize;
            var z = index / gridSize;
            var gridPos = new Vector3Int(x, 0, z);
            return gridPos;
        }
    }
}

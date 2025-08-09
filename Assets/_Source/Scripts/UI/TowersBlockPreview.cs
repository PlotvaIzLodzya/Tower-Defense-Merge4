using System;
using System.Linq;
using _Source.Scripts.Buildings;
using _Source.Scripts.ReferencesAndSources;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Source.Scripts.UI
{
    public class TowersBlockPreview : Panel, IPointerDownHandler
    {
        [SerializeField] private TowerPlacementBufferReference _towerPlacementBufferReference;
        [SerializeField] private TowerPreview[] _towerPreviews;
        
        private int _gridSize;
        private TowerPlacementBuffer  _placementBuffer;
        private TowerBlockPreset _preset;

        public void Awake()
        {
            _placementBuffer = _towerPlacementBufferReference.Value;
            _gridSize = 3;
            foreach (var towerPreview in _towerPreviews)
            {
                towerPreview.Hide();
            }
        }

        public void Construct(TowerBlockPreset preset)
        {
            _preset = preset;
            var centerIndex = _towerPreviews.Length / 2;
            var centerGridPos = GetByIndex(centerIndex, _gridSize);
            for (int i = 0; i < _towerPreviews.Length; i++)
            {
                var gridPos = GetByIndex(i, _gridSize);
                var offset = gridPos - centerGridPos;
                
                var towerBlueprint = preset.Blueprints.FirstOrDefault(b => b.Offset == offset);
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
        public void OnPointerDown(PointerEventData eventData)
        {
            OnGetBlueprintButtonClick();
        }

        private void OnGetBlueprintButtonClick()
        {
            _placementBuffer.Add(_preset);
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

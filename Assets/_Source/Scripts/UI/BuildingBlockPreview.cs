using System;
using System.Linq;
using _Source.Scripts.Buildings;
using _Source.Scripts.ReferencesAndSources;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.Scripts.UI
{
    public class BuildingBlockPreview : Panel
    {
        [SerializeField] private BuildingPlacement _buildingPlacementReference;
        [SerializeField] private TowerPreview[] _towerPreviews;
        [SerializeField] private Button _getBlueprintButton;
        
        private int _gridSize;
        [SerializeField] private BuildingPlacement  _buildingPlacement;
        private BuildingBlockBlueprint _blueprint;

        private void Awake()
        {
            _getBlueprintButton.onClick.AddListener(OnGetBlueprintButtonClick);
            foreach (var towerPreview in _towerPreviews)
            {
                towerPreview.Hide();
            }

            _gridSize = 3;
        }

        private void Start()
        {
            // _buildingPlacement = _buildingPlacementReference.Value;
        }

        private void OnDestroy()
        {
            _getBlueprintButton.onClick.RemoveListener(OnGetBlueprintButtonClick);
        }

        public void Construct(BuildingBlockBlueprint blueprint)
        {
            _blueprint = blueprint;
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

        private void OnGetBlueprintButtonClick()
        {
            Debug.Log("GetBlueprintButtonClick");
            _buildingPlacement.CreateBuilding(_blueprint);
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

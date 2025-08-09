using System;
using _Source.Scripts.Buildings;
using _Source.Scripts.ReferencesAndSources;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Source.Scripts.UI
{
    public class TowerPlacementBuffer : MonoBehaviour, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField] private TowerPlacementReference _towerPlacementReference;
        
        private TowerPlacement _towerPlacement;
        private TowerBlockPreset _prefab;

        private void Awake()
        {
            _towerPlacement = _towerPlacementReference.Value;
        }

        public void Add(TowerBlockPreset presetPrefab)
        {
            _prefab = presetPrefab;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if(Input.GetMouseButton(0) && _prefab != null)
                _towerPlacement.SetPresetPrefab(_prefab);
            
            _prefab = null;
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            _prefab = null;
            _towerPlacement.DeleteCurrent();
        }
    }
}
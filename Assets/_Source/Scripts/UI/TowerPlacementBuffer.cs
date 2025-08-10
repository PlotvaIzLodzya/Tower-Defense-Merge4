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
        private BlockPlacementDto _placementDto;

        private void Awake()
        {
            _towerPlacement = _towerPlacementReference.Value;
        }

        public void Add(BlockPlacementDto placementDto)
        {
            _placementDto = placementDto;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if(Input.GetMouseButton(0) && _placementDto != null)
                _towerPlacement.SetPresetPrefab(_placementDto);
            
            _placementDto = null;
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            _placementDto = null;
            _towerPlacement.DeleteCurrent();
        }
    }
}
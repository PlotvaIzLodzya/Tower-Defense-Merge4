using _Source.Scripts.Controls;
using _Source.Scripts.ReferencesAndSources;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class TowerPlacementPreview : MonoBehaviour
    {
        [SerializeField] private InputReference _inputReference;
        
        private Camera _camera;
        private TowerBlockPreset _towerBlockPreset;
        private TowerBlockPreset _towerPreview;
        
        private IInput _input;

        private void Start()
        {
            _camera = Camera.main;
            _input = _inputReference.Value;
        }

        private void Update()
        {
            var woldPos = _camera.ScreenToWorldPoint(_input.PointerPosition);
            woldPos.y = 1;
            transform.position = woldPos;
        }
        
        public void SetTowerBlockPreset(TowerBlockPreset towerBlockPreset)
        {
            _towerBlockPreset = towerBlockPreset;
            _towerPreview = Instantiate(_towerBlockPreset, transform);
            _towerPreview.UpdateTowersView();
            _towerPreview.transform.localPosition = Vector3.zero;
        }

        public void DeletePreview()
        {
            if(_towerPreview != null)
                Destroy(_towerPreview.gameObject);
        }
    }
}
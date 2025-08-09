using _Source.Scripts.UI;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class TowerPlacementPreview : MonoBehaviour
    {
        private TowerBlockPreset _towerBlockPreset;
        private TowerBlockPreset _towerPreview;
        
        private void Update()
        {
            var woldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            woldPos.y = 1;
            transform.position = woldPos;
        }
        
        public void SetTowerBlockPreset(TowerBlockPreset towerBlockPreset)
        {
            _towerBlockPreset = towerBlockPreset;
            _towerPreview = Instantiate(_towerBlockPreset, transform);
        }

        public void DeletePreview()
        {
            Destroy(_towerPreview.gameObject);
        }
    }
}
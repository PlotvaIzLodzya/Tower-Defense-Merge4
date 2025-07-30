using UnityEngine;
using UnityEngine.UI;

namespace _Source.Scripts.UI
{
    public class BuildingBlockShop : Panel
    {
        [SerializeField] BuildingBlockPreview[] _previews;
        [SerializeField] Button _refreshButton;
        private void Awake()
        {
            _refreshButton.onClick.AddListener(Generate);
        }

        private void Start()
        {
            Generate();
        }

        private void OnDestroy()
        {
            _refreshButton.onClick.RemoveAllListeners();
        }

        public void Generate()
        {
            foreach (var b in _previews)
            {
                var blueprint = FormPresets.GenerateBuildingBlockBlueprint(4);
                b.Consruct(blueprint);
            }
        }
    }
}
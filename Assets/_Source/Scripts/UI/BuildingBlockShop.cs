using _Source.Scripts.Buildings;
using _Source.Scripts.ReferencesAndSources;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.Scripts.UI
{
    public class BuildingBlockShop : Panel
    {
        [SerializeField] private BuildingPresets _presets;
        [SerializeField] private BuildingBlockPreview[] _previews;
        [SerializeField] private Button _refreshButton;
        
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
                var blueprint = _presets.GetRandomBlueprint(4);
                b.Construct(blueprint);
            }
        }
    }
}
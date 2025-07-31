using _Source.Scripts.Buildings;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.Scripts.UI
{
    public class BuildingBlockShop : Panel
    {
        [SerializeField] private LevelConfigProvider _levelConfigProvider;
        [SerializeField] private BuildingBlockPreview[] _previews;
        [SerializeField] private Button _refreshButton;
        
        private LevelConfig _levelConfig;
        private void Awake()
        {
            _refreshButton.onClick.AddListener(Generate);
        }

        private void Start()
        {
            _levelConfig = _levelConfigProvider.LevelConfig;
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
                var blueprint = _levelConfig.Presets.GetRandomBlueprint(4);
                b.Construct(blueprint);
            }
        }
    }
}
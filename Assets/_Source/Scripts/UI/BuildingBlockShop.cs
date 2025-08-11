using System;
using _Source.Scripts.Buildings;
using _Source.Scripts.ReferencesAndSources;
using _Source.Scripts.Trade;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.Scripts.UI
{
    public class BuildingBlockShop : Panel
    {
        [SerializeField] private LevelConfigProvider _levelConfigProvider;
        [SerializeField] private TowersBlockPreview[] _previews;
        [SerializeField] private Button _refreshButton;
        [SerializeField] private PriceView _refreshPriceView;
        [SerializeField] private WalletReference  _walletReference;
        
        private LevelConfig _levelConfig;
        private Wallet _wallet;
        
        private void Awake()
        {
            _wallet = _walletReference.Value;
            _refreshPriceView.SetPrice(GameConfig.RefreshPrice);
            _refreshButton.onClick.AddListener(Refresh);
        }

        private void Start()
        {
            _levelConfig = _levelConfigProvider.LevelConfig;
            Generate(true);
        }

        private void OnDestroy()
        {
            _refreshButton.onClick.RemoveAllListeners();
        }

        public void Refresh()
        {
            Generate(false);
        }

        public void Generate(bool free)
        {
            if (free || _wallet.TrySpend(GameConfig.RefreshPrice))
            {
                foreach (var preview in _previews)
                {
                    var blueprint = _levelConfig.Presets.GetRandomPreset(4);
                    preview.Construct(blueprint);
                }
            }
            
        }
    }
}
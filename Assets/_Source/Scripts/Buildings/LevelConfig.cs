using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class GameConfig
    {
        public const int WalletMaxAmount = 999;
        public const int PricePerTowerLvl = 10;
        public const int StartMoney = 100;
        public const int RefreshPrice = 10;
    }
    
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Levels/LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        public BuildingPresets Presets;
        public Tower TowerPrefab;

        private void OnValidate()
        {
            Presets.ThrowIfNull();
            TowerPrefab.ThrowIfNull();
        }
    }
}
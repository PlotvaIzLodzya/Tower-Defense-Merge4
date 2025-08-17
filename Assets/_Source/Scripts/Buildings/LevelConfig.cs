using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public static class NamingConstant
    {
        public const string AttackBehaviours = "AttackBehaviours";
    }

    public class GameConfig
    {
        public const int GateHealth = 100;
        public const int WalletMaxAmount = 999;
        public const int PricePerTowerLvl = 10;
        public const int StartMoney = 1000;
        public const int RefreshPrice = 10;


        public const int MaxAttackSpeed = 700;
        public const float MaxAttackDelay = 1f;
        public const float MinAttackDelay = 0.2f;
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
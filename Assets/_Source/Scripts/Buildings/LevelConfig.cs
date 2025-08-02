using UnityEngine;

namespace _Source.Scripts.Buildings
{
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
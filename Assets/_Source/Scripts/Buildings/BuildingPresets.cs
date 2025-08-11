using UnityEngine;

namespace _Source.Scripts.Buildings
{
    [CreateAssetMenu(fileName = "BuildingPresets", menuName = "TowerPlacement/BuildingPresets")]
    public class BuildingPresets : ScriptableObject
    {
        [SerializeField] private TowerBlockPreset[] _presets;

        public TowerBlockPreset GetRandomPreset(int levelRangeExclusive = 2)
        {
            var index = Random.Range(0, _presets.Length);
            var preset = _presets[index];
            
            var level = Random.Range(1, levelRangeExclusive);
            foreach (var blueprint  in preset.Blueprints)
            {
                blueprint.Stats = new TowerStats()
                {
                    Level = level,
                };
            }
            
            return preset;
        }
    }
}
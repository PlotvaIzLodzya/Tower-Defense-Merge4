using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    [CreateAssetMenu(fileName = "BuildingPresets", menuName = "TowerPlacement/BuildingPresets")]
    public class BuildingPresets : ScriptableObject
    {
        [SerializeField] private TowerBlockPreset[] _presets;

        public TowerBlockPreset GetRandom()
        {
            var index = Random.Range(0, _presets.Length);
            return _presets[index];
        }

        public TowersBlockBlueprint GetRandomBlueprint(int levelRangeExclusive =2)
        {
            var buildingBlueprint = new List<TowerBlueprint>();
            var index = Random.Range(0, _presets.Length);
            var preset = _presets[index];
        
            foreach (var piece in preset.Blueprints)
            {
                var level = Random.Range(1, levelRangeExclusive);
                buildingBlueprint.Add(new TowerBlueprint()
                {
                    Offset = piece.Offset,
                    Stats = new()
                    {
                        Level = level
                    }
                });
            }

            var buildingBlockBlueprint = new TowersBlockBlueprint()
            {
                TowersBlueprints = buildingBlueprint.ToArray(),
            };
            return buildingBlockBlueprint;
        }
        
        public bool TryGetPreset(TowersBlockBlueprint blueprint, out TowerBlockPreset blockPreset)
        {
            for (int i = 0; i < _presets.Length; i++)
            {
                if (IsValid(_presets[i].Blueprints, blueprint.TowersBlueprints))
                {
                    blockPreset = _presets[i];
                    return true;
                }
            }
            
            blockPreset = null;
            return false;
        }

        private bool IsValid(TowerBlueprint[] blueprint, TowerBlueprint[] buildingBlueprints)
        {
            if (blueprint.Length != buildingBlueprints.Length)
                return false;
            
            for (int i = 0; i < buildingBlueprints.Length; i++)
            {
                if(blueprint[i].Offset != buildingBlueprints[i].Offset)
                    return false;
            }

            return true;
        }
    }
}
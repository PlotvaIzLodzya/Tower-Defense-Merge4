using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    [CreateAssetMenu(fileName = "BuildingPresets", menuName = "BuildingPlacement/BuildingPresets")]
    public class BuildingPresets : ScriptableObject
    {
        [SerializeField] private BuildingBlock[] _presets;

        public BuildingBlock GetRandom()
        {
            var index = Random.Range(0, _presets.Length);
            return _presets[index];
        }

        public BuildingBlockBlueprint GetRandomBlueprint(int levelRangeExclusive =2)
        {
            var buildingBlueprint = new List<BuildingBlueprint>();
            var index = Random.Range(0, _presets.Length);
            var preset = _presets[index];
        
            foreach (var piece in preset.Form)
            {
                var level = Random.Range(1, levelRangeExclusive);
                buildingBlueprint.Add(new BuildingBlueprint()
                {
                    Offset = piece.Offset,
                    Stats = new()
                    {
                        Level = level
                    }
                });
            }

            var buildingBlockBlueprint = new BuildingBlockBlueprint()
            {
                BuildingBlueprints = buildingBlueprint.ToArray(),
            };
            return buildingBlockBlueprint;
        }
        
        public bool TryGetPreset(BuildingBlockBlueprint blueprint, out BuildingBlock preset)
        {
            for (int i = 0; i < _presets.Length; i++)
            {
                if (IsValid(_presets[i].Form, blueprint.BuildingBlueprints))
                {
                    preset = _presets[i];
                    return true;
                }
            }
            
            preset = null;
            return false;
        }

        private bool IsValid(BuildingBlockPiece[] form, BuildingBlueprint[] buildingBlueprints)
        {
            if (form.Length != buildingBlueprints.Length)
                return false;
            
            for (int i = 0; i < buildingBlueprints.Length; i++)
            {
                if(form[i].Offset != buildingBlueprints[i].Offset)
                    return false;
            }

            return true;
        }
    }
}
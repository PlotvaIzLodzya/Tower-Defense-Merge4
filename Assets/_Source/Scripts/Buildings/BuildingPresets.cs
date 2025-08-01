using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    [CreateAssetMenu(fileName = "BuildingPresets", menuName = "TowerPlacement/BuildingPresets")]
    public class BuildingPresets : ScriptableObject
    {
        [SerializeField] private TowersBlock[] _presets;

        public TowersBlock GetRandom()
        {
            var index = Random.Range(0, _presets.Length);
            return _presets[index];
        }

        public TowersBlockBlueprint GetRandomBlueprint(int levelRangeExclusive =2)
        {
            var buildingBlueprint = new List<TowerBlueprint>();
            var index = Random.Range(0, _presets.Length);
            var preset = _presets[index];
        
            foreach (var piece in preset.Form)
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
                BuildingBlueprints = buildingBlueprint.ToArray(),
            };
            return buildingBlockBlueprint;
        }
        
        public bool TryGetPreset(TowersBlockBlueprint blueprint, out TowersBlock preset)
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

        private bool IsValid(TowerBlockPiece[] form, TowerBlueprint[] buildingBlueprints)
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
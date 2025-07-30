using _Source.Scripts.Buildings;
using BananaParty.Arch;
using UnityEngine;

namespace _Source.Scripts.ReferencesAndSources
{
    [CreateAssetMenu(menuName = "References/" + nameof(BuildingPlacementReference), fileName = nameof(BuildingPlacementReference))]
    public class BuildingPlacementReference : ReferenceAsset<BuildingPlacement>
    {
        
    }
}
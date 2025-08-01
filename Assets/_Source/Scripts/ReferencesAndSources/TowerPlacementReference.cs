using _Source.Scripts.Buildings;
using BananaParty.Arch;
using UnityEngine;

namespace _Source.Scripts.ReferencesAndSources
{
    [CreateAssetMenu(menuName = "References/" + nameof(TowerPlacementReference), fileName = nameof(TowerPlacementReference))]
    public class TowerPlacementReference : ReferenceAsset<TowerPlacement>
    {
        
    }
}
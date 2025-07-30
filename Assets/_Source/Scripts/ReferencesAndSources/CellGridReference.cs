using _Source.Scripts.Grid;
using BananaParty.Arch;
using UnityEngine;

namespace _Source.Scripts.ReferencesAndSources
{
    [CreateAssetMenu(menuName = "References/" + nameof(CellGridReference), fileName = nameof(CellGridReference))]
    public class CellGridReference : ReferenceAsset<CellGrid>
    {
        
    }
}
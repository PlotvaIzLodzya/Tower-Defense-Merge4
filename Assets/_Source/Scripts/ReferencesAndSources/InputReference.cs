using _Source.Scripts.Controls;
using BananaParty.Arch;
using UnityEngine;

namespace _Source.Scripts.ReferencesAndSources
{
    [CreateAssetMenu(menuName = "References/" + nameof(InputReference), fileName = nameof(InputReference))]
    public class InputReference : ReferenceAsset<IInput>
    {
        
    }
}
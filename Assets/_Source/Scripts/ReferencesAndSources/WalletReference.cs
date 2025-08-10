using _Source.Scripts.Trade;
using BananaParty.Arch;
using UnityEngine;

namespace _Source.Scripts.ReferencesAndSources
{
    [CreateAssetMenu(menuName = "References/" + nameof(WalletReference), fileName = nameof(WalletReference))]
    public class WalletReference : ReferenceAsset<Wallet>
    {
        
    }
}
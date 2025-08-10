using _Source.Scripts.Trade;
using TMPro;
using UnityEngine;

namespace _Source.Scripts.UI
{
    public class WalletView : Panel
    {
        [SerializeField] private Wallet _wallet;
        [SerializeField] private TMP_Text _amount;

        private void Update()
        {
            _amount.text = $"{_wallet.Amount}";
        }
    }
}
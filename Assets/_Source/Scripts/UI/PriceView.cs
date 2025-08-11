using System;
using _Source.Scripts.ReferencesAndSources;
using TMPro;
using UnityEngine;

namespace _Source.Scripts.UI
{
    public class PriceView : Panel
    {
        [SerializeField] private TMP_Text _price;
        [SerializeField] private WalletReference _wallet;
        
        private int _currentPrice;
        
        public void SetPrice(int price)
        {
            _currentPrice = price;
            _price.text = $"{price}";
        }

        private void Update()
        {
            UpdateView(_wallet.Value.Have(_currentPrice));
        }

        public void UpdateView(bool enoughMoney)
        {
            _price.color = enoughMoney ? Color.white : Color.red;
        }
    }
}
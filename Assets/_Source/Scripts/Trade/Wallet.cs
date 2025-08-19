using System;
using _Source.Scripts.Buildings;
using _Source.Scripts.Helpers;
using UnityEngine;

namespace _Source.Scripts.Trade
{
    public class Wallet : MonoBehaviour
    {
        public int Amount { get; private set; }
        public int MaxAmount { get; private set; }

        private void Awake()
        {
            MaxAmount = GameConfig.WalletMaxAmount;
        }

        public void Add(int value)
        {
            ChangeAmount(value);
        }

        public bool Have(int value)
        {
            return Amount >= value;
        }

        public bool TrySpend(int amount)
        {
            if (Have(amount))
            {
                Spend(amount);
                return true;
            }
            
            return false;
        }

        public void Spend(int value)
        {
            ChangeAmount(-value);
        }

        private void ChangeAmount(int value)
        {
            Amount += value;
            Amount = Mathf.Clamp(Amount, 0, MaxAmount);
        }
    }
}

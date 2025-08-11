using System;
using _Source.Scripts.Buildings;
using _Source.Scripts.Trade;
using UnityEngine;

namespace _Source.Scripts.GameFeatures
{
    public class LevelStart : MonoBehaviour
    {
        [SerializeField] private Wallet _wallet;

        private void Start()
        {
            _wallet.Add(GameConfig.StartMoney);
        }
    }
}

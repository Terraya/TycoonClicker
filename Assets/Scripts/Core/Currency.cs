using System;
using UnityEngine;

namespace TDSStudio.Core
{
    [Serializable]
    public class Currency
    {
        [Header("Currency Settings")]
        [SerializeField] private CurrencyType currencyType;
        public CurrencyType CurrencyType => currencyType;
        [SerializeField] private double currencyAmount;
        public double CurrencyAmount => currencyAmount;

        public void IncreaseCurrencyAmount(double amount) => currencyAmount += amount;
        public void DecreaseCurrencyAmount(double amount) => currencyAmount -= amount;
    }
}

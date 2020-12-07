using UnityEngine;
using System;

namespace TDSStudio.Core
{
    [Serializable]
    public class CurrencyMultiplicator
    {
        [Header("CurrencyMultiplicator Settings")]
        [SerializeField] private CurrencyType currencyType;
        public CurrencyType CurrencyType => currencyType;
        [SerializeField] private float multiplicator = 1f;
        public float Multiplicator => multiplicator;

        public void IncrementMultiplicator(float addition) => multiplicator += addition;
    }
}
using UnityEngine;
using TDSStudio.Core;
using System;

namespace TDSStudio.Control
{
    [Serializable]
    public abstract class BaseGenerator : MonoBehaviour
    {
        [Header("Generator Statistics")]
        [SerializeField] private CurrencyType currencyIncomeType;
        public CurrencyType CurrencyIncomeType => currencyIncomeType;
        [SerializeField] private string generatorName;
        public string GeneratorName => generatorName;
        [SerializeField] private double income;
        public double Income => income;
        [SerializeField] private int level;
        public int Level => level;

        [Header("Purchase Settings")]
        [SerializeField] private CurrencyType currencyCostType;
        public CurrencyType CurrencyCostType => currencyCostType;
        [SerializeField] private double initialCost;
        public double InitialCost => initialCost;

        [Header("Generator Settings")]
        [SerializeField] private float timer;
        public float Timer => timer;
        private float runningTimer;
        public float RunningTimer => runningTimer;

        [Header("Dependencys")]
        [SerializeField] private CurrencyManager currencyManager;
        public CurrencyManager CurrencyManager => currencyManager;

        public abstract double ReturnGeneratedCurrency();
        public abstract void PurchaseGenerator();
        public abstract void UpgradeGenerator();

        private void Start() => runningTimer = timer;
        public void IncreaseLevel() => level++;
        public void SetRunningTimer(float value) => runningTimer = value;
        public double ReturnUpgradeCost() => level * initialCost;
    }
}
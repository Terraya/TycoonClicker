using TDSStudio.Core;
using UnityEngine;

namespace TDSStudio.Control
{
    public abstract class BaseManager : MonoBehaviour
    {
        [Header("Manager Statistics")]
        [SerializeField] private string managerName;
        public string ManagerName => managerName;
        [SerializeField] private int level;
        public int Level => level;
        [SerializeField] private int maxLevel;
        public int MaxLevel => maxLevel;

        [Header("Manager Multiplicator Settings")]
        [SerializeField] private CurrencyType managerMultiplierType;
        public CurrencyType ManagerMultiplierType => managerMultiplierType;
        [SerializeField] private float currencyMultiplier;
        public float CurrencyMultiplier => currencyMultiplier;

        [Header("Purchase Settings")]
        [SerializeField] private CurrencyType managerCostType;
        public CurrencyType ManagerCostType => managerCostType;
        [SerializeField] private double initialCost;
        public double InitialCost => initialCost;

        [Header("Dependencys")]
        [SerializeField] private CurrencyManager currencyManager;
        public CurrencyManager CurrencyManager => currencyManager;

        public abstract void PurchaseManager();
        public abstract void UpgradeManager();
        public abstract float ReturnCalculatedCurrencyMultiplier();

        public void IncreaseLevel() => level++;
        public double ReturnUpgradeCost() => level * initialCost;
    }
}
using TDSStudio.Control;
using UnityEngine;
using UnityEngine.UI;

namespace TDSStudio.UI
{
    public abstract class BaseManagerUIHandler : MonoBehaviour
    {
        [Header("General Text")]
        public Text NameText;
        public Text BtnText;
        public Text LevelText;
        public Text CostText;
        public Text MultiplierValueText;

        [Header("Slider")]
        public Slider Slider;

        private BaseManager baseManager;
        public BaseManager BaseManager => baseManager;

        private void Awake() => SetBaseManager(GetComponent<BaseManager>());

        private void Start()
        {
            UpdateUI();
            NameText.text = baseManager.ManagerName;
        }

        public void SetBaseManager(BaseManager newManager) => baseManager = newManager;

        public void BuyGeneratorBtnHandler()
        {
            if (baseManager.Level >= baseManager.MaxLevel) return;
            else if (baseManager.Level < 1) baseManager.PurchaseManager();
            else baseManager.UpgradeManager();
            UpdateUI();
        }

        private void UpdateUI()
        {
            Slider.value = baseManager.Level / baseManager.MaxLevel;
            BtnText.text = baseManager.Level > 0 ? "Upgrade Manager" : "Buy Manager";
            MultiplierValueText.text = baseManager.Level > 0 
                ? $"Multiplier: {baseManager.ReturnCalculatedCurrencyMultiplier()}" 
                : $"Multiplier: {baseManager.CurrencyMultiplier}";
            LevelText.text = $"Level: {baseManager.Level}";
            CostText.text = baseManager.Level < 1
                ? $"Purchase Cost: {baseManager.InitialCost}"
                : $"Upgrade Cost: {baseManager.ReturnUpgradeCost()}";
        }
    }
}
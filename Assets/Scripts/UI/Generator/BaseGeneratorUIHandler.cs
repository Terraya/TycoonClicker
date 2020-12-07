using TDSStudio.Control;
using UnityEngine;
using UnityEngine.UI;

namespace TDSStudio.UI
{
    public abstract class BaseGeneratorUIHandler : MonoBehaviour
    {
        [Header("General Text")] public Text NameText;
        public Text BtnText;
        public Text LevelText;
        public Text CostText;
        public Text IncomeText;

        [Header("Slider")] public Slider Slider;
        public Text TimerText;

        private BaseGenerator baseGenerator;
        public BaseGenerator BaseGenerator => baseGenerator;

        private void Awake() => SetBaseGenerator(GetComponent<BaseGenerator>());

        private void Start()
        {
            UpdateUI();
            NameText.text = baseGenerator.GeneratorName;
        }

        private void Update() => GeneratorSliderHandler();

        void LateUpdate() => IncomeText.text = BaseGenerator.Level > 0
            ? $"Income: {BaseGenerator.ReturnGeneratedCurrency()}"
            : $"Income: {BaseGenerator.Income}";

        public void SetBaseGenerator(BaseGenerator generator) => baseGenerator = generator;

        public void BuyGeneratorBtnHandler()
        {
            if (BaseGenerator.Level < 1) BaseGenerator.PurchaseGenerator();
            else BaseGenerator.UpgradeGenerator();
            UpdateUI();
        }

        private void GeneratorSliderHandler()
        {
            if (BaseGenerator.Level > 0)
            {
                BaseGenerator.SetRunningTimer(BaseGenerator.RunningTimer - Time.deltaTime);
                TimerText.text = BaseGenerator.RunningTimer.ToString();
                Slider.value = BaseGenerator.RunningTimer / BaseGenerator.Timer;

                if (BaseGenerator.RunningTimer > 0) return;
                BaseGenerator.SetRunningTimer(BaseGenerator.Timer);
                BaseGenerator.CurrencyManager.ReturnCurrencyByCurrencyType(baseGenerator.CurrencyIncomeType)
                    .IncreaseCurrencyAmount(BaseGenerator.ReturnGeneratedCurrency());
            }
        }

        private void UpdateUI()
        {
            BtnText.text = BaseGenerator.Level > 0 ? "Upgrade Generator" : "Buy Generator";
            LevelText.text = $"Level: {BaseGenerator.Level}";
            CostText.text = BaseGenerator.Level > 0
                ? $"Upgrade Cost: {BaseGenerator.ReturnUpgradeCost()}"
                : $"Cost: {BaseGenerator.InitialCost}";
        }
    }
}
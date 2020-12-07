using TDSStudio.Core;

namespace TDSStudio.Control {
    public class GoldGenerator : BaseGenerator {
        public override double ReturnGeneratedCurrency () => Income * Level * CurrencyManager.ReturnCurrencyMultiplicatorByCurrencyType (CurrencyIncomeType).Multiplicator;

        public override void PurchaseGenerator () {
            if (InitialCost > CurrencyManager.ReturnCurrencyByCurrencyType (CurrencyCostType).CurrencyAmount || Level > 0) return;
            CurrencyManager.ReturnCurrencyByCurrencyType (CurrencyCostType).DecreaseCurrencyAmount (InitialCost);
            IncreaseLevel ();
        }

        public override void UpgradeGenerator () {
            if (CurrencyManager.ReturnCurrencyByCurrencyType (CurrencyIncomeType).CurrencyAmount < ReturnUpgradeCost () || Level < 1) return;
            CurrencyManager.ReturnCurrencyByCurrencyType (CurrencyIncomeType).DecreaseCurrencyAmount (ReturnUpgradeCost ());
            IncreaseLevel ();
        }
    }
}
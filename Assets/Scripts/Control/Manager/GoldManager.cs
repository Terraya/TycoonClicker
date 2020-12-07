using TDSStudio.Core;

namespace TDSStudio.Control
{
    public class GoldManager : BaseManager
    {
        public override float ReturnCalculatedCurrencyMultiplier() => CurrencyMultiplier * Level;

        public override void PurchaseManager()
        {
            if(CurrencyManager.ReturnCurrencyByCurrencyType(ManagerCostType).CurrencyAmount < InitialCost) return;
            CurrencyManager.ReturnCurrencyByCurrencyType(ManagerCostType).DecreaseCurrencyAmount(InitialCost);
            IncreaseLevel();
            CurrencyManager.ReturnCurrencyMultiplicatorByCurrencyType(ManagerMultiplierType).IncrementMultiplicator(ReturnCalculatedCurrencyMultiplier());
        }

        public override void UpgradeManager()
        {
            if(CurrencyManager.ReturnCurrencyByCurrencyType(ManagerCostType).CurrencyAmount < ReturnUpgradeCost()) return;
            CurrencyManager.ReturnCurrencyByCurrencyType(ManagerCostType).DecreaseCurrencyAmount(ReturnUpgradeCost());
            IncreaseLevel();
            CurrencyManager.ReturnCurrencyMultiplicatorByCurrencyType(ManagerMultiplierType).IncrementMultiplicator(ReturnCalculatedCurrencyMultiplier());
        }
    }
}
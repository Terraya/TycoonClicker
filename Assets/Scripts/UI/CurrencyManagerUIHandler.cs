using UnityEngine;
using UnityEngine.UI;
using TDSStudio.Core;

namespace TDSStudio.UI
{
    [RequireComponent(typeof(CurrencyManager))]
    public class CurrencyManagerUIHandler : MonoBehaviour
    {
        public Text GoldText;

        private CurrencyManager currencyManager;

        private void Awake() => currencyManager = GetComponent<CurrencyManager>();
        private void LateUpdate() => UpdateCurrencyManagerUI();
        private void UpdateCurrencyManagerUI() => GoldText.text = currencyManager.ReturnCurrencyByCurrencyType(CurrencyType.Gold).CurrencyAmount.ToString();
    }
}
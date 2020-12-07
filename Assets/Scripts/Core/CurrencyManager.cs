using UnityEngine;
using UnityEngine.UI;

namespace TDSStudio.Core
{
    public class CurrencyManager : MonoBehaviour
    {
        [Header("UI Setup")]
        public Text currencyText;

        [SerializeField] private CurrencyMultiplicator[] currencyMultiplicators;
        [SerializeField] private Currency[] currencys;

        private void Update() 
            => currencyText.text = ReturnCurrencyByCurrencyType(CurrencyType.Gold).CurrencyAmount.ToString();

        public CurrencyMultiplicator ReturnCurrencyMultiplicatorByCurrencyType(CurrencyType currencyType)
        {
            foreach (CurrencyMultiplicator multiplicator in currencyMultiplicators)
            {
                if (multiplicator.CurrencyType.Equals(currencyType))
                {
                    return multiplicator;
                }
            }
            Debug.LogError("CurrencyType not found");
            return null;
        }

        public Currency ReturnCurrencyByCurrencyType(CurrencyType currencyType)
        {
            foreach (Currency currency in currencys)
            {
                if (currency.CurrencyType.Equals(currencyType))
                {
                    return currency;
                }
            }
            Debug.LogError("Currency not found");
            return null;
        }
    }
}
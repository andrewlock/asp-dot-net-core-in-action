using System;
using System.Collections.Generic;
using System.Linq;

namespace ExchangeRates.Web
{
    public class CurrencyConverter
    {
        /// <summary>
        /// Converts a value in one currency to GBP
        /// </summary>
        /// <param name="value">The value in the other currency</param>
        /// <param name="exchangeRate">The exchange rate from GBP to the currency. e.g. 1 GBP = <paramref name="exchangeRate"/>USD  </param>
        /// <param name="decimalPlaces"></param>
        /// <returns></returns>
        public decimal ConvertToGbp(decimal value, decimal exchangeRate, int decimalPlaces)
        {
            if (exchangeRate <= 0)
            {
                throw new ArgumentException("Exchange rate must be greater than zero", nameof(exchangeRate));
            }

            if (decimalPlaces < 0)
            {
                throw new ArgumentException("Decimal places must not be less than zero", nameof(decimalPlaces));
            }

            var valueInGbp = value / exchangeRate;

            return decimal.Round(valueInGbp, decimalPlaces);
        }
    }
}

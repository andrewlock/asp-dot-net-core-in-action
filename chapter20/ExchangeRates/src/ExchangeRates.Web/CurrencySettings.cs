using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRates.Web
{
    public class CurrencySettings
    {
        public decimal DefaultValue { get; set; }
        public decimal DefaultExchangeRate { get; set; }
        public int DefaultDecimalPlaces { get; set; }
    }
}

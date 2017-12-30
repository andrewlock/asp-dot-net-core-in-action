using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverter.Controllers
{
    public class CurrencyController : Controller
    {
        public string ConvertCurrency(string currencyIn, string currencyOut, int qty)
        {
            return $@"CurrencyIn: {currencyIn}
CurrencyOut: {currencyOut}
Qty: {qty}";
        }
    }
}
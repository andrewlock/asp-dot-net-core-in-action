using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CurrencyConverter.Controllers
{
    public class CurrencyController : Controller
    {
        static readonly Dictionary<string, decimal> AllCurrencies =
            new Dictionary<string, decimal>
            {
                {"GBP", 1.00m},
                {"USD", 1.22m},
                {"CAD", 1.64m},
                {"EUR", 1.15m},
            };

        public IActionResult Index()
        {
            var model = AllCurrencies.Select(x => new SelectListItem { Text = x.Key }).ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult ShowRates(List<string> currencies)
        {
            var selectedCurrencies =
                AllCurrencies.Where(x => currencies.Contains(x.Key))
                .ToDictionary(x => x.Key, x => x.Value);
            return View(selectedCurrencies);
        }

        public class ViewModel
        {
            public List<string> Currencies { get; set; }
        }
    }
}

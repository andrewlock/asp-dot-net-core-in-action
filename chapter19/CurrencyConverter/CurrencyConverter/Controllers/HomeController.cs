using CurrencyConverter;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverter.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new CurrencyConverterModel
            {
                CurrencyFrom = "CAD",
                CurrencyTo = "USD",
                Quantity = 50
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(CurrencyConverterModel viewModel)
        {
            return View(viewModel);
        }
    }
}

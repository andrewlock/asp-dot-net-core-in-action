using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ExchangeRates.Web.Models;
using Microsoft.Extensions.Options;

namespace ExchangeRates.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly CurrencyConverter _converter;
        private readonly CurrencySettings _settings;
        public HomeController(CurrencyConverter converter, IOptions<CurrencySettings> settings)
        {
            _converter = converter;
            _settings = settings.Value;
        }

        public ViewResult Index()
        {
            var viewModel = new ConvertViewModel()
            {
                Value = _settings.DefaultValue,
                ExchangeRate = _settings.DefaultExchangeRate,
                DecimalPlaces = _settings.DefaultDecimalPlaces,
            };
            return View(viewModel);
        }

        [HttpPost]
        public ViewResult Index(ConvertViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Result = _converter.ConvertToGbp(
                model.Value,
                model.ExchangeRate,
                model.DecimalPlaces);

            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

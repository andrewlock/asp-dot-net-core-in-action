using ExchangeRates.Web;
using ExchangeRates.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Xunit;

namespace ExchangeRateHelper.Test
{
    public class CurrencyControllerTest
    {
        [Fact]
        public void Convert_ReturnsValue()
        {
            var converter = new CurrencyConverter();
            var controller = new CurrencyController(converter);
            var model = new ConvertInputModel
            {
                Value = 1,
                ExchangeRate = 2,
                DecimalPlaces = 2,
            };

            var result = controller.Convert(model);
            Assert.IsType<JsonResult>(result);
        }

        [Fact]
        public void Convert_Returns400WhenInvalid()
        {
            var converter = new CurrencyConverter();
            var controller = new CurrencyController(converter);
            var model = new ConvertInputModel
            {
                Value = 1,
                ExchangeRate = -2,
                DecimalPlaces = 2,
            };
            controller.ModelState.AddModelError(
                nameof(model.ExchangeRate),
                "Exchange rate must be greater than zero"
                );

            var result = controller.Convert(model);
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}

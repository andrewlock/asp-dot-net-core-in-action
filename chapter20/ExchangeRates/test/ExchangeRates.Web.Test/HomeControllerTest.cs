using System;
using System.Collections.Generic;
using System.Text;
using ExchangeRates.Web;
using ExchangeRates.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Xunit;

namespace ExchangeRateHelper.Test
{
    public class HomeControllerTest
    {
        [Fact]
        public void Index_ReturnsViewModel()
        {
            var converter = new CurrencyConverter();
            var controller = new HomeController(converter, Options.Create(new CurrencySettings()));

            var result = controller.Index();
            Assert.IsType<ViewResult>(result);

            var viewModel = (result as ViewResult).Model;
            Assert.IsType<ConvertViewModel>(viewModel);

        }

        [Fact]
        public void WhenViewModelIsValid_ReturnsIndexViewModel()
        {
            var converter = new CurrencyConverter();
            var controller = new HomeController(converter, Options.Create(new CurrencySettings()));
            var model = new ConvertViewModel
            {
                Value = 1,
                ExchangeRate = 1.23m,
                DecimalPlaces = 2,
            };

            var viewResult = controller.Index(model);
            Assert.IsType<ConvertViewModel>(viewResult.Model);
        }
    }
}

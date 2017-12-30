using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using CurrencyConverter.Models;

namespace CurrencyConverter.Controllers
{
    public class CurrencyController : Controller
    {
        public IActionResult Convert()
        {
            return View(new CurrencyConverterModel());
        }

        [HttpPost]
        public IActionResult Convert(CurrencyConverterModel model)
        {
            if (model.CurrencyFrom == model.CurrencyTo)
            {
                ModelState.AddModelError(string.Empty, "Cannot convert currency to itself");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Store the valid values somewhere (e.g. database), 
            // do the conversion etc

            return RedirectToAction("Index", "Checkout");
        }
    }
}

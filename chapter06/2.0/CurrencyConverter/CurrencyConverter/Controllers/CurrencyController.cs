using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return View();
        }
    }

}

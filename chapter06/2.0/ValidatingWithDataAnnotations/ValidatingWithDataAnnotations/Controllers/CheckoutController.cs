using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ValidatingWithDataAnnotations.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult SaveUser()
        {
            return View(new UserBindingModel());
        }

        [HttpPost]
        public IActionResult SaveUser(UserBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //Do something, e.g. take payment, save to database etc.

            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return View();
        }
    }

}

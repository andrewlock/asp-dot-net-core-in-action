using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ValidatingWithDataAnnotations.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new HomeViewModel());
        }

        [HttpPost]
        public IActionResult Index(HomeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                ModelState.AddModelError("", "The validation succeeded, but here's a model error for you!");
            }
            return View(viewModel);
        }

    }

}

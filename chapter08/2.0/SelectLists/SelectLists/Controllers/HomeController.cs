using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SelectLists.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new SelectListsViewModel());
        }

        [HttpPost]
        public IActionResult Index(SelectListsViewModel viewModel)
        {
            return View("Results", viewModel);
        }
    }
}

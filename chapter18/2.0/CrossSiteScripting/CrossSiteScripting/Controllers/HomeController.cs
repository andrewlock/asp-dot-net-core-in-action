using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrossSiteScripting.Models;
using System.ComponentModel;

namespace CrossSiteScripting.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IList<string> _data = new List<string>{"Dave", "Jim"};

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Protected()
        {
            return View(GetViewModel());
        }

        [HttpPost]
        public IActionResult Protected(DataViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Data = _data;
                return View(viewModel);
            }
            _data.Add(viewModel.Name);
            return RedirectToAction(nameof(Protected));
        }

        public IActionResult Vulnerable()
        {
            return View(GetViewModel());
        }

        [HttpPost]
        public IActionResult Vulnerable(DataViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Data = _data;
                return View(viewModel);
            }
            _data.Add(viewModel.Name);
            return RedirectToAction(nameof(Vulnerable));
        }


        private static DataViewModel GetViewModel()
        {
            return new DataViewModel
            {
                Data = _data,
                Name = "<script>alert('Oh no! XSS!')</script>"
            };
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

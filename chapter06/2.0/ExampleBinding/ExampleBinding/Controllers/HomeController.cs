using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ExampleBinding.Controllers
{
    public partial class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new ProductModel());
        }

        [HttpPost]
        public IActionResult EditProduct(ProductModel product)
        {
            return View("Index", product);
        }

        [HttpPost]
        public IActionResult EditTwoProducts(ProductModel product1, ProductModel product2)
        {
            return View("Index", product1);
        }
    }
}

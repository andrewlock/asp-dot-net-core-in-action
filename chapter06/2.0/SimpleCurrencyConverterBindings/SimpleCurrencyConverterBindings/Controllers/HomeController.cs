using Microsoft.AspNetCore.Mvc;

namespace SimpleCurrencyConverterBindings.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

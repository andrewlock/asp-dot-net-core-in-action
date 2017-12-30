using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace StoreViewerApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly MapDisplaySettings _settings;
        public HomeController(IOptionsSnapshot<MapDisplaySettings> settings)
        {
            _settings = settings.Value;
        }

        public IActionResult Index()
        {
            return View(_settings);
        }
        
        public IActionResult Error()
        {
            return View();
        }
    }
}

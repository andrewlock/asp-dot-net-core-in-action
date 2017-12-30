using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StoreViewerApplication.Models;

namespace StoreViewerApplication.Controllers
{
    public class TestController : Controller
    {
        private readonly TestOptions _settings;
        public TestController(IOptionsSnapshot<TestOptions> settings)
        {
            _settings = settings.Value;
        }

        public IActionResult Index()
        {
            return View(_settings);
        }
    }
}

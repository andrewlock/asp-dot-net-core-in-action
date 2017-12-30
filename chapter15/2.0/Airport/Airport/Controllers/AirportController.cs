using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Airport.Models;
using Microsoft.AspNetCore.Authorization;

namespace Airport.Controllers
{
    public class AirportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize("CanEnterSecurity")]
        public IActionResult AirportSecurity()
        {
            return View();
        }

        [Authorize("CanAccessLounge")]
        public IActionResult AirportLounge()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

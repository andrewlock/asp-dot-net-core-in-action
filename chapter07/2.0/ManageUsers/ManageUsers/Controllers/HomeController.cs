using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ManageUsers.Models;

namespace ManageUsers.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// WARNING: For demo only, not thread safe, you would store these values in a database etc
        /// </summary>
        private static readonly List<string> _users = new List<string>
        {
            "Bart",
            "Jimmy",
            "Robbie"
        };

        public IActionResult Index()
        {
            var viewModel = RebuildViewModel(new IndexViewModel());
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel = RebuildViewModel(viewModel);
                return View(viewModel);
            }
            if (_users.Contains(viewModel.NewUser))
            {
                //Note, you would typically extract this to a validation attribute
                //But I do it here as the users list is hard coded above
                ModelState.AddModelError(nameof(viewModel.NewUser), "This user already exists!");
                viewModel = RebuildViewModel(viewModel);
                return View(viewModel);
            }

            //all ok, add the user and clear the existing value
            _users.Add(viewModel.NewUser);

            viewModel = RebuildViewModel(new IndexViewModel());
            return View(viewModel);
        }

        private IndexViewModel RebuildViewModel(IndexViewModel viewModel)
        {
            //display newest first
            viewModel.ExistingUsers = _users.Select(user => user).Reverse().ToList();
            return viewModel;
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult ViewUser(string userName)
        {
            ViewData["Message"] = userName;
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

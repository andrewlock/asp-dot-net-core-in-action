using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartialViews.Models;

namespace PartialViews.Controllers
{
    public class ToDoController : Controller
    {
        //This list would be loaded from a database or file etc
        private static readonly List<ToDoItemViewModel> Tasks = new List<ToDoItemViewModel>
        {
            new ToDoItemViewModel(1, "Shopping List", "Buy milk", "Buy eggs", "Buy bread"),
            new ToDoItemViewModel(2, "Agenda", "Pick up kids", "Take kids to school"),
            new ToDoItemViewModel(4, "Car stuff", "Get fuel", "Check oil", "Check Tyre pressure"),
            new ToDoItemViewModel(4, "Problems"),
            new ToDoItemViewModel(5, "Writing tasks","Write blog post", "Edit book chapter"),
        };

        const int RecentToDosToDisplay = 3;

        public IActionResult Index()
        {
            var recentTasks = Tasks.Take(RecentToDosToDisplay);
            var viewModel = new RecentTasksViewModel(recentTasks);
            return View(viewModel);
        }

        public IActionResult View(int id)
        {
            var item = Tasks.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return RedirectToAction("Index");
            }
            return View(item);
        }

    }
}

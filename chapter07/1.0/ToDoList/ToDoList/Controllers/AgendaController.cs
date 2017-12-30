using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ToDoList.Controllers
{
    public class AgendaController : Controller
    {
        private readonly List<ToDoItemViewModel> Tasks = new List<ToDoItemViewModel>
        {
            new ToDoItemViewModel(1, "Buy milk", "Buy eggs", "Buy bread"),
            new ToDoItemViewModel(2, "Pick up kids", "Take kids to school"),
            new ToDoItemViewModel(3),
            new ToDoItemViewModel(4, "Get fuel", "Check oil", "Check Tyre pressure"),
        };

        public IActionResult Index()
        {
            return View(Tasks);
        }

        public IActionResult View(int id)
        {
            var item = Tasks.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return RedirectToAction("List");
            }

            if (item.IsComplete)
            {
                return View("Complete", item);
            }
            return View(item);
        }

    }
}

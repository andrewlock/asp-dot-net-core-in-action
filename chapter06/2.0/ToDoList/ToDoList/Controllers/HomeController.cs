using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {
        public IActionResult ListCategory(ToDoBindingModel model)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            //TODO: Validate the parameters
            var service = new ToDoService();
            var tasks = service.GetToDoItems(model.Category, model.Username)
                .Select(x => new ToDoItemViewModel.Task(x.Number, x.Title));
            var viewModel = new ToDoItemViewModel(tasks, model.Category, model.Username);

            return View(viewModel);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViews.Models
{
    public class RecentTasksViewModel
    {
        public RecentTasksViewModel(IEnumerable<ToDoItemViewModel> tasks)
        {
            ToDos = new List<ToDoItemViewModel>(tasks);
            NumberOfToDos = ToDos.Count();
        }

        public int NumberOfToDos { get; }
        public IEnumerable<ToDoItemViewModel> ToDos { get; }
    }
}

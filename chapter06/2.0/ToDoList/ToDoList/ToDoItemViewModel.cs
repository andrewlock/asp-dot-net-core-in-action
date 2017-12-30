using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList
{
    public class ToDoItemViewModel
    {
        public ToDoItemViewModel(IEnumerable<Task> tasks, string category, string username)
        {
            Tasks = tasks;
            Category = category;
            Username = username;
        }

        public IEnumerable<Task> Tasks { get; }
        public string Category { get; }
        public string Username { get; }

        public class Task
        {
            public Task(int id, string task)
            {
                Id = id;
                Description = task;
            }

            public int Id { get; }
            public string Description { get; set; }
        }
    }
}

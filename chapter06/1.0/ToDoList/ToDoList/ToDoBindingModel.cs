using System.ComponentModel.DataAnnotations;

namespace ToDoList
{
    public class ToDoBindingModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Category { get; set; }
    }
}

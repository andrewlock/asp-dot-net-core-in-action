using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManageUsers
{
    public class IndexViewModel
    {
        [Required]
        [Display(Name = "Add new user")]
        [StringLength(100)]
        public string NewUser { get; set; }

        [BindNever]
        public IList<string> ExistingUsers { get; set; }
    }
}

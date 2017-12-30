using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CrossSiteScripting.Models
{
    public class DataViewModel
    {
        [Editable(false), BindNever]
        public IList<string> Data { get; set; }

        [Required]
        public string Name { get; set; }
    }
    
}

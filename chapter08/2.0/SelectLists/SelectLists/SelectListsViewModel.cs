using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelectLists
{
    public class SelectListsViewModel
    {
        public string SelectedValue1 { get; set; }
        public string SelectedValue2 { get; set; }
        public IEnumerable<string> MultiValues1 { get; set; }
        public IEnumerable<string> MultiValues2 { get; set; }

        //Remove the Group value from the ItemsWithGroups list items
        public IEnumerable<SelectListItem> Items =>
            ItemsWithGroups.Select(item => new SelectListItem
            {
                Value = item.Value,
                Text = item.Text
            });


        public ICollection<SelectListItem> ItemsWithGroups { get; set; } = new List<SelectListItem>
        {
           new SelectListItem{Value= "javascript", Text="JavaScript", Group = _dynamicGroup},
           new SelectListItem{Value= "cpp", Text="C++", Group = _staticGroup},
           new SelectListItem{Value= "python", Text= "Python", Group = _dynamicGroup},
           new SelectListItem{Value= "csharp", Text="C#"},
        };

        private static readonly SelectListGroup _dynamicGroup = new SelectListGroup { Name = "Dynamic Languages" };
        private static readonly SelectListGroup _staticGroup = new SelectListGroup { Name = "Static Languages" };
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Airport.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Employee Number")]
        public string EmployeeNumber { get; set; }

        [Display(Name = "Boarding Pass Number")]
        public string BoardingPassNumber { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Is banned from Lounge?")]
        public bool IsBannedFromLounge { get; set; }

        [Display(Name = "FrequentFlyerClass")]
        public string FrequentFlyerClass { get; set; }

        public SelectListItem[] FrequentFlyerClasses {get; } = 
            {
                new SelectListItem{Text = "Gold", Value = "Gold"},
                new SelectListItem{Text = "Silver", Value = "Silver"},
                new SelectListItem{Text = "Bronze", Value = "Bronze"},
            };
    }
}

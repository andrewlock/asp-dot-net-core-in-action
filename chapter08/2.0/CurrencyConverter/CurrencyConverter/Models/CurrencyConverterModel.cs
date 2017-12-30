using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CurrencyConverter.Models
{
    public class CurrencyConverterModel
    {
        [Required]
        [StringLength(3, MinimumLength = 3)]
        [CurrencyCode("GBP", "USD", "CAD", "EUR")]
        [Display(Name = "Currency From")]
        public string CurrencyFrom { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3)]
        [CurrencyCode("GBP", "USD", "CAD", "EUR")]
        [Display(Name = "Currency To")]
        public string CurrencyTo { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Quantity { get; set; }

        public SelectListItem[] CurrencyCodes { get; } =
        {
            new SelectListItem{Text="GBP", Value = "GBP"},
            new SelectListItem{Text="USD", Value = "USD"},
            new SelectListItem{Text="CAD", Value = "CAD"},
            new SelectListItem{Text="EUR", Value = "EUR"},
        };
    }
}

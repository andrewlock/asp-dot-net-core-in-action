using System.ComponentModel;

namespace ExchangeRates.Web
{
    public class ConvertViewModel: ConvertInputModel
    {
        [DisplayName("Value in alternate currency")]
        public decimal Result { get; set; }
    }
}

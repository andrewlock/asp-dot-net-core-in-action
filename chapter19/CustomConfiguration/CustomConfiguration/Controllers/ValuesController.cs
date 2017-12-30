using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CustomConfiguration.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly CurrencyOptions _currencies;

        public ValuesController(IOptions<CurrencyOptions> currencies, Lazy<ICurrencyProvider> provider)
        {
            _currencies = currencies.Value;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _currencies.Currencies;
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.shopping.com.Controllers
{
    // [EnableCors("AllowShoppingApp")]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        // [EnableCors("AllowShoppingApp")]
        // Disabling CORS only works for policies applied using the [EnableCors] attribute
        // It won't disable CORS added through the UseCors middleware
        // [DisableCors] 
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] {
               "Aunt Hattie's",
                "Danish",
                "Cobblestone",
                "Dave's Killer Bread",
                "Entenmann's",
                "Famous Amos",
                "Home Pride",
                "Hovis",
                "Keebler Company",
                "Kits",
                "McVitie's",
                "Mother's Pride",
            };
        }
    }
}

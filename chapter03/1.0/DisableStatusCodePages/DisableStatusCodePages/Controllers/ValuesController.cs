using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;

namespace DisableStatusCodePages.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        public IActionResult Get()
        {
            var statusCodePagesFeature = HttpContext.Features
                    .Get<IStatusCodePagesFeature>();
            if (statusCodePagesFeature != null)
            {
                statusCodePagesFeature.Enabled = false;
            }

            return StatusCode(500);

        }
    }
}

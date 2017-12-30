using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilterPipelineExample.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterPipelineExample.Controllers
{
    [LogResourceFilter, LogActionFilter, LogAuthorizationFilter, LogResultFilter, LogExceptionFilter]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Console.WriteLine("Executing HomeController.Index");
            return Content("Home Page");
        }

        public IActionResult Exception()
        {
            Console.WriteLine("Executing HomeController.Exception");
            throw new System.Exception("Exception thrown!");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Executing HomeController.OnActionExecuting");
            //context.Result = new ContentResult()
            //{
            //    Content = "HomeController.OnActionExecuting - Short-circuiting ",
            //};
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"Executing HomeController.OnActionExecuted: cancelled {context.Canceled}");
            //context.ExceptionHandled = true;
            //context.Result = new ContentResult()
            //{
            //    Content = "HomeController - convert to success ",
            //};
        }
    }
}

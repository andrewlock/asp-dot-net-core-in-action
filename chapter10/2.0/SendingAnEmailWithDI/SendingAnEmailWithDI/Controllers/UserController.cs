using DependencyInjectionExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionExample.Controllers
{
    public class UserController : Controller
    {
        private readonly IEmailSender _emailSender;
        public UserController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public IActionResult RegisterUser(string username)
        {
            _emailSender.SendEmail(username);
            return View();
        }
    }
}

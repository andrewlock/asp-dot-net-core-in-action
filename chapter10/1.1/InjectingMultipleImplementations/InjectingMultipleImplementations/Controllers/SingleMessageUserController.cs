using DependencyInjectionExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionExample.Controllers
{
    public class SingleMessageController : Controller
    {
        private readonly IMessageSender _messageSender;
        public SingleMessageController(IMessageSender messageSender)
        {
            _messageSender = messageSender;
        }

        public IActionResult RegisterUser(string username)
        {
            _messageSender.SendMessage(username);
            return View();
        }
    }
}

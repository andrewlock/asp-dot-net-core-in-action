using System.Collections.Generic;
using DependencyInjectionExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionExample.Controllers
{
    public class MultiMessageController : Controller
    {
        private readonly IEnumerable<IMessageSender> _messageSenders;
        public MultiMessageController(IEnumerable<IMessageSender> messageSenders)
        {
            _messageSenders = messageSenders;
        }

        public IActionResult RegisterUser(string username)
        {
            foreach (var messageSender in _messageSenders)
            {
                messageSender.SendMessage(username);
            }
            
            return View();
        }
    }
}

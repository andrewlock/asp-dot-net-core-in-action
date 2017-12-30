using DependencyInjectionExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionExample.Controllers
{
    public class UserController : Controller
    {
        public IActionResult RegisterUser(string username)
        {
            var emailSender = new EmailSender(
                new MessageFactory(),
                new NetworkClient(
                    new EmailServerSettings
                    {
                        Host = "smtp.server.com",
                        Port = 25
                    })
                );
            emailSender.SendEmail(username);
            return View();
        }
    }
}

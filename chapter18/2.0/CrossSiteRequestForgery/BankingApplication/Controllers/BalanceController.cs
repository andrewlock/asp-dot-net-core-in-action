using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankingApplication.Controllers
{
    [Authorize]
    public class BalanceController : Controller
    {
        private static ConcurrentDictionary<string, int> _balances = new ConcurrentDictionary<string, int>();

        public IActionResult Index()
        {
            var userId = User.Identity.Name;

            var viewModel = new BalanceViewModel
            {
                Balance = GetBalance(userId),
            };

            return View(viewModel);
        }

        // Uncomment this to protect again CSRF attacks
        // [ValidateAntiForgeryToken] 
        [HttpPost]
        public IActionResult Withdraw(int amount)
        {
            if (amount <= 0)
            {
                return BadRequest();
            }

            var userId = User.Identity.Name;
            var balance = GetBalance(userId);
            var newBalance = balance - amount;

            _balances[userId] = newBalance;

            return RedirectToAction(nameof(Index));
        }

        private static int GetBalance(string userId)
        {
            //everyone starts with a balance of 10,000
            return _balances.GetOrAdd(userId, 10_000);
        }
    }
}

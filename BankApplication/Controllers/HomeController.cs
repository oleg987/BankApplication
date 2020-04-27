using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BankApplication.Models;

namespace BankApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Bank bank = new Bank();

            return View(bank);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Page()
        {
            List<Bank> banks = new List<Bank>();

            banks.Add(new Bank());
            banks.Add(new Bank() { Title = "GigaBank"});
            banks.Add(new Bank() { Title = "TeraBank"});

            return View(banks);
        }
    }
}

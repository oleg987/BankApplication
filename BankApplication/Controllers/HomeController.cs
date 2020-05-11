using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BankApplication.Models;
using BankApplication.Models.Repository;
using BankApplication.Models.Repository.FakeStorage;
using Microsoft.AspNetCore.Authorization;

namespace BankApplication.Controllers
{    
    public class HomeController : Controller
    {
        private IBankRepository repository;

        public HomeController(IBankRepository repository)
        {
            this.repository = repository;
        }

        [Authorize]
        public IActionResult Index()
        {
            var bank = repository.GetBank();

            return View(bank);
        }

        public IActionResult AddBranch()
        {
            var branch = new Branch();

            return View(branch);
        }

        [HttpPost]
        public IActionResult AddBranch(Branch branch)
        {
            var bank = repository.GetBank();
            bank.Branch.Add(branch);
            repository.Update(bank);

            return View("Index", bank);
        }

        public IActionResult Privacy()
        {
            return View();
        }        
    }
}

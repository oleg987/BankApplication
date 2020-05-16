using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BankApplication.Models;
using BankApplication.Models.Repository;

using Microsoft.AspNetCore.Authorization;
using BankApplication.Models.Entities;

namespace BankApplication.Controllers
{    
    public class HomeController : Controller
    {
        private IRepository<Bank> repository;

        public HomeController(IRepository<Bank> repository)
        {
            this.repository = repository;
        }

        [Authorize]
        public IActionResult Index()
        {
            var bank = repository.GetAll().FirstOrDefault();

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
            var bank = repository.GetAll().FirstOrDefault();
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

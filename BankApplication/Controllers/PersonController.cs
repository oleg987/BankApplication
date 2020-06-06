using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApplication.Models;
using BankApplication.Models.Entities;
using BankApplication.Models.Repository;
using BankApplication.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace BankApplication.Controllers
{

    // host/Person/{Action}
    [Authorize]
    public class PersonController : Controller
    {
        private UserManager<User> userManager;
        private UnitOfWork uow;

        public PersonController(UserManager<User> userManager, UnitOfWork uow)
        {
            this.userManager = userManager;
            this.uow = uow;
        }

        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);            

            var person = uow.PersonRepository.GetById(user.PersonId ?? default);

            if (person != null)
            {
                var viewModel = new PersonIndexViewModel()
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    MiddleName = person.MiddleName,
                    Phone = person.Phone,
                    Email = person.Email,
                    Passport = person.PassportSeries + person.PassportNumber,
                    Tin = person.Tin,
                    IsDeleted = person.IsDeleted,
                    RegistrationDate = person.Client.RegistrationDate,
                };

                return View(viewModel);
            }

            return StatusCode(404);
        }

        [HttpGet]
        public IActionResult Update()
        {
            var user = userManager.GetUserAsync(User).Result;

            var person = uow.PersonRepository.GetById(user.PersonId ?? default);

            var model = new PersonUpdateViewModel()
            {
                Phone = person.Phone,
                Email = person.Email,
                PassportSeries = person.PassportSeries,
                PassportNumber = person.PassportNumber,
                Tin = person.Tin,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(PersonUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.GetUserAsync(User).Result;

                var person = uow.PersonRepository.GetById(user.PersonId ?? default);

                person.Tin = model.Tin;
                person.Phone = model.Phone;
                person.Email = model.Email;
                person.PassportSeries = model.PassportSeries;
                person.PassportNumber = model.PassportNumber;

                uow.PersonRepository.Update(person);
                uow.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete()
        {
            var user = userManager.GetUserAsync(User).Result;

            uow.PersonRepository.Delete(user.PersonId ?? default);
            uow.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Restore()
        {
            var user = userManager.GetUserAsync(User).Result;

            uow.PersonRepository.Restore(user.PersonId ?? default);
            uow.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApplication.Models;
using BankApplication.Models.Entities;
using BankApplication.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BankApplication.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        #region Constructor
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private DataDbContext ctx;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, DataDbContext ctx)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.ctx = ctx;
        }
        #endregion

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginModel model, string returnUrl)
        {
            #region LoginLogic
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByEmailAsync(model.Email);

                if(user != null)
                {
                    await signInManager.SignOutAsync();

                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/");
                    }
                }

                ModelState.AddModelError(nameof(UserLoginModel.Email), "Invalid e-mail or password");
            }
            #endregion
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Register() => View();

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(ClientCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    UserName = model.Login,
                    Email = model.Email,
                    PhoneNumber = model.Phone
                };

                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                
                if (result.Succeeded)
                {
                    var person = new Person()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        MiddleName = model.MiddleName,
                        PassportSeries = model.PassportSeries,
                        PassportNumber = model.PassportNumber,
                        Tin = model.Tin,
                        Email = model.Email,
                        Phone = model.Phone,
                        UserId = user.Id,
                        Client = new Client() { RegistrationDate = DateTime.Now }
                    };

                    ctx.Persons.Add(person);
                    await ctx.SaveChangesAsync();

                    await signInManager.SignOutAsync();
                    var sign = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if(sign.Succeeded)
                    {
                        return Redirect("/");
                    }
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<RedirectResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
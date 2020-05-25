using BankApplication.Models.Entities;
using BankApplication.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApplication.Models.Repository
{
    public class EFUserRepository : IUserRepository
    {
        private UserManager<User> userManager;
        private DataDbContext dataCtx;
        private SecurityDbContext securityCtx;
        private RoleManager<IdentityRole> roleManager;

        public EFUserRepository(UserManager<User> userManager, DataDbContext dataCtx, SecurityDbContext securityCtx, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.dataCtx = dataCtx;
            this.securityCtx = securityCtx;
            this.roleManager = roleManager;
        }

        public async Task<bool> Create(ClientCreateViewModel model, string role)
        {
            using(var securityTransaction = securityCtx.Database.BeginTransaction())
            {
                using(var dataTransaction = dataCtx.Database.BeginTransaction())
                {
                    try
                    {
                        User user = new User()
                        {
                            UserName = model.Login,
                            Email = model.Email,
                            PhoneNumber = model.Phone
                        };

                        IdentityResult result = await userManager.CreateAsync(user, model.Password);

                        if (!result.Succeeded)
                        {
                            throw new Exception("Create user failed");
                        }

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

                        dataCtx.Persons.Add(person);
                        await dataCtx.SaveChangesAsync();

                        user.PersonId = person.Id;

                        securityCtx.Users.Update(user);
                        await securityCtx.SaveChangesAsync();

                        if (!roleManager.RoleExistsAsync(role).GetAwaiter().GetResult())
                        {
                            var r = await roleManager.CreateAsync(new IdentityRole(role));
                        }

                        var roleRes =  await userManager.AddToRoleAsync(user, role);

                        if(!roleRes.Succeeded)
                        {
                            throw new Exception($"Add user to role \"{role}\" failed");
                        }
                    }
                    catch (Exception e)
                    {
                        await securityTransaction.RollbackAsync();
                        await dataTransaction.RollbackAsync();

                        return false;
                    }

                    await securityTransaction.CommitAsync();
                    await dataTransaction.CommitAsync();
                }
            }

            return true;
        }
    }
}

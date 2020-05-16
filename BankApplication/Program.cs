using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApplication.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BankApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();

            var host = CreateHostBuilder(args).Build();

            using (var services = host.Services.CreateScope())
            {
                var secuityDbCtx = services.ServiceProvider.GetRequiredService<SecurityDbContext>();
                var dataDbCtx = services.ServiceProvider.GetRequiredService<DataDbContext>();
                var userMng = services.ServiceProvider.GetRequiredService<UserManager<User>>();
                var roleMng = services.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                secuityDbCtx.Database.Migrate();
                dataDbCtx.Database.Migrate();

                var adminRole = new IdentityRole("Admin");

                if (!secuityDbCtx.Roles.Any())
                {
                    roleMng.CreateAsync(adminRole).GetAwaiter().GetResult();
                }

                if(!secuityDbCtx.Users.Any(u => u.UserName == "admin"))
                {
                    var user = new User()
                    {
                        UserName = "admin",
                        Email = "admin@example.com"
                    };

                    var result = userMng.CreateAsync(user, "123456").GetAwaiter().GetResult();

                    if (result.Succeeded)
                    {
                        userMng.AddToRoleAsync(user, adminRole.Name).GetAwaiter().GetResult();
                    }
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

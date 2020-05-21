using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApplication.Models;
using BankApplication.Models.Entities;
using BankApplication.Models.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BankApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddDbContext<SecurityDbContext>(options =>
            {
                options.UseNpgsql(Configuration["IdentityStorage:ConnectionString"]);
            });

            services.AddIdentity<User, IdentityRole>(options =>
                {
                    options.User.RequireUniqueEmail = true;                    
                    
                    options.Password.RequiredLength = 6;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireDigit = false;
                })
                .AddEntityFrameworkStores<SecurityDbContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<DataDbContext>(options =>
            {
                options.UseNpgsql(Configuration["DataStorage:ConnectionString"]);
            });

            services.AddTransient<IRepository<Bank>, EFBankStorage>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseStatusCodePages();

            app.UseAuthentication();

            // host/{controller=Home}/{action=Index}/{id?}
            app.UseMvcWithDefaultRoute();
        }
    }
}

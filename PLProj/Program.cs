using BLLProject.Interfaces;
using BLLProject.Repositories;
using DALProject.Models;
using DALProject;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DALProject.Data.Seeding;
using Microsoft.Extensions.Options;

namespace PLProj
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region ConfigureServices
            builder.Services.AddControllersWithViews();

            #region Dbcontext
            builder.Services.AddDbContext<CarAppDbContext>(optionsBuilder =>
            {

                optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("CS"));
                optionsBuilder.UseLazyLoadingProxies(true);

            });

            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequiredUniqueChars = 2;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 5;

                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

                //options.Lockout.AllowedForNewUsers = true;
                //options.Lockout.MaxFailedAccessAttempts = 5;
                //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

            }).AddEntityFrameworkStores<CarAppDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/LogIn";
                options.LogoutPath = "/Account/LogOut";
                //options.ExpireTimeSpan = TimeSpan.MaxValue;
                options.AccessDeniedPath = "/Home/Index";
                options.SlidingExpiration = false;
            });

            #endregion

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion


            var app = builder.Build();

            #region Update DataBase

             using (var scope = app.Services.CreateScope())
             {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var dbcontext = services.GetRequiredService<CarAppDbContext>();
                    dbcontext.Database.Migrate();
                    var _RoleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                     await CarAppDbContextSeed.SeedRoles(_RoleManager);
                    var _UserManager = services.GetRequiredService<UserManager<AppUser>>();
                    await CarAppDbContextSeed.SeedUser(_UserManager);

                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<CarAppDbContext>();
                    logger.LogError(ex,"an error accured during apply migrations");
                }
             }
            #endregion

            #region Configure
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

			app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            
            #endregion

            app.Run();
            

        }

      
    }
}


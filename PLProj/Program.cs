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

            builder.Services.AddIdentity<AppUser, IdentityRole>(option => option.SignIn.RequireConfirmedAccount = false)
            .AddEntityFrameworkStores<CarAppDbContext>().AddDefaultTokenProviders();


            #endregion
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeAreaPage("Identity", "/Account/Register");
                options.Conventions.AuthorizeAreaPage("Identity", "/Account/Login");


            });
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

			app.MapRazorPages();

			app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            

            //app.MapControllerRoute(
            //       name: "Technician",
            //    pattern: "{controller=Tec}/{action=Register}/{id?}");
          

            #endregion

            app.Run();
            

        }

      
    }
}


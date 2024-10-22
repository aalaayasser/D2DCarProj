using BLLProject.Interfaces;
using BLLProject.Repositories;
using BLLProject.Specifications;
using DALProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLProj.Controllers
{
    public class DriverController: Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DriverController> _logger;
        private readonly IWebHostEnvironment env;

        public DriverController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IUnitOfWork unitOfWork,
            ILogger<DriverController> logger, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
            _logger = logger;
            this.env = env;
        }

        public IActionResult Index()
        {
            
            var Drivs = _unitOfWork.Repository<Driver>().GetAll().Select(t => (DriverViewModel)t).ToList();


            return View(Drivs);


        }



        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(DriverViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new AppUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                
                {
                    var Driver = new Driver
                    {
                        AppUserId = user.Id,
                        Availability = model.Availability,                     
                        BirthDate = model.BirthDate,
                        License = model.License,
                        LicenseDate = model.LicenseDate,
                        LicenseExpDate = model.LicenseExpDate,
                        Name = model.Name,
                        
                        


                    };

                    _unitOfWork.Repository<Driver>().Add(Driver);
                    _unitOfWork.Complete();

                    _logger.LogInformation("Driver created a new account with password.");

                    return RedirectToAction("Index");

                }


                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
        public IActionResult Details(int? Id, string viewname = "Details")
        {
            if (!Id.HasValue)
                return BadRequest();
           
            var Driv = _unitOfWork.Repository<Driver>().Get(Id.Value);
            if (Driv is null)
                return NotFound();

            return View(viewname, (DriverViewModel)Driv);
        }

        //public async Task<IActionResult> Details(int? Id, string viewname = "Details")
        //{
        //    if (!Id.HasValue)
        //        return BadRequest();

        //    // جلب المستخدم الحالي
        //    var _user = await _userManager.GetUserAsync(User);
        //    if (_user == null)
        //        return Unauthorized(); // أو أي معالجة مناسبة أخرى

        //    // إنشاء specification لتصفية التقنية بناءً على Id والتأكد من أن AppUserId يتطابق مع المستخدم الحالي
        //    var spec = new BaseSpecification<Driver>(e => e.Id == Id.Value && e.AppUserId == _user.Id);
        //    spec.Includes.Add(e => e.Category);

        //    // جلب التقنية باستخدام specification
        //    var Tech = _unitOfWork.Repository<Driver>().GetEntityWithSpec(spec);
        //    if (Tech is null)
        //        return NotFound();

        //    return View(viewname, (DriverViewModel)Tech);
        //}
        public IActionResult Edit(int? Id)
        {


            return Details(Id, nameof(Edit));

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int Id, DriverViewModel Driv)
        {
            if (Id != Driv.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(Driv);

            try
            {

                _unitOfWork.Repository<Driver>().Update((Driver)Driv);
                _unitOfWork.Complete();
                TempData["Message"] = "Driver Has been Updated Successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                if (env.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    ModelState.AddModelError(string.Empty, "An Error Has Occurred during Updating the Department");

                return View(Driv);
            }
        }
        public IActionResult Delete(int? Id)
        {

            return Details(Id, nameof(Delete));

        }

        [HttpPost]
        public IActionResult Delete(DriverViewModel Driv)
        {
            try
            {
                _unitOfWork.Repository<Driver>().Delete((Driver)Driv);
                _unitOfWork.Complete();
                TempData["Message"] = "Technicain Deleted Successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                
                if (env.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    ModelState.AddModelError(string.Empty, "An Error Has Occurred during Deleting the Department");

                return View(Driv);
            }
        }
    }




}  
    

	



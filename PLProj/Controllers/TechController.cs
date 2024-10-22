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
    public class TechController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<TechController> _logger;
        private readonly IWebHostEnvironment env;

        public TechController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IUnitOfWork unitOfWork,
            ILogger<TechController> logger, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
            _logger = logger;
            this.env = env;
        }

        public IActionResult Index()
        {
            
            var techs = _unitOfWork.Repository<Technician>().GetAll().Select(t => (TechnicianViewModel)t).ToList();
            return View(techs);


        }



        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(TechnicianViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new AppUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var technician = new TechnicianViewModel
                    {
                        AppUserId = user.Id,
                        Availability = model.Availability,
                        BirthDate = model.BirthDate,
                        CategoryId = model.CategoryId,    
                        Name = model.Name,
                        ContactNumber = model.ContactNumber,
                        Email = model.Email,
                        City = model.City,
                        Street = model.Street

                        
                        


                    };

                    _unitOfWork.Repository<Technician>().Add((Technician)technician);
                    _unitOfWork.Complete();

                    _logger.LogInformation("Technician created a new account with password.");

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
            var spec = new BaseSpecification<Technician>(e => e.Id == Id.Value);
            spec.Includes.Add(e => e.Category);
            var Tech = _unitOfWork.Repository<Technician>().GetEntityWithSpec(spec);
            if (Tech is null)
                return NotFound();

            return View(viewname, (TechnicianViewModel)Tech);
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
        //    var spec = new BaseSpecification<Technician>(e => e.Id == Id.Value && e.AppUserId == _user.Id);
        //    spec.Includes.Add(e => e.Category);

        //    // جلب التقنية باستخدام specification
        //    var Tech = _unitOfWork.Repository<Technician>().GetEntityWithSpec(spec);
        //    if (Tech is null)
        //        return NotFound();

        //    return View(viewname, (TechnicianViewModel)Tech);
        //}
        public IActionResult Edit(int? Id)
        {


            return Details(Id, nameof(Edit));

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int Id, TechnicianViewModel Tech)
        {
            if (Id != Tech.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(Tech);

            try
            {

                _unitOfWork.Repository<Technician>().Update((Technician)Tech);
                _unitOfWork.Complete();
                TempData["Message"] = "Technician Has been Updated Successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                if (env.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    ModelState.AddModelError(string.Empty, "An Error Has Occurred during Updating the Department");

                return View(Tech);
            }
        }
        public IActionResult Delete(int? Id)
        {

            return Details(Id, nameof(Delete));

        }

        [HttpPost]
        public IActionResult Delete(TechnicianViewModel Tech)
        {
            try
            {
                _unitOfWork.Repository<Technician>().Delete((Technician)Tech);
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

                return View(Tech);
            }
        }
    }




}  
    

	



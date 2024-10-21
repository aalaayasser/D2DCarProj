using BLLProject.Interfaces;
using DALProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
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

        public TechController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IUnitOfWork unitOfWork,
            ILogger<TechController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
            _logger = logger;
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
                    var technician = new Technician
                    {
                        AppUserId = user.Id,
                        Availability = model.Availability,
                        BirthDate = model.BirthDate,
                        CategoryId = model.CategoryId,
                        

                    };

                    _unitOfWork.Repository<Technician>().Add(technician);
                    _unitOfWork.Complete();

                    _logger.LogInformation("Technician created a new account with password.");

                    return RedirectToAction("");
                 
                }


                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
    }
}


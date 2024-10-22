using BLLProject.Interfaces;
using BLLProject.Specifications;
using DALProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PLProj.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PLProj.Controllers
{
	public class CarController : Controller
	{
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<HomeController> _logger;
		private readonly IUnitOfWork unitOfWork;
		public CarController(UserManager<AppUser> userManager, ILogger<HomeController> logger, IUnitOfWork unitOfWork)
		{
            _userManager = userManager;
            _logger = logger;
			this.unitOfWork = unitOfWork;
		}
		public IActionResult Car()
		{
			var spec = new BaseSpecification<Car>();
			spec.Includes.Add(e => e.Model);
			spec.Includes.Add(e => e.Model.Brand);
			spec.Includes.Add(e => e.Color);

			ViewData["Models"] = unitOfWork.Repository<Model>().GetAll();
			ViewData["Brands"] = unitOfWork.Repository<Brand>().GetAll();

			var models = unitOfWork.Repository<Car>().GetAllWithSpec(spec)
			.Select(m => (CarViewModel)m).ToList();
			return View(models);
		}

		public IActionResult CreateCar()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateCar(CarViewModel car)
		{

			var _user = await _userManager.GetUserAsync(User);
			var spec = new BaseSpecification<Customer>(c => c.AppUserId == _user.Id);
			var customer = unitOfWork.Repository<Customer>().GetEntityWithSpec(spec);

            if (ModelState.IsValid)
			{
				unitOfWork.Repository<Car>().Add((Car)car);
				var count = unitOfWork.Complete();
				if (count > 0)
				{
					TempData["message"] = "vehicle has been Added Successfully";
					return RedirectToAction("Index", "Home");
				}
			}
			return View(car);
		}

		[HttpGet]
		public IActionResult GetModelByBrands(int BrandId)
		{
			var spec = new BaseSpecification<Model>(e => e.BrandId == BrandId);
			var Models = unitOfWork.Repository<Model>().GetAllWithSpec(spec)
				.Select(e => new { Id = e.Id, Name = e.Name }).ToList();

			return new JsonResult(Models);
		}

		


	
	}
}

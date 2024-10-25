using BLLProject.Interfaces;
using BLLProject.Repositories;
using BLLProject.Specifications;
using DALProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace PLProj.Controllers
{
	public class BrandController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly ILogger<HomeController> _logger;
		private readonly IUnitOfWork unitOfWork;
		private readonly IWebHostEnvironment env;

		public BrandController(UserManager<AppUser> userManager, ILogger<HomeController> logger, IUnitOfWork unitOfWork, IWebHostEnvironment env)
		{
			_userManager = userManager;
			_logger = logger;
			this.unitOfWork = unitOfWork;
			this.env = env;
		}
		public IActionResult Index()
		{
			var Services = unitOfWork.Repository<Brand>().GetAll()
				.Select(s => (BrandViewModel)s).ToList();
			return View(Services);
		}
	}
}

using BLLProject.Interfaces;
using DALProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PLProj.Controllers
{
	public class PartsController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly ILogger<HomeController> _logger;
		private readonly IUnitOfWork unitOfWork;
		private readonly IWebHostEnvironment env;

		public PartsController(UserManager<AppUser> userManager, ILogger<HomeController> logger, IUnitOfWork unitOfWork, IWebHostEnvironment env)
		{
			_userManager = userManager;
			_logger = logger;
			this.unitOfWork = unitOfWork;
			this.env = env;
		}
		public IActionResult Index()
		{
			return View();
		}
	}
}

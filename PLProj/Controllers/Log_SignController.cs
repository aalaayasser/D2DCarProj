using BLLProject.Interfaces;
using BLLProject.Repositories;
using DALProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PLProj.Controllers
{
	public class Log_SignController : Controller
	{

		private readonly ILogger<HomeController> _logger;
		private readonly IUnitOfWork unitOfWork;
		public Log_SignController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
		{
			_logger = logger;
			this.unitOfWork = unitOfWork;
		}
		public IActionResult SignUp()
		{
			return View();

		}
		[HttpPost]
		public IActionResult SignUp(CustomerViewModel customer)
		{
			if (ModelState.IsValid)
			{
				unitOfWork.Repository<Customer>().Add((Customer)customer);
				var count = unitOfWork.Complete();
				if (count > 0)
				{
					TempData["message"] = "Sign Up Successfully";
					return RedirectToAction("Index", "Home");
				}
			}
			return View(customer);
		}
	}
}

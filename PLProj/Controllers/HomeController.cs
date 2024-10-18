using BLLProject.Interfaces;
using BLLProject.Specifications;
using DALProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PLProj.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PLProj.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IUnitOfWork unitOfWork;

		public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
		{
			_logger = logger;
			this.unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{
			return View();
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
					return RedirectToAction(nameof(Index));
				}
			}


			return View(customer);
		}

		//public ActionResult SelectModel()
		//{
		//	var spec = new BaseSpecification<Model>();
		//	spec.Includes.Add(e => e.Brand);

		//	var models = unitOfWork.Repository<Model>().GetAllWithSpec(spec)
		//	.Select(m => (ModelViewModel)m).ToList();
		//	return View(models);
		//}

		public ActionResult Car()
		{
			var spec = new BaseSpecification<Car>();
			spec.Includes.Add(e => e.Model);
			spec.Includes.Add(e => e.KiloMetres);
			spec.Includes.Add(e => e.Color);

			//var spec2 = new BaseSpecification<Model>();
			//spec2.Includes.Add(e => e.Brand);

			var models = unitOfWork.Repository<Car>().GetAllWithSpec(spec)
			.Select(m => (CarViewModel)m).ToList();
			return View(models);
		}

		[HttpPost]
		//public ActionResult SelectModel(int modelId)
		//{
		//	var parts = _partService.GetPartsByModel(modelId); 
		//	return View(parts);
		//}

		public IActionResult Book()
		{
			return View();
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}

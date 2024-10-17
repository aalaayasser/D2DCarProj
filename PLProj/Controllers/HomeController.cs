using BLLProject.Interfaces;
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

		public IActionResult SignUp ()
        {
            return View();

        }
        [HttpPost]
		  public IActionResult SignUp( CustomerViewModel customer)
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

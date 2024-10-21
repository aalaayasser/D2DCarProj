using BLLProject.Interfaces;
using BLLProject.Specifications;
using DALProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace PLProj.Controllers
{
    public class TechniciansController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork unitOfWork;
		private readonly IWebHostEnvironment env;
		public TechniciansController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            _logger = logger;
            this.unitOfWork = unitOfWork;
			this.env = env;
		}

        public IActionResult GetTechnical()
        {
            var technician = unitOfWork.Repository<Technician>().GetAll().Select(s => (TechnicianViewModel)s).ToList();
            return View(technician);
        }

        public IActionResult addTechnical(TechnicianViewModel technical)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Repository<Technician>().Add((Technician)technical);
                var count = unitOfWork.Complete();
                if (count > 0)
                {
                    TempData["Message"] = "Service has been Added Successfully";
                    return RedirectToAction(nameof(GetTechnical));
                }

            }

            return View(technical);
        }

		public IActionResult add()
		{
			return View();
		}
		[HttpPost]
		public IActionResult add(TechnicianViewModel technical)
		{
			if (ModelState.IsValid)
			{
				unitOfWork.Repository<Technician>().Add((Technician)technical);
				var count = unitOfWork.Complete();
				if (count > 0)
				{
					TempData["Message"] = "Service has been Added Successfully";
					return RedirectToAction(nameof(GetTechnical));
				}

			}
			return View(technical);
		}


		#region Details

		public IActionResult Details(int? Id, string viewName = "Details")
		{
			if (!Id.HasValue)
				return BadRequest();

			var spec = new BaseSpecification<Technician>
			(e => e.Id == Id.Value);
			spec.Includes.Add(e => e.Category);
			var service = unitOfWork.Repository<Technician>().GetEntityWithSpec(spec);

			if (service is null)
				return NotFound();

			return View(viewName, (TechnicianViewModel)service);
		}

		#endregion

		#region Edit

		public IActionResult Edit(int? Id)
		{
			return Details(Id, nameof(Edit));
		}

		[HttpPost]
		public IActionResult Edit(TechnicianViewModel emp)
		{
			if (!ModelState.IsValid)
				return View(emp);

			try
			{
				unitOfWork.Repository<Technician>().Update((Technician)emp);
				unitOfWork.Complete();
				TempData["message"] = "Service Updated Successfully";
				return RedirectToAction(nameof(GetTechnical));
			}
			catch (Exception ex)
			{
				if (env.IsDevelopment())
				{
					ModelState.AddModelError(string.Empty, ex.Message);
				}
				else
				{
					ModelState.AddModelError(string.Empty, "An Error Has Occurred during Updating the Employee");
				}
				return View(emp);
			}
		}

		#endregion

		#region Delete
		public IActionResult Delete(int? Id)
		{
			return Details(Id, nameof(Delete));
		}

		[HttpPost]
		public IActionResult Delete(TechnicianViewModel sev)
		{
			try
			{

				unitOfWork.Repository<Technician>().Delete((Technician)sev);
				unitOfWork.Complete();
				TempData["message"] = "Service Deleted Successfully";
				return RedirectToAction(nameof(GetTechnical));
			}
			catch (Exception ex)
			{

				if (env.IsDevelopment())
				{
					ModelState.AddModelError(string.Empty, ex.Message);
				}
				else
				{
					ModelState.AddModelError(string.Empty, "An Error Has Occurred during Deleted the Service");
				}
				return View(sev);
			}
		}
		#endregion
	}
}

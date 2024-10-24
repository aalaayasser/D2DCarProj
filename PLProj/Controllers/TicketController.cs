using BLLProject.Interfaces;
using BLLProject.Specifications;
using DALProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PLProj.Controllers
{
	public class TicketController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly ILogger<HomeController> _logger;
		private readonly IUnitOfWork unitOfWork;
		private readonly IWebHostEnvironment env;

		public TicketController(UserManager<AppUser> userManager, ILogger<HomeController> logger, IUnitOfWork unitOfWork, IWebHostEnvironment env)
		{
			_userManager = userManager;
			_logger = logger;
			this.unitOfWork = unitOfWork;
			this.env = env;
		}

		#region User
		[Authorize(Roles = "Customer")]
		public async Task<IActionResult> MyTicketAsync()
		{
			var _user = await _userManager.GetUserAsync(User);
			var spec = new BaseSpecification<Customer>(c => c.AppUserId == _user.Id);
			spec.Includes.Add(t => t.Cars);
			var customer = unitOfWork.Repository<Customer>().GetEntityWithSpec(spec);
			var myTicketList = customer.Cars.SelectMany(s => s.Tickets).ToList();

			//ViewData["Services"] = unitOfWork.Repository<Service>().GetAll();

			return View(myTicketList);
		}
		public async Task<IActionResult> AddTicketAsync()
		{

			var _user = await _userManager.GetUserAsync(User);
			var spec = new BaseSpecification<Customer>(c => c.AppUserId == _user.Id);
			spec.Includes.Add(t => t.Cars);
			var customer = unitOfWork.Repository<Customer>().GetEntityWithSpec(spec);
			var myCarList = customer.Cars;
			ViewData["CarList"] = myCarList;
			ViewData["Services"] = unitOfWork.Repository<Service>().GetAll();

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddTicketAsync(TicketViewModelCustomer ticket)
		{
			//var _user = await _userManager.GetUserAsync(User);
			//var spec = new BaseSpecification<Customer>(c => c.AppUserId == _user.Id);
			//spec.Includes.Add(t => t.Cars);
			//var customer = unitOfWork.Repository<Customer>().GetEntityWithSpec(spec);
			//ViewData["Services"] = unitOfWork.Repository<Service>().GetAll();

			//if (customer != null)
			//{
			//	if (customer.Cars.Any())
			//	{
			//		ViewData["CarsList"] = customer.Cars.Select(c => new SelectListItem
			//		{
			//			Value = c.Id.ToString(),
			//			Text = c.Model.Name
			//		}).ToList();
			//	}
			//	else
			//	{
			//		// رسالة خطأ إذا لم يكن هناك سيارات
			//		ModelState.AddModelError("", "No cars found for this customer.");
			//	}
			//}
			//else
			//{
			//	// رسالة خطأ إذا لم يتم العثور على العميل
			//	ModelState.AddModelError("", "Customer not found.");
			//}

			if (ModelState.IsValid)
			{
				

				try
				{
					
					unitOfWork.Repository<Ticket>().Add((Ticket)ticket);
					unitOfWork.Complete();
					TempData["Message"] = "Ticket has been Added Successfully";

					return RedirectToAction(nameof(Index));
				}
				catch (Exception ex)
				{
					
					if (env.IsDevelopment())
						ModelState.AddModelError(string.Empty, ex.Message);
					else
						ModelState.AddModelError(string.Empty, "An Error Has Occurred during Deleting the Employee");

					
				}
				
			}

			return View(ticket);
		}

		#endregion



		#region Admin => to manage opreations
		[Authorize(Roles = "Admin")]
		public IActionResult AllTicket()
		{


			return View();
		}
		#endregion

		#region Technician
		[Authorize(Roles = "Technician")]
		public IActionResult AssignedTicket()
		{


			return View();
		}
		#endregion

		public IActionResult Index()
		{



			var tickets = unitOfWork.Repository<Ticket>().GetAll().Select(c => new
			{
				CustomerViewModel = (TicketViewModelCustomer)c,
				TechnicianViewModel = (TicketViewModelTechnician)c
			}).ToList();

			return View(tickets);
		}


		public IActionResult CreateTechnician()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateTechnician(TicketViewModelTechnician ticket)
		{
			var _user = await _userManager.GetUserAsync(User);
			var spec = new BaseSpecification<Technician>(c => c.AppUserId == _user.Id);

			var tech = unitOfWork.Repository<Technician>().GetEntityWithSpec(spec);
			ViewData["Services"] = unitOfWork.Repository<Service>().GetAll();

			if (ModelState.IsValid)
			{
				ticket.Id = tech.Id;
				if (tech != null)
				{
					unitOfWork.Repository<Ticket>().Add((Ticket)ticket);
					var count = unitOfWork.Complete();
					if (count > 0)
					{
						TempData["message"] = "Ticket has been Added Successfully";
						return RedirectToAction("Index", "Ticket");
					}
				}

			}
			return View(ticket);
		}

	}
}

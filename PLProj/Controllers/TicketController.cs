using BLLProject.Interfaces;
using BLLProject.Specifications;
using DALProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
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
		public IActionResult Index()
		{ 
			
			var tickets = unitOfWork.Repository<Ticket>().GetAll().Select(c => new
			{
				CustomerViewModel = (TicketViewModelCustomer)c,
				TechnicianViewModel = (TicketViewModelTechnician)c
			}).ToList();

			return View(tickets);
		}
		
		public IActionResult CreateCustomer()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateTicketbyCustomer(TicketViewModelCustomer ticket)
		{
			var _user = await _userManager.GetUserAsync(User);
			var spec = new BaseSpecification<Customer>(c => c.AppUserId == _user.Id);
			spec.Includes.Add(t => t.Cars);
			var customer = unitOfWork.Repository<Customer>().GetEntityWithSpec(spec);
			ViewData["Services"] = unitOfWork.Repository<Service>().GetAll();

			if (customer != null)
			{
				if (customer.Cars.Any())
				{
					ViewData["CarsList"] = customer.Cars.Select(c => new SelectListItem
					{
						Value = c.Id.ToString(),
						Text = c.Model.Name
					}).ToList();
				}
				else
				{
					// رسالة خطأ إذا لم يكن هناك سيارات
					ModelState.AddModelError("", "No cars found for this customer.");
				}
			}
			else
			{
				// رسالة خطأ إذا لم يتم العثور على العميل
				ModelState.AddModelError("", "Customer not found.");
			}

			if (ModelState.IsValid)
			{
				// التحقق من صحة السيارة المختارة
				if (customer != null && customer.Cars.Any(c => c.Id == ticket.CarId))
				{
					unitOfWork.Repository<Ticket>().Add((Ticket)ticket);
					var count = unitOfWork.Complete();
					if (count > 0)
					{
						TempData["message"] = "Ticket has been Added Successfully";
						return RedirectToAction("Index", "Ticket");
					}
					else
					{
						// تسجيل خطأ إذا حدثت مشكلة في الحفظ
						ModelState.AddModelError("", "Error occurred while saving the ticket.");
					}
				}
				else
				{
					// رسالة خطأ إذا كانت السيارة غير صحيحة
					ModelState.AddModelError("", "Selected car is not valid.");
				}
			}

			return View(ticket);
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
				ticket.Id= tech.Id;
				if (tech != null )
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

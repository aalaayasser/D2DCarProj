using Microsoft.AspNetCore.Mvc;

namespace PLProj.Controllers
{
	public class BookController : Controller
	{
		public IActionResult Appointment()
		{
			return View();
		}
	}
}

using BLLProject.Interfaces;
using DALProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace PLProj.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ILogger<ServicesController> logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IWebHostEnvironment en;

        public ServicesController(ILogger<ServicesController> logger, IUnitOfWork unitOfWork, IWebHostEnvironment en)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
            this.en = en;
        }
        #region Get
        public IActionResult GetServices()
        {
            var Services = unitOfWork.Repository<Service>().GetAll().Select(s => (ServiceViewModel)s).ToList();
            return View(Services);
        }

        #endregion

        #region Create
        public IActionResult CreateService()
        {

            return View();
        }
        [HttpPost]
        public IActionResult CreateService(ServiceViewModel serv)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Repository<Service>().Add((Service)serv);
                var count = unitOfWork.Complete();
                if (count > 0)
                {
                    TempData["Message"] = "Service has been Added Successfully";
                    return RedirectToAction(nameof(GetServices));
                }

            }

            return View(serv);
        }

        #endregion


    }
}

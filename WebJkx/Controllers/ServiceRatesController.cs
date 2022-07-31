using Microsoft.AspNetCore.Mvc;
using Entities;
using Interfaces;
namespace WebJkx.Controllers
{
    public class ServiceRatesController : Controller
    {
        private readonly IServiceDAO serviceDAO;
        private readonly IRateDAO rateDAO;

        
        public ServiceRatesController(IServiceDAO serviceDAO, IRateDAO rateDAO)
        {
            this.serviceDAO = serviceDAO;
            this.rateDAO = rateDAO;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var services = serviceDAO.GetAll();

            return View(services);
        }
        
        [HttpGet]
        public IActionResult ShowRates(int id)
        {
            var service = serviceDAO.GetServiceById(id);

            var ratesOfService = rateDAO.GetServicesRates(service);

            if (ratesOfService.Count > 0)
            {
                return View(ratesOfService);
            }

            return RedirectToAction("NoRateError");
        }
        //______________________________________________________________________
        [HttpGet]
        public IActionResult AddRate(int id)
        {
            var rateViewModel = new Rate
            (

                "Тариф для "+serviceDAO.GetServiceById(id).Name,
                id,
                0,
                DateTime.Now,
                DateTime.Now
            );
            return View(rateViewModel);
        }

        [HttpPost]
        public IActionResult AddRate(Rate rate)
        {
            if (!ModelState.IsValid)
            {
                return View(rate);
            }
            var rateToInsert = new Rate
            (
                rate.Id,
                rate.Name,
                rate.ServiceId,
                rate.Price,
                rate.StartData,
                rate.EndData
            );
            //var rateToInsert = new Rate
            //{
            //    Id = rate.Id,
            //    Name = rate.Name,
            //    ServiceId = rate.ServiceId,
            //    Price = rate.Price,
            //    StartData = rate.StartData,
            //    EndData = rate.EndData
            //};

            rateDAO.Add(rateToInsert);

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult HaveRateError()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NoRateError()
        {
            return View();
        }

    }
}

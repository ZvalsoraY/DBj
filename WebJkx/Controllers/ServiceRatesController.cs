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
        
        //[HttpGet]
        //public IActionResult AddRate()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult AddRate(int ServiceId)
        //{
        //    // Model

        //    var addRate = new Rate
        //    {
        //        //ServiceId = Id
        //    };
        //    if (!ModelState.IsValid)
        //    {
        //        return View(addRate);
        //    }

        //    //var rateToInsert = new Rate
        //    //(
        //    //    rate.Id,
        //    //    rate.Name,
        //    //    rate.ServiceId,
        //    //    rate.Price,
        //    //    rate.StartData,
        //    //    rate.EndData
        //    //);

        //    rateDAO.Add(addRate);

        //    return RedirectToAction("Index");
        //}
        //[HttpGet]
        //public IActionResult AddRate(int Id)
        //{
        //    var service = serviceDAO.GetServiceById(Id);

        //    //var availableRates = rateDAO.GetServicesRates(service);

        //    var addRate = new Rate
        //    {
        //        ServiceId = service.Id
        //    };

        //    return View(addRate);
        //}
        //[HttpPost]
        //public IActionResult AddRate(int serviceId)
        //{
        //    var service = serviceDAO.GetUserById(serviceid);

        //    rateDAO.Add(service, rateid);

        //    return RedirectToAction("Index");

        //}
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



        //[HttpPost]
        //public IActionResult Delete(int id)
        //{
        //    var service = serviceDAO.GetAll().First(x => x.Id == id);

        //    serviceDAO.Delete(service);

        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public IActionResult Insert()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Insert(Service service)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(service);
        //    }

        //    var serviceToInsert = new Service
        //    (
        //        service.Id,
        //        service.Name
        //    );

        //    serviceDAO.Add(serviceToInsert);

        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public IActionResult Update(int id)
        //{
        //    var service = serviceDAO.GetAll().First(x => x.Id == id);

        //    var serviceViewModel = new Service
        //    (
        //        service.Id,
        //        service.Name
        //    );

        //    return View(serviceViewModel);
        //}

        //[HttpPost]
        //public IActionResult Update(Service service)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(service);
        //    }

        //    var serviceToUpdate = new Service
        //    {
        //        Id = service.Id,
        //        Name = service.Name
        //    };

        //    serviceDAO.Edit(serviceToUpdate);

        //    return RedirectToAction("Index");
        //}
    }
}

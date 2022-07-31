using Microsoft.AspNetCore.Mvc;
using Entities;
using Interfaces;
namespace WebJkx.Controllers
{
    public class ServiceCountersController : Controller
    {
        private readonly IServiceDAO serviceDAO;
        private readonly ICounterDAO counterDAO;

        
        public ServiceCountersController(IServiceDAO serviceDAO, ICounterDAO counterDAO)
        {
            this.serviceDAO = serviceDAO;
            this.counterDAO = counterDAO;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var services = serviceDAO.GetAll();

            return View(services);
        }
        
        [HttpGet]
        public IActionResult ShowCounters(int id)
        {
            var service = serviceDAO.GetServiceById(id);

            var countersOfService = counterDAO.GetServicesCounters(service);

            if (countersOfService.Count > 0)
            {
                return View(countersOfService);
            }

            return RedirectToAction("NoCounterError");
        }
        //______________________________________________________________________
        [HttpGet]
        public IActionResult AddCounter(int id)
        {
            var counterViewModel = new Counter
            (

                "Счетчик для "+serviceDAO.GetServiceById(id).Name,
                id,
                0,
                0,
                0,
                0,
                DateTime.Now
            );
            return View(counterViewModel);
        }

        [HttpPost]
        public IActionResult AddCounter(Counter counter)
        {
            if (!ModelState.IsValid)
            {
                return View(counter);
            }
            var counterToInsert = new Counter
            (
                counter.Id,
                counter.Name,
                counter.ServiceId,
                counter.SerialNumber,
                counter.Capacity,
                counter.DecimalCapacity,
                counter.InitialValue,
                counter.CreateData
            );
            counterDAO.Add(counterToInsert);

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult HaveCounterError()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NoCounterError()
        {
            return View();
        }

    }
}

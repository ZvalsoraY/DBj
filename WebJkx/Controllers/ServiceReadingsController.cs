using Microsoft.AspNetCore.Mvc;
using Entities;
using Interfaces;
namespace WebJkx.Controllers
{
    public class ServiceReadingsController : Controller
    {
        private readonly IServiceDAO serviceDAO;
        private readonly IReadingDAO readingDAO;

        
        public ServiceReadingsController(IServiceDAO serviceDAO, IReadingDAO readingDAO)
        {
            this.serviceDAO = serviceDAO;
            this.readingDAO = readingDAO;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var services = serviceDAO.GetAll();

            return View(services);
        }
        
        [HttpGet]
        public IActionResult ShowReadings(int id)
        {
            var service = serviceDAO.GetServiceById(id);

            var readingsOfService = readingDAO.GetServicesReadings(service);

            if (readingsOfService.Count > 0)
            {
                return View(readingsOfService);
            }

            return RedirectToAction("NoReadingError");
        }
        //______________________________________________________________________
        [HttpGet]
        public IActionResult AddReading(int id)
        {
            var readingViewModel = new Reading
            (

                id,
                0,
                DateTime.Now
            );
            return View(readingViewModel);
        }

        [HttpPost]
        public IActionResult AddReading(Reading reading)
        {
            if (!ModelState.IsValid)
            {
                return View(reading);
            }
            var readingToInsert = new Reading
            (
                reading.Id,
                reading.ServiceId,
                reading.CurValue,
                reading.TransDate
            );
            readingDAO.Add(readingToInsert);

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult HaveReadingError()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NoReadingError()
        {
            return View();
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Entities;
using Interfaces;
namespace WebJkx.Controllers
{
    public class ServiceReadingsController : Controller
    {
        private readonly IServiceDAO serviceDAO;
        private readonly IReadingDAO readingDAO;
        private readonly IRateDAO rateDAO;


        public ServiceReadingsController(IServiceDAO serviceDAO, IReadingDAO readingDAO, IRateDAO rateDAO)
        {
            this.serviceDAO = serviceDAO;
            this.readingDAO = readingDAO;
            this.rateDAO = rateDAO;
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

        [HttpGet]
        public IActionResult ShowDebt(int id)
        {
            var service = serviceDAO.GetServiceById(id);

            var readingsOfService = readingDAO.GetServicesReadings(service);

            var ratesOfService = rateDAO.GetServicesRates(service);
            double sumDept = 0;

            if (readingsOfService.Count > 0 && ratesOfService.Count > 0)
            {
                ratesOfService.OrderBy(d => d.EndData);
                for(int i = 0; i < ratesOfService.Count; i++)
                {
                    double readingIni = ratesOfService[i].ini;
                    double readingLast = 0;
                    int lastIndex = 0;
                    DateTime datePerem = DateTime.Now.AddYears(-150);
                    foreach(var r in readingsOfService)
                    {
                        if (r.TransDate < ratesOfService[i].EndData && r.TransDate > datePerem)
                        {
                            datePerem = r.TransDate;
                            readingLast = r.CurValue;
                        }
                    }
                    sumDept += (readingLast - readingIni) * ratesOfService[i].Price 
                }
                return View(readingsOfService);
            }



            //if (readingsOfService.Count > 0)
            //{
            //    return View(readingsOfService);
            //}

            return RedirectToAction("DebtError");
        }
    }
}

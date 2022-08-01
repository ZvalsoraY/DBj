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
        private readonly ICounterDAO counterDAO;


        public ServiceReadingsController(IServiceDAO serviceDAO, IReadingDAO readingDAO, IRateDAO rateDAO, ICounterDAO counterDAO)
        {
            this.serviceDAO = serviceDAO;
            this.readingDAO = readingDAO;
            this.rateDAO = rateDAO;
            this.counterDAO = counterDAO;
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
            var counterOfService = counterDAO.GetServicesCounters(service);

            double sumDept = 0;

            if (readingsOfService.Count > 0 && ratesOfService.Count > 0)
            {
                ratesOfService.OrderBy(d => d.EndData);
                for(int i = 0; i < ratesOfService.Count; i++)//проход по тарифам для услуги
                {
                    double readingIni = counterOfService.Last().InitialValue;
                    double readingLast = 0;
                    DateTime datePeremIni = counterOfService.Last().CreateData;
                    DateTime datePeremLast = DateTime.Now.AddYears(-150);
                    foreach(var r in readingsOfService)// проход по показаниям
                    {
                        if(r.TransDate < ratesOfService[i].StartData && r.TransDate > datePeremIni)
                        {
                            datePeremIni = r.TransDate;
                            readingIni = r.CurValue;
                        }
                        if (r.TransDate < ratesOfService[i].EndData && r.TransDate > datePeremLast)
                        {
                            datePeremLast = r.TransDate;
                            readingLast = r.CurValue;
                        }

                    }
                    sumDept += (readingLast - readingIni) * ratesOfService[i].Price; 
                }
                ViewData["SumDept"] = sumDept;
                return View(sumDept);
            }



            //if (readingsOfService.Count > 0)
            //{
            //    return View(readingsOfService);
            //}

            return RedirectToAction("DebtError");
        }
    }
}

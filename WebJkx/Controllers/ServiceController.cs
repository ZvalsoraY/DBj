using Microsoft.AspNetCore.Mvc;
using Entities;
using Interfaces;

namespace WebJkx.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceDAO serviceDAO;

        public ServiceController(IServiceDAO serviceDAO)
        {
            this.serviceDAO = serviceDAO;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var services = serviceDAO.GetAll();

            return View(services);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var service = serviceDAO.GetAll().First(x => x.Id == id);

            serviceDAO.Delete(service);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View(service);
            }

            var serviceToInsert = new Service
            (
                service.Id,
                service.Name
            );

            serviceDAO.Add(serviceToInsert);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var service = serviceDAO.GetAll().First(x => x.Id == id);

            var serviceViewModel = new Service
            (
                service.Id,
                service.Name
            );

            return View(serviceViewModel);
        }

        [HttpPost]
        public IActionResult Update(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View(service);
            }

            var serviceToUpdate = new Service
            {
                Id = service.Id,
                Name = service.Name
            };

            serviceDAO.Edit(serviceToUpdate);

            return RedirectToAction("Index");
        }
    }
}

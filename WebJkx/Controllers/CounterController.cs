using Microsoft.AspNetCore.Mvc;
using Entities;
using Interfaces;

namespace WebJkx.Controllers
{
    public class CounterController : Controller
    {
        private readonly ICounterDAO counterDAO;

        public CounterController(ICounterDAO counterDAO)
        {
            this.counterDAO = counterDAO;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var counters = counterDAO.GetAll();

            return View(counters);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var counter = counterDAO.GetAll().First(x => x.Id == id);

            counterDAO.Delete(counter);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Counter counter)
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
        public IActionResult Update(int id)
        {
            var counter = counterDAO.GetAll().First(x => x.Id == id);

            var counterViewModel = new Counter
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

            return View(counterViewModel);
        }

        [HttpPost]
        public IActionResult Update(Counter counter)
        {
            if (!ModelState.IsValid)
            {
                return View(counter);
            }

            var counterToUpdate = new Counter
            {
                Id = counter.Id,
                Name = counter.Name,
                ServiceId = counter.ServiceId,
                SerialNumber = counter.SerialNumber,
                Capacity = counter.Capacity,
                DecimalCapacity = counter.DecimalCapacity,
                InitialValue = counter.InitialValue,
                CreateData = counter.CreateData
            };

            counterDAO.Edit(counterToUpdate);

            return RedirectToAction("Index");
        }
    }
}

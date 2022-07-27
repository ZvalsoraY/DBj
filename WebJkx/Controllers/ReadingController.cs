using Microsoft.AspNetCore.Mvc;
using Entities;
using Interfaces;

namespace WebJkx.Controllers
{
    public class ReadingController : Controller
    {
        private readonly IReadingDAO readingDAO;

        public ReadingController(IReadingDAO readingDAO)
        {
            this.readingDAO = readingDAO;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var readings = readingDAO.GetAll();

            return View(readings);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var reading = readingDAO.GetAll().First(x => x.Id == id);

            readingDAO.Delete(reading);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Reading reading)
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
        public IActionResult Update(int id)
        {
            var reading = readingDAO.GetAll().First(x => x.Id == id);

            var readingViewModel = new Reading
            (
                reading.Id,
                reading.ServiceId,
                reading.CurValue,
                reading.TransDate
            );

            return View(readingViewModel);
        }

        [HttpPost]
        public IActionResult Update(Reading reading)
        {
            if (!ModelState.IsValid)
            {
                return View(reading);
            }

            var readingToUpdate = new Reading
            {
                Id = reading.Id,
                ServiceId = reading.ServiceId,
                CurValue = reading.CurValue,
                TransDate = reading.TransDate
            };

            readingDAO.Edit(readingToUpdate);

            return RedirectToAction("Index");
        }
    }
}

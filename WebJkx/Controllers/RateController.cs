using Microsoft.AspNetCore.Mvc;
using Entities;
using Interfaces;

namespace WebJkx.Controllers
{
    public class RateController : Controller
    {
        private readonly IRateDAO rateDAO;

        public RateController(IRateDAO rateDAO)
        {
            this.rateDAO = rateDAO;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var rates = rateDAO.GetAll();

            return View(rates);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var rate = rateDAO.GetAll().First(x => x.Id == id);

            rateDAO.Delete(rate);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Rate rate)
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

            rateDAO.Add(rateToInsert);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var rate = rateDAO.GetAll().First(x => x.Id == id);

            var rateViewModel = new Rate
            (
                rate.Id,
                rate.Name,
                rate.ServiceId,
                rate.Price,
                rate.StartData,
                rate.EndData
            );

            return View(rateViewModel);
        }

        [HttpPost]
        public IActionResult Update(Rate rate)
        {
            if (!ModelState.IsValid)
            {
                return View(rate);
            }

            var rateToUpdate = new Rate
            {
                Id = rate.Id,
                Name = rate.Name,
                ServiceId = rate.ServiceId,
                Price = rate.Price,
                StartData = rate.StartData,
                EndData = rate.EndData
            };

            rateDAO.Edit(rateToUpdate);

            return RedirectToAction("Index");
        }
    }
}

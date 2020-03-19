using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TransportCompany.Data;
using TransportCompany.Models.CodeFirst;
using X.PagedList;

namespace TransportCompany.Controllers
{
    public class CarModelController : Controller
    {
        private TransCompContext db;

        public CarModelController(TransCompContext context)
        {
            db = context;
        }

        public IActionResult Index(int? page, string searchModel)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 25;

            ViewData["searchModel"] = searchModel;

            IQueryable<CarModel> carModels = db.CarModels;

            if (!String.IsNullOrEmpty(searchModel))
            {
                carModels = carModels.Where(n => n.NameModel.Contains(searchModel));
            }

            carModels = carModels.OrderBy(i => i.Id);

            return View(carModels.ToPagedList(pageNumber, pageSize));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                db.CarModels.Add(carModel);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var carModel = db.CarModels.Find(id);
                return View(carModel);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                db.CarModels.Update(carModel);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var carModel = db.CarModels.Find(id);
                db.CarModels.Remove(carModel);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TransportCompany.Data;
using TransportCompany.Models.CodeFirst;
using X.PagedList;

namespace TransportCompany.Controllers
{
    public class CarController : Controller
    {
        private TransCompContext db;

        public CarController(TransCompContext context)
        {
            db = context;
        }

        public IActionResult Index(int? page, DateTime? searchYear)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 25;

            ViewData["searchYear"] = searchYear;

            IQueryable<Car> cars = db.Cars.Include(m => m.CarModel);

            if (searchYear.HasValue)
            {
                cars = cars.Where(y => y.YearCreation == searchYear);
            }

            cars = cars.OrderBy(i => i.Id);
            return View(cars.ToPagedList(pageNumber, pageSize));
        }

        public IActionResult Create()
        {
            ViewBag.CarModels = new SelectList(db.CarModels, "Id", "NameModel");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var car = db.Cars.Find(id);
                ViewBag.CarModels = new SelectList(db.CarModels, "Id", "NameModel", car.CarModelId);
                return View(car);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Update(car);
                db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var car = db.Cars.Find(id);
                db.Cars.Remove(car);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
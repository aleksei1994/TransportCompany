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
    public class TripController : Controller
    {
        private TransCompContext db;

        public TripController(TransCompContext context)
        {
            db = context;
        }
        public IActionResult Index(int? page, string searchOperator, string searchDriver)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 25;

            ViewData["searchOperator"] = searchOperator;
            ViewData["searchDriver"] = searchDriver;

            IQueryable<Trip> trips = db.Trips.Include(c => c.Car).
                                              Include(o => o.Operator).
                                              Include(d => d.Driver).
                                              Include(t => t.TariffPlan);

            if (!String.IsNullOrEmpty(searchOperator))
            {
                trips = trips.Where(o => o.Operator.FioStaff.Contains(searchOperator));
            }
            if (!String.IsNullOrEmpty(searchDriver))
            {
                trips = trips.Where(d => d.Driver.FioStaff.Contains(searchDriver));
            }

            trips = trips.OrderBy(i => i.Id);
            return View(trips.ToPagedList(pageNumber, pageSize));
        }

        public IActionResult Create()
        {
            ViewBag.Cars = new SelectList(db.Cars, "Id", "RegistrationNumber");
            ViewBag.Operators = new SelectList(db.Staffs.Where(s => s.Position.JobTitle.Contains("Оператор")), "Id", "FioStaff");
            ViewBag.Drivers = new SelectList(db.Staffs.Where(p => p.Position.JobTitle.Contains("Водитель")), "Id", "FioStaff");
            ViewBag.TariffPlans = new SelectList(db.TariffPlans, "Id", "TitlePlan");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Trip trip)
        {
            if (ModelState.IsValid)
            {
                db.Trips.Add(trip);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var trip = db.Trips.Find(id);
                ViewBag.Cars = new SelectList(db.Cars, "Id", "RegistrationNumber");
                ViewBag.Operators = new SelectList(db.Staffs.Where(s => s.Position.JobTitle.Contains("Оператор")), "Id", "FioStaff", trip.OperatorId);
                ViewBag.Drivers = new SelectList(db.Staffs.Where(p => p.Position.JobTitle.Contains("Водитель")), "Id", "FioStaff", trip.DriverId);
                ViewBag.TariffPlans = new SelectList(db.TariffPlans, "Id", "TitlePlan");

                return View(trip);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(Trip trip)
        {
            if (ModelState.IsValid)
            {
                db.Trips.Update(trip);
                db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var trip = db.Trips.Find(id);
                db.Trips.Remove(trip);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
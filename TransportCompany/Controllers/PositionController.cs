using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TransportCompany.Data;
using TransportCompany.Models.CodeFirst;
using X.PagedList;

namespace TransportCompany.Controllers
{
    public class PositionController : Controller
    {
        private TransCompContext db;

        public PositionController(TransCompContext context)
        {
            db = context;
        }

        public IActionResult Index(int? page, string searchPosition)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 25;
            ViewData["searchPosition"] = searchPosition;

            IQueryable<Position> positions = db.Positions;

            if (!String.IsNullOrEmpty(searchPosition))
            {
                positions = positions.Where(t => t.JobTitle.Contains(searchPosition));
            }

            return View(positions.ToPagedList(pageNumber, pageSize));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Position position)
        {
            if (ModelState.IsValid)
            {
                db.Positions.Add(position);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var position = db.Positions.Find(id);
                return View(position);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(Position position)
        {
            if (ModelState.IsValid)
            {
                db.Positions.Update(position);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var position = db.Positions.Find(id);
                if (!position.JobTitle.Contains("Водитель") && !position.JobTitle.Contains("Оператор"))
                {
                    db.Positions.Remove(position);
                }
                else
                {
                    var staffs = db.Staffs.Where(p => p.PositionId == id).Select(s => s.Id).ToList();
                    var tripsOperator = db.Trips.Where(o => staffs.Contains(o.OperatorId)).ToList();
                    var tripsDriver = db.Trips.Where(d => staffs.Contains(d.DriverId)).ToList();
                    if (tripsOperator.Count() <= 0 && tripsDriver.Count() <= 0)
                    {
                        db.Positions.Remove(position);
                    }
                }
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
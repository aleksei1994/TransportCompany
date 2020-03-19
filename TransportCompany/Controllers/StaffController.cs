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
    public class StaffController : Controller
    {
        private TransCompContext db;

        public StaffController(TransCompContext context)
        {
            db = context;
        }

        public IActionResult Index(int? page, string searchPosition)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 25;
            ViewData["searchPosition"] = searchPosition;

            IQueryable<Staff> staffs = db.Staffs.Include(p => p.Position);

            if (!String.IsNullOrEmpty(searchPosition))
            {
                staffs = staffs.Where(p => p.Position.JobTitle.Contains(searchPosition));
            }
            staffs = staffs.OrderBy(i => i.Id);

            return View(staffs.ToPagedList(pageNumber, pageSize));
        }

        public IActionResult Create()
        {
            ViewBag.Positions = new SelectList(db.Positions, "Id", "JobTitle");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Staffs.Add(staff);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var staff = db.Staffs.Find(id);
                ViewBag.Positions = new SelectList(db.Positions, "Id", "JobTitle", staff.PositionId);
                return View(staff);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Staffs.Update(staff);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var staff = db.Staffs.Find(id);
                if (db.Trips.Where(i => i.OperatorId == id).Count() <= 0 && db.Trips.Where(i => i.DriverId == id).Count() <= 0)
                {
                    db.Staffs.Remove(staff);
                    db.SaveChanges();
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
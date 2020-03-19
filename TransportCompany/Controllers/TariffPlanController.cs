using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TransportCompany.Data;
using TransportCompany.Models.CodeFirst;
using X.PagedList;

namespace TransportCompany.Controllers
{
    public class TariffPlanController : Controller
    {
        private TransCompContext db;

        public TariffPlanController(TransCompContext context)
        {
            db = context;
        }

        public IActionResult Index(int? page, string searchTitle)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 25;
            ViewData["searchTitle"] = searchTitle;

            IQueryable<TariffPlan> tariffPlans = db.TariffPlans;

            if (!String.IsNullOrEmpty(searchTitle))
            {
                tariffPlans = tariffPlans.Where(t => t.TitlePlan.Contains(searchTitle));
            }

            return View(tariffPlans.ToPagedList(pageNumber, pageSize));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TariffPlan tariffPlan)
        {
            if (ModelState.IsValid)
            {
                db.TariffPlans.Add(tariffPlan);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var tariffPlan = db.TariffPlans.Find(id);
                return View(tariffPlan);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(TariffPlan tariffPlan)
        {
            if (ModelState.IsValid)
            {
                db.TariffPlans.Update(tariffPlan);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var tariffPlan = db.TariffPlans.Find(id);
                db.TariffPlans.Remove(tariffPlan);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
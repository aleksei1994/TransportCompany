using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TransportCompany.Models;
using TransportCompany.Data;
using TransportCompany.Models.CodeFirst;

namespace TransportCompany.Controllers
{
    public class HomeController : Controller
    {
        private TransCompContext db;

        public HomeController(TransCompContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            db.Positions.Add(new Position { Id = 1, JobTitle = "1" });
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using diplom.Models;

namespace diplom.Controllers
{
    public  class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public static MyConnection db = new MyConnection();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View(db);
        }
        [HttpGet]
        public IActionResult Item(int lot)
        {

            return View(db.Lots.Where(x => x.lot_id == lot).FirstOrDefault());
        }
        [HttpPost]
        public string sendcomment(string text)
        {
            return $"Площадь треугольника с основанием {text} и высотой";
        }
        [HttpPost]
        public IActionResult Item()
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

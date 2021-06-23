using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using diplom.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace diplom.Controllers
{
    public  class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IWebHostEnvironment _appEnvironment;

        public static MyConnection db = new MyConnection();
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment appEnvironment)
        {
            _logger = logger;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateItem()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View(db);
        }
        [HttpGet]
        public IActionResult Privacy2(string category)
        {
            return View(db.Lots.Where(x=>x.lot_category==category));
        }
        [HttpGet]
        public IActionResult Item(int lot)
        {

            return View(db.Lots.Where(x => x.lot_id == lot).FirstOrDefault());
        }
        [HttpPost]
        public IActionResult sendcomment(string text,string login,int lot)
        {
            var user =db.Users.Where(x => x.user_email == login).FirstOrDefault();
            if(user!=null)
            {
                var comment = new Comment();
                comment.comm_date = DateTime.Now;
                comment.lot_id = lot;
                comment.user_id = user.user_id;
                comment.comm_id = db.Comments.Select(x => x.comm_id).Max() + 1;
                comment.comm_text = text;
                db.Comments.Add(comment);
                db.SaveChanges();
            }
            var reallot = db.Lots.Where(x => x.lot_id == lot).FirstOrDefault();
            return View("Item", reallot);
        }
        [HttpPost]
        public IActionResult createlot(string name,string category, string login, string text,IFormFile photo)
        {
            var user = db.Users.Where(x => x.user_email == login).FirstOrDefault();
            var lot = new Lot();
            if (user != null)
            {
                lot.lot_data = DateTime.Now;
                lot.lot_name = name;
                lot.lot_description = text;
                lot.lot_category = category;
                lot.user_id = user.user_id;
                lot.lot_id = db.Lots.Select(x => x.lot_id).Max() + 1;
                string path = "/images/" + photo.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    photo.CopyTo(fileStream);
                }
                lot.lot_photo = "~"+path;
                db.Lots.Add(lot);
                db.SaveChanges();
            }
            var reallot = db.Lots.Where(x => x.lot_id == lot.lot_id).FirstOrDefault();
            return View("Item", reallot);
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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Day_3.Models;

namespace Day_3.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context){
            dbContext = context;
        }
        public IActionResult Index()
        {
            List<Trail> allTrails = dbContext.Trails.ToList();
            return View("Index", allTrails);
        }

        [HttpGet("Trail/new")]
        public IActionResult addNewTrail(){
            return View();
        }

        [HttpPost("Trail/new")]
        public IActionResult createTrail(Trail newTrail){
            if(ModelState.IsValid){
                dbContext.Add(newTrail);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("addNewTrail");
        }

        [HttpGet("Trail/{trailId}")]
        public IActionResult ShowTrail(int trailId){
            Trail oneTrail = dbContext.Trails.FirstOrDefault(q =>q.TrailId == trailId);
            return View(oneTrail);
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

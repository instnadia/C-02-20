using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Day_1.Models;
using Microsoft.AspNetCore.Http;

namespace Day_1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.a="asdfasdf";
            return View("Index");
        }
        [HttpPost("Home/registration")]
        public IActionResult registration(ViewModel user){
            if(ModelState.IsValid){
                HttpContext.Session.SetString("UserName", user.registration.fname);
                HttpContext.Session.SetInt32("user_id",123123);
                return RedirectToAction("success");
            }
            return View("Index");
        }
        [HttpGet("Home/success")]
        public IActionResult success(){
            ViewBag.fname=HttpContext.Session.GetString("UserName");
            string a = null;
            int? b = HttpContext.Session.GetInt32("user_id");
            return View();
        }

        [HttpGet("Home/logout")]
        public IActionResult logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpPost("Home/login")]
        public IActionResult login(ViewModel user){
            if(ModelState.IsValid){
                return RedirectToAction("success");
            }
            return View("Index");
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

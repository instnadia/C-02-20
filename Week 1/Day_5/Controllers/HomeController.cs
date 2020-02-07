using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Day_5.Models;

namespace Day_5.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // [HttpPost("newQuote")]
        // public IActionResult quote(string quote, string author){
        //     ViewBag.quote = quote;
        //     ViewBag.name = author;
        //     return View("result");
        // }

        [HttpPost("newQuote")]
        public IActionResult quote(Quote acb){
            if(ModelState.IsValid){
                return View("result", acb);
            }
            return View("Index");
        }

        [HttpGet("listofstrings")]
        public IActionResult listofstring(){
            List<string> newList = new List<string>{"This","is", "from a","list"};
            return View("list", newList);
        }

        [HttpGet("listOfQuotes")]
        public IActionResult listofquotes(){
            List<Quote> quoteList = new List<Quote>();
            Quote a = new Quote();
            a.quote = "The way to get started is to quit talking and begin doing";
            a.author = "Walt Disney";
            Quote b = new Quote();
            b.quote = "Life is what happens when you're busy making other plans.";
            b.author = "John Lenon";
            Quote c = new Quote();
            c.quote = "You miss 100% of the shots you don't take.";
            c.author = "Wayne Gretzky -Michel Scott";
            quoteList.Add(a);
            quoteList.Add(b);
            quoteList.Add(c);
            return View("quotes", quoteList);
        }

        [HttpGet("astring")]
        public IActionResult astring(){
            string a="this is a string";
            return View("astring",a);
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

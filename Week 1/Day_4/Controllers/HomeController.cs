using Microsoft.AspNetCore.Mvc;
namespace lecture.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public string Index(){
            return "this is aspnet";
        }

        [HttpGet("user/{name}/{location}/{favorite_stack}")]
        public string StudInfo(string name, string location, string favorite_stack){
            return $"{name}'s worst stack is {favorite_stack} and is studying at {location}";
        }

        [HttpGet("fromhtml")]
        public IActionResult Show(){
            ViewBag.name="Nadia";
            return View("abc");
        }
            
        [HttpGet("click")]
        public IActionResult click(){
            return View("abc");
        }

        [HttpGet("redirect")]
        public IActionResult red(){
            return RedirectToAction("Index");
        }
    }
}
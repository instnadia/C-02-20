using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Day_5.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace Day_5.Controllers
{
    public class HomeController : Controller
    {
        private Context dbContext;
        public HomeController(Context context){
            dbContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("User/new")]
        public IActionResult registration(User newUser){
            if(ModelState.IsValid){
                if(dbContext.Users.FirstOrDefault(q=>q.email==newUser.email)!=null){
                    ModelState.AddModelError("email","Please log in");
                    return View("Index");
                }
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                newUser.password = hasher.HashPassword(newUser, newUser.password);
                dbContext.Add(newUser);
                dbContext.SaveChanges();
                HttpContext.Session.SetInt32("userId", newUser.UserId);
                return RedirectToAction("success");
            }
            return View("Index");
        }

        [HttpGet("User/success")]
        public IActionResult success(){ 
            if(HttpContext.Session.GetInt32("userId")==null){
                return RedirectToAction("Index");
            }
            int uid = (int)HttpContext.Session.GetInt32("userId");
            User user = dbContext.Users.FirstOrDefault(q=>q.UserId==uid);
            ViewBag.user = user;
            List<Post> allP = dbContext.Posts.ToList();
            ViewBag.allPosts = allP;
            return View();
        }

        [HttpPost("Post/new")]
        public IActionResult newPost(Post newPost){
            if(HttpContext.Session.GetInt32("userId")==null){
                return RedirectToAction("Index");
            }
            if(ModelState.IsValid){
                newPost.UserId = (int)HttpContext.Session.GetInt32("userId");
                dbContext.Add(newPost);
                dbContext.SaveChanges();
                return RedirectToAction("success");
            }
            User user = dbContext.Users.FirstOrDefault(q=>q.UserId==(int)HttpContext.Session.GetInt32("userId"));
            ViewBag.user = user;
            return View("success");
        }

        [HttpPost("Post/delete/{pId}")]
        public IActionResult delete(int pId){
            if(HttpContext.Session.GetInt32("userId")==null){
                return RedirectToAction("Index");
            }
            Post postToDelete = dbContext.Posts.FirstOrDefault(q=>q.PostId==pId);
            dbContext.Remove(postToDelete);
            dbContext.SaveChanges();
            return RedirectToAction("success");
        }

        [HttpGet("Login")]
        public IActionResult Login(){
            return View();
        }
        [HttpPost("User/login")]
        public IActionResult UserLogin(Login userLogin){
            if(ModelState.IsValid){
                User isInDb = dbContext.Users.FirstOrDefault(q=>q.email==userLogin.lemail);
                if(isInDb==null){
                    ModelState.AddModelError("lemail","Invalid cradentails");
                    return View("Login");
                }
                var hasher = new PasswordHasher<Login>();
                var result = hasher.VerifyHashedPassword(userLogin, isInDb.password, userLogin.lpassword);
                if(result==0){
                    ModelState.AddModelError("lemail","Invalid cradentails");
                    return View("Login");
                }
                HttpContext.Session.SetInt32("userId", isInDb.UserId);
                return RedirectToAction("success");
            }
            return View("Login");
        }

        [HttpGet("Post/edit/{pId}")]
        public IActionResult edit(int pId){
            Post postToEdit = dbContext.Posts.FirstOrDefault(q=>q.PostId==pId);
            return View(postToEdit);
        }

        [HttpPost("Post/edit/{pId}")]
        public IActionResult update(Post updated, int pId){
            Post postFromDb = dbContext.Posts.FirstOrDefault(q=>q.PostId==pId);
            postFromDb.Content = updated.Content;
            dbContext.SaveChanges();
            return RedirectToAction("success");
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

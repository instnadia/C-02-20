using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Day_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day_1.Controllers {
    public class HomeController : Controller {
        private Context dbContext;
        public HomeController (Context context) {
            dbContext = context;
        }
        public IActionResult Index () {
            return View ();
        }

        [HttpPost ("User/new")]
        public IActionResult registration (User newUser) {
            if (ModelState.IsValid) {
                if (dbContext.Users.FirstOrDefault (q => q.email == newUser.email) != null) {
                    ModelState.AddModelError ("email", "Please log in");
                    return View ("Index");
                }
                PasswordHasher<User> hasher = new PasswordHasher<User> ();
                newUser.password = hasher.HashPassword (newUser, newUser.password);
                dbContext.Add (newUser);
                dbContext.SaveChanges ();
                HttpContext.Session.SetInt32 ("userId", newUser.UserId);
                return RedirectToAction ("success");
            }
            return View ("Index");
        }

        [HttpGet ("Login")]
        public IActionResult Login () {
            return View ();
        }

        [HttpPost ("User/login")]
        public IActionResult UserLogin (Login userLogin) {
            if (ModelState.IsValid) {
                User isInDb = dbContext.Users.FirstOrDefault (q => q.email == userLogin.lemail);
                if (isInDb == null) {
                    ModelState.AddModelError ("lemail", "Invalid cradentails");
                    return View ("Login");
                }
                var hasher = new PasswordHasher<Login> ();
                var result = hasher.VerifyHashedPassword (userLogin, isInDb.password, userLogin.lpassword);
                if (result == 0) {
                    ModelState.AddModelError ("lemail", "Invalid cradentails");
                    return View ("Login");
                }
                HttpContext.Session.SetInt32 ("userId", isInDb.UserId);
                return RedirectToAction ("success");
            }
            return View ("Login");
        }

        [HttpGet ("User/success")]
        public IActionResult success () {
            if (HttpContext.Session.GetInt32 ("userId") == null) {
                return RedirectToAction ("Index");
            }

            int uid = (int) HttpContext.Session.GetInt32 ("userId");
            User user = dbContext.Users.FirstOrDefault (q => q.UserId == uid);
            List<Post> allP = dbContext.Posts.Include (q => q.Creator).Include(v=>v.Votes).ToList ();
            successModel model = new successModel ();
            model.userLogged = user;
            model.allP = allP;
            return View (model);
        }

        [HttpPost ("Post/new")]
        public IActionResult newPost (successModel newPost) {
            if (HttpContext.Session.GetInt32 ("userId") == null) {
                return RedirectToAction ("Index");
            }
            if (ModelState.IsValid) {
                newPost.post.UserId = (int) HttpContext.Session.GetInt32 ("userId");
                dbContext.Add (newPost.post);
                dbContext.SaveChanges ();
                return RedirectToAction ("success");
            }
            User user = dbContext.Users.FirstOrDefault (q => q.UserId == (int) HttpContext.Session.GetInt32 ("userId"));
            ViewBag.user = user;
            return View ("success");
        }

        [HttpPost ("Post/delete/{pId}")]
        public IActionResult delete (int pId) {
            if (HttpContext.Session.GetInt32 ("userId") == null) {
                return RedirectToAction ("Index");
            }
            Post postToDelete = dbContext.Posts.FirstOrDefault (q => q.PostId == pId);
            dbContext.Remove (postToDelete);
            dbContext.SaveChanges ();
            return RedirectToAction ("success");
        }

        [HttpGet ("Post/edit/{pId}")]
        public IActionResult edit (int pId) {
            Post postToEdit = dbContext.Posts.FirstOrDefault (q => q.PostId == pId);
            return View (postToEdit);
        }

        [HttpPost ("Post/edit/{pId}")]
        public IActionResult update (Post updated, int pId) {
            Post postFromDb = dbContext.Posts.FirstOrDefault (q => q.PostId == pId);
            postFromDb.Content = updated.Content;
            dbContext.SaveChanges ();
            return RedirectToAction ("success");
        }
        [HttpPost("Post/vote")]
        public IActionResult Vote(bool vote, int pId){
            if (HttpContext.Session.GetInt32 ("userId") == null) {
                return RedirectToAction ("Index");
            }
            Vote isVoted = dbContext.Votes.Where(p=>p.PostId==pId).FirstOrDefault(u=>u.UserId==HttpContext.Session.GetInt32 ("userId")); //checking if there is a vote on a post by user logged in
            if(isVoted==null){ // of there is no vote on the post by user, create one
                Vote newVote = new Vote();
                newVote.PostId = pId;
                newVote.IsUpvote = vote;
                newVote.UserId = (int)HttpContext.Session.GetInt32 ("userId");
                dbContext.Add(newVote);
                dbContext.SaveChanges();
                return RedirectToAction("success");
            }
            if(isVoted.IsUpvote==vote){ // if clicking on the same button again
                dbContext.Remove(isVoted);
            }else{ // clicking on the other button
                isVoted.IsUpvote = vote;
            }
            dbContext.SaveChanges();
            return RedirectToAction("success");
        }

        [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
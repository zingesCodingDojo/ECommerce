using System;
using System.Linq;
using ECommerce.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers{
    public class HammiesHomeController : Controller
{
        private HammyContext _waterFeeder;
        public HammiesHomeController(HammyContext stare){
            _waterFeeder = stare;
        }
    
        [HttpGet]
        [Route("HammiesHome")]
        public IActionResult HammiesHome(){
            ViewBag.Errors = new List<string>();
            if(HttpContext.Session.GetString("HammyID") != null){
                ViewBag.HammyLoggedIn = true;
            }
            if(HttpContext.Session.GetString("HammyName") != null){
                ViewBag.HamHamName = HttpContext.Session.GetString("HammyName");
            }
            else{
                ViewBag.HamHamName = null;
            }
            List<HammyBlog> allBlogs = _waterFeeder.HammyBlog.OrderByDescending( day => day.BlogCreated_At).Include( ham => ham.Hamster ).ToList();
            ViewBag.allBlogs = allBlogs;
            
            List<BlogLike> allLikes = _waterFeeder.BlogLike.ToList();
            ViewBag.allLikes = allLikes;

            ViewBag.myId = HttpContext.Session.GetString("HammyID");
            return View("HammiesHome");
        }
        
        [HttpGet]
        [Route("logoff")]
        public IActionResult Logoff(){
            HttpContext.Session.Clear();
            return RedirectToAction("HammiesHome");
        }
        
        [HttpGet]
        [Route("hammieSettings")]
        public IActionResult HammieSettings(){
            return RedirectToAction("MySettings", "HammieSettings");
        }

        [HttpGet]
        [Route("goLogin")]
        public IActionResult GoLogIn(){
            return RedirectToAction("LoginHome", "Login");
        }

        [HttpPost]
        [Route("likeThatBlog/{myId}/{blogId}")]
        public IActionResult LikeThatBlog(string myId, int blogId){
            if(myId == null){
                return RedirectToAction("HammiesHome");
            }
            BlogLike hammyLikeBlog = new BlogLike{
                BlogId = blogId,
                HamsterId = myId,
                LikeCreated_At = DateTime.Now,
                LikeUpdated_At = DateTime.Now
            };
            _waterFeeder.Add(hammyLikeBlog);
            _waterFeeder.SaveChanges();
            return RedirectToAction("HammiesHome"); 
        }

        [HttpGet]
        [Route("hammieBlog")]
        public IActionResult HammiesBlog(){
            ViewBag.Errors = new List<string>();
            if(HttpContext.Session.GetString("HammyID") != null){
                ViewBag.HammyLoggedIn = true;
            }
            if(HttpContext.Session.GetString("HammyName") != null){
                ViewBag.HamHamName = HttpContext.Session.GetString("HammyName");
            }
            else{
                ViewBag.HamHamName = null;
            }
            return View("HammiesBlog");
        }
        

        [HttpPost]
        [Route("newBlog")]
        public IActionResult NewBlog(HammyBlog newBlog){
            if(HttpContext.Session.GetString("HammyID") != null){
                ViewBag.HammyLoggedIn = true;
            }
            if(HttpContext.Session.GetString("HammyName") != null){
                ViewBag.HamHamName = HttpContext.Session.GetString("HammyName");
            }
            else{
                ViewBag.HamHamName = null;
            }
            Hamster gimmeCard = _waterFeeder.Hamster.SingleOrDefault( cc => cc.HamsterId == HttpContext.Session.GetString("HammyID"));
            if(gimmeCard == null){
                return RedirectToAction("RegistrationHome", "Registration");
            }
            if(ModelState.IsValid){
                HammyBlog addingBlog = new HammyBlog{
                    BlogTitle = newBlog.BlogTitle,
                    BlogContent = newBlog.BlogContent,
                    BlogCreated_At = DateTime.Now,
                    BlogUpdated_At = DateTime.Now,
                    HamsterId = gimmeCard.HamsterId
                };
                _waterFeeder.Add(addingBlog);
                _waterFeeder.SaveChanges();
                return RedirectToAction("HammiesHome", "HammiesHome");
            }
            ViewBag.Errors = ModelState.Values;
            return View("HammiesBlog");
        }
    }
}

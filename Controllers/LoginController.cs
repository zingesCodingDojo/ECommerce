using System;
using System.Linq;
using ECommerce.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Controllers{
    public class LoginController : Controller{
        private HammyContext _waterFeeder;
        public LoginController(HammyContext stare){
            _waterFeeder = stare;
        }
    
        [HttpGet]
        [Route("login")]
        public IActionResult LoginHome(){
            ViewBag.LoginErrors = new List<string>();
            return View("Login");
        }

        [HttpPost]
        [Route("loginHammy")]
        public IActionResult LoginHammy(string HamsterEmail, string HamsterPassword){
            ViewBag.LoginErrors = new List<string>();
            if(HamsterEmail == null){
                ViewBag.LoginErrors.Add("Hammy Email cannot be empty!");
            }
            if(HamsterPassword == null){
                ViewBag.LoginErrors.Add("Hammy Password cannot be empty!");
            }
            else{
                Hamster myHammy = _waterFeeder.Hamster.SingleOrDefault( my => my.HamsterEmail == HamsterEmail);
                var Hasher = new PasswordHasher<Hamster>();
                if(myHammy == null){
                    ViewBag.LoginErrors.Add("Hammy detects an invalid Email/Password Combination!");
                }
                else if(0 != Hasher.VerifyHashedPassword(myHammy, myHammy.HamsterPassword, HamsterPassword)){
                    HttpContext.Session.SetString("HammyID", myHammy.HamsterId);
                    string HammyNamedString = myHammy.HamsterFirstName + " " + myHammy.HamsterLastName;
                    HttpContext.Session.SetString("HammyName", HammyNamedString);
                    return RedirectToAction("HammiesHome", "HammiesHome");
                }
                else{
                    ViewBag.LoginErrors.Add("Hammy detects an invalid Email/Password Combination!");
                }
            }
            return View("Login");
        }

    }
}

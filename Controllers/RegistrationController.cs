using System;
using System.Linq;
using ECommerce.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Controllers{
    public class RegistrationController : Controller{
        private HammyContext _waterFeeder;
        public RegistrationController(HammyContext stare){
            _waterFeeder = stare;
        }
    
        [HttpGet]
        [Route("registration")]
        public IActionResult RegistrationHome(string secretCodeName, string secretID){
            ViewBag.Errors = new List<string>();
            
            System.Console.WriteLine(secretCodeName);
            return View("RegistrationHome");
        }

        [HttpPost]
        [Route("registerHammy")]
        public IActionResult RegusterHammy(RegisterHamsterModel regHamster){
            ViewBag.Errors = new List<string>();
            if(ModelState.IsValid){
                if(_waterFeeder.Hamster.SingleOrDefault( ping => ping.HamsterEmail == regHamster.HamsterEmail) == null){
                    PasswordHasher<Hamster> Secret = new PasswordHasher<Hamster>();
                    ECommerce.Models.Hamster newHammy = new ECommerce.Models.Hamster{
                        HamsterFirstName = regHamster.HamsterFirstName,
                        HamsterLastName = regHamster.HamsterLastName,
                        HamsterEmail = regHamster.HamsterEmail,
                        HamsterCreated_At = DateTime.Now,
                        HamsterUpdated_At = DateTime.Now
                    };
                    newHammy.HamsterPassword = Secret.HashPassword(newHammy, regHamster.HamsterPassword);
                    _waterFeeder.Add(newHammy);
                    _waterFeeder.SaveChanges();
                    return RedirectToAction("LoginHome", "Login");
                }
                else{
                    ViewBag.EmailError = "Hammy apologizes, but that email is not available!";
                    return View("RegistrationHome");
                }
            }
            ViewBag.Errors = ModelState.Values;
            return View("RegistrationHome");
        }
    }
}

using System;
using System.Linq;
using ECommerce.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Controllers
{
    public class HammiesController : Controller
    {
        private readonly UserManager<Hamster> _hammyManager;
        private readonly SignInManager<Hamster> _hammysignInManager;
        private HammyContext _waterFeeder;
        public HammiesController(HammyContext stare, UserManager<Hamster> _hammanager, SignInManager<Hamster> _signinmanager)
        {
            _waterFeeder = stare;
            _hammyManager = _hammanager;
            _hammysignInManager = _signinmanager;
            
        }
    
        [HttpGet]
        [Route("hammies")]
        public IActionResult Hammies()
        {
            ViewBag.Errors = new List<string>();
            return View("Hammies");
        }

        [HttpPost]
        [Route("registerHammy")]
        public IActionResult RegisterHammy(RegisterHamsterModel regHamster){
            if(ModelState.IsValid){
                System.Console.WriteLine("HAMSTER MODEL IS VALID");
                System.Console.WriteLine("HAMSTER MODEL IS VALID");
                System.Console.WriteLine("HAMSTER MODEL IS VALID");
                System.Console.WriteLine("HAMSTER MODEL IS VALID");
                ECommerce.Models.RegisterHamsterModel newHammy = new ECommerce.Models.RegisterHamsterModel{
                    HamsterFirstName = regHamster.HamsterFirstName,
                    HamsterLastName = regHamster.HamsterLastName,
                    HamsterEmail = regHamster.HamsterEmail,
                    HamsterPassword = regHamster.HamsterPassword
                };
                _waterFeeder.Add(newHammy);
                _waterFeeder.SaveChanges();
                return RedirectToAction("Hammies");
            }
            ViewBag.Errors = ModelState.Values;
            return View()
        }
    }
}

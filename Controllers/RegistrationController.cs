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
        private readonly UserManager<Hamster> _hammyManager;
        private readonly SignInManager<Hamster> _hammysignInManager;
        private HammyContext _waterFeeder;
        public RegistrationController(HammyContext stare, UserManager<Hamster> _hammanager, SignInManager<Hamster> _signinmanager){
            _waterFeeder = stare;
            _hammyManager = _hammanager;
            _hammysignInManager = _signinmanager;
        }
    
        [HttpGet]
        [Route("registration")]
        public IActionResult RegistrationHome(){
            ViewBag.Errors = new List<string>();
            return View("RegistrationHome");
        }

        [HttpPost]
        [Route("registerHammy")]
        public async Task<IActionResult> Method(RegisterHamsterModel regHamster){
            ViewBag.Errors = new List<string>();
            if(ModelState.IsValid){
                System.Console.WriteLine("HAMSTER MODEL IS VALID");
                System.Console.WriteLine("HAMSTER MODEL IS VALID");
                System.Console.WriteLine("HAMSTER MODEL IS VALID");
                System.Console.WriteLine("HAMSTER MODEL IS VALID");
                ECommerce.Models.Hamster newHammy = new ECommerce.Models.Hamster{
                    HamsterFirstName = regHamster.HamsterFirstName,
                    HamsterLastName = regHamster.HamsterLastName,
                    HamsterEmail = regHamster.HamsterEmail,
                };
                IdentityResult hammyResult = await _hammyManager.CreateAsync(newHammy, regHamster.HamsterPassword);
                if(hammyResult.Succeeded){
                    System.Console.WriteLine("HAMSTER IS SUCCEEDEEEDDIIINNG");
                    System.Console.WriteLine("HAMSTER IS SUCCEEDEEEDDIIINNG");
                    System.Console.WriteLine("HAMSTER IS SUCCEEDEEEDDIIINNG");
                    System.Console.WriteLine("HAMSTER IS SUCCEEDEEEDDIIINNG");
                    System.Console.WriteLine("HAMSTER IS SUCCEEDEEEDDIIINNG");
                    await _hammysignInManager.SignInAsync(newHammy, isPersistent: false);
                }
                foreach( var error in hammyResult.Errors ){
                    System.Console.WriteLine("Errors FOund");
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                _waterFeeder.Add(newHammy);
                _waterFeeder.SaveChanges();
                return RedirectToAction("RegistrationHome");
            }
            ViewBag.Errors = ModelState.Values;
            return View("RegistrationHome");
        }
    }
}

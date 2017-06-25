using System;
using System.Linq;
using ECommerce.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ECommerce.Controllers
{
    public class IglooController : Controller
    {
        private HammyContext _waterFeeder;
 
        public IglooController(HammyContext stare)
        {
            _waterFeeder = stare;
        }
    
        [HttpGet]
        [Route("")]
        public IActionResult WakeUp()
        {
            return RedirectToAction("HammyControl");
        }

        [HttpGet]
        [Route("myHome")]
        public IActionResult HammyControl()
        {
            return View("CottonView");
        }

        [HttpGet]
        [Route("hammyGoodies")]
        public IActionResult HammyGoodies(){

            return RedirectToAction("FoodBowl", "FoodBowl");
        }
    }
}

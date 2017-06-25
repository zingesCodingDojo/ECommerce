using System;
using System.Linq;
using ECommerce.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ECommerce.Controllers
{
    public class FoodBowlController : Controller
    {
        private HammyContext _waterFeeder;
 
        public FoodBowlController(HammyContext stare)
        {
            _waterFeeder = stare;
        }
    
        [HttpGet]
        [Route("foodBowl")]
        public IActionResult FoodBowl()
        {
            return View("FoodBowl");
        }

    }
}

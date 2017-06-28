using System;
using System.Linq;
using ECommerce.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ECommerce.Controllers{
    public class HammiesController : Controller
{
        private HammyContext _waterFeeder;
        public HammiesController(HammyContext stare){
            _waterFeeder = stare;
        }
    
        [HttpGet]
        [Route("hammies")]
        public IActionResult Hammies(){
            ViewBag.Errors = new List<string>();
            return View("Hammies");
        }
    }
}

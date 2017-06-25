using System;
using System.Linq;
using ECommerce.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ECommerce.Controllers
{
    public class WheelController : Controller
    {
        private HammyContext _waterFeeder;
 
        public WheelController(HammyContext stare)
        {
            _waterFeeder = stare;
        }
    
        [HttpGet]
        [Route("wheel")]
        public IActionResult Wheel()
        {
            return View("Wheel");
        }

    }
}

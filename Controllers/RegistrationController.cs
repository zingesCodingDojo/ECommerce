using System;
using System.Linq;
using ECommerce.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ECommerce.Controllers
{
    public class RegistrationController : Controller
    {
        private HammyContext _waterFeeder;
        public RegistrationController(HammyContext stare)
        {
            _waterFeeder = stare;
        }
    
        [HttpGet]
        [Route("registration")]
        public IActionResult RegistrationHome()
        {
            return View("RegistrationHome");
        }

    }
}

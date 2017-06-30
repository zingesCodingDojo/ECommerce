using System;
using System.Linq;
using ECommerce.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Controllers{
    public class HammieShopController : Controller
{
        private HammyContext _waterFeeder;
        public HammieShopController(HammyContext stare){
            _waterFeeder = stare;
        }
    
        [HttpGet]
        [Route("hammieShop")]
        public IActionResult HammieShop(){
            ViewBag.Errors = new List<string>();
            if(HttpContext.Session.GetString("HammyID") != null){
                ViewBag.HammyLoggedIn = true;
            }
            
            return View("HammieShop");
        }
    }
}
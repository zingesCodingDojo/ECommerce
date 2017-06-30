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
            ViewBag.Errors = new List<string>();
            return View("FoodBowl");
        }

        [HttpPost]
        [Route("addFood")]
        public IActionResult AddFood(RegisterGoodieModel newGoodie){
            ViewBag.Errors = new List<string>();
            if(ModelState.IsValid){
                Goodie addingGoodie = new Goodie{
                    GoodieName = newGoodie.GoodieName,
                    GoodieDescription = newGoodie.GoodieDescription,
                    GoodieImageURL = newGoodie.GoodieImageURL,
                    GoodiePrice = newGoodie.GoodiePrice,
                    GoodieQuantity = newGoodie.GoodieQuantity,
                    GoodieCreated_At = DateTime.Now,
                    GoodieUpdated_At = DateTime.Now,
                    GoodiePopularity = 1
                };
                _waterFeeder.Add(addingGoodie);
                _waterFeeder.SaveChanges();
                return RedirectToAction("FoodBowl");
            }
            ViewBag.Errors = ModelState.Values;
            return View("FoodBowl");
        }
    }
}

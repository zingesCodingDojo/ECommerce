using System;
using System.Linq;
using ECommerce.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
            if(HttpContext.Session.GetString("HammyName") != null){
                ViewBag.HamHamName = HttpContext.Session.GetString("HammyName");
            }
            else{
                ViewBag.HamHamName = null;
            }
            List<Goodie> allGoodies = _waterFeeder.Goodie.Include( wish => wish.HammyWishList).Include( com => com.Comment).ToList();
            ViewBag.allGoodies = allGoodies;
            return View("HammieShop");
        }

        [HttpGet]
        [Route("singleItem/{id}")]
        public IActionResult SingleItem(int id){
            ViewBag.Wishie = null;
            if(HttpContext.Session.GetString("HammyID") != null){
                ViewBag.HammyLoggedIn = true;
            }
            if(HttpContext.Session.GetString("HammyName") != null){
                ViewBag.HamHamName = HttpContext.Session.GetString("HammyName");
            }
            else{
                ViewBag.HamHamName = null;
            }
            Goodie myGoodie = _waterFeeder.Goodie.SingleOrDefault( myitem => myitem.GoodieId == id);
            List<HammyWishList> pingDataBase = _waterFeeder.HammyWishList.Where(goodie => goodie.GoodieId == id).Include(ham => ham.Hamster).ToList();
            foreach(var item in pingDataBase){
                if(item.HamsterId == HttpContext.Session.GetString("HammyID")){
                    ViewBag.Wishie = "Already Wishlist Item";
                    ViewBag.remove = "Remove From Wishlist";
                }
            }
            
            ViewBag.myGoodie = myGoodie;
            return View("SingleItem");
        }

        [HttpPost]
        [Route("addToWishList/{id}")]
        public IActionResult AddToWishList(int id){
            ViewBag.remove = null;
            ViewBag.Wishie = null;
            if(HttpContext.Session.GetString("HammyID") == null){
                return RedirectToAction("SingleItem", "HammieShop", new { id = id});
            }
            List<HammyWishList> pingDataBase = _waterFeeder.HammyWishList.Where( goodie => goodie.GoodieId == id).Include( ham => ham.Hamster).ToList();
            if(pingDataBase.Count < 1){
                HammyWishList newWishListItem = new HammyWishList{
                    HamsterId = HttpContext.Session.GetString("HammyID"),
                    GoodieId = id,
                    HammyWishListCreated_At = DateTime.Now,
                    HammyWishListUpdated_At = DateTime.Now
                };
                _waterFeeder.Add(newWishListItem);
                _waterFeeder.SaveChanges();
                return RedirectToAction("SingleItem", "HammieShop", new { id = id });
            }
            foreach(var item in pingDataBase){
                if(item.HamsterId == HttpContext.Session.GetString("HammyID")){
                    break;
                }
                else{
                    HammyWishList newWishListItem = new HammyWishList{
                        HamsterId = HttpContext.Session.GetString("HammyID"),
                        GoodieId = id,
                        HammyWishListCreated_At = DateTime.Now,
                        HammyWishListUpdated_At = DateTime.Now
                    };
                    _waterFeeder.Add(newWishListItem);
                    _waterFeeder.SaveChanges();
                    return RedirectToAction("SingleItem", "HammieShop", new { id = id });
                }
            }
            ViewBag.Wishie = "You have already added this item to your Wishlist!";
            return RedirectToAction("SingleItem", "HammieShop", new { id = id });
        }
        
        [HttpPost]
        [Route("removeFromWishList/{id}")]
        public IActionResult RemoveFromWishList(int id){
            List<HammyWishList> pingDataBase = _waterFeeder.HammyWishList.Where( goodie => goodie.GoodieId == id).Include( ham => ham.Hamster).ToList();
            foreach(var item in pingDataBase){
                if(item.HamsterId == HttpContext.Session.GetString("HammyID")){
                    _waterFeeder.Remove(item);
                }
            }
            _waterFeeder.SaveChanges();
            return RedirectToAction("SingleItem", "HammieShop", new { id = id });
        }
    }
}
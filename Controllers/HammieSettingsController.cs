using System;
using System.Linq;
using ECommerce.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;

namespace ECommerce.Controllers{
    public class HammieSettingsController : Controller
{
        private HammyContext _waterFeeder;
        public HammieSettingsController(HammyContext stare){
            _waterFeeder = stare;
        }
    
        [HttpGet]
        [Route("mySettings")]
        public IActionResult MySettings(){
            if(HttpContext.Session.GetString("HammyID") == null){
                return RedirectToAction("RegistrationHome", "Registration");
            }
            else{
                ViewBag.HammyLoggedIn = true;
            }
            // Get Hamster CC
            var gimmeCard = _waterFeeder.HamsterCreditCard.SingleOrDefault( cc => cc.HamsterId == HttpContext.Session.GetString("HammyID"));
            if(gimmeCard != null){
                ViewBag.ValidCC = 1;
            }
            ViewBag.Errors = new List<string>();

            return View("HammieSettings");
        }
        
        [HttpPost]
        [Route("changeHammie")]
        public IActionResult ChangeHammie(Hamster changeHammie){
            var gimmeCard = _waterFeeder.HamsterCreditCard.SingleOrDefault( cc => cc.HamsterId == HttpContext.Session.GetString("HammyID"));
            if(gimmeCard != null){
                ViewBag.ValidCC = 1;
            }
            ViewBag.Errors = new List<string>();
            Hamster currentHamster = _waterFeeder.Hamster.SingleOrDefault( curr => curr.HamsterId == HttpContext.Session.GetString("HammyID"));
            if(changeHammie.HamsterFirstName != null){
                if(changeHammie.HamsterFirstName.Length > 2){
                    currentHamster.HamsterFirstName = changeHammie.HamsterFirstName;
                    }
                else{
                    ViewBag.Errors.Add("Hammy First Name cannot be less than 2 characters!");
                }
            }
            
            if(changeHammie.HamsterLastName != null){
                if(changeHammie.HamsterLastName.Length > 2){
                    currentHamster.HamsterLastName = changeHammie.HamsterLastName;
                }
                else{
                    ViewBag.Errors.Add("Hammy Last Name cannot be less than 2 characters!");
                }
            }
            
            if(changeHammie.HamsterUserName != null){
                if(changeHammie.HamsterUserName.Length > 8){
                    currentHamster.HamsterUserName = changeHammie.HamsterUserName;
                }
                else{
                    ViewBag.Errors.Add("Hammy Username needs to be 8 characters or longer!");
                }
            }

            if(changeHammie.HamsterAddress != null){
                if(changeHammie.HamsterAddress.Length > 5){
                    currentHamster.HamsterAddress = changeHammie.HamsterAddress;
                }
                else{
                    ViewBag.Errors.Add("Hammie Address needs to be longer than 5 characters!");
                }
            }
            
            if(changeHammie.HamsterCity != null){
                if(changeHammie.HamsterCity.Length > 4){
                    currentHamster.HamsterCity = changeHammie.HamsterCity;
                }
                else{
                    ViewBag.Errors.Add("Hammie City needs to be longer than 4 characters!");
                }
            }
            
            if(changeHammie.HamsterState != null){
                currentHamster.HamsterState = changeHammie.HamsterState;
            }
            if(changeHammie.HamsterZip != null){
                currentHamster.HamsterZip = changeHammie.HamsterZip;
            }
            int? tempPhone = changeHammie.HamsterPhoneNumber;
            if(tempPhone != null){
                currentHamster.HamsterPhoneNumber = changeHammie.HamsterPhoneNumber;
            }
            System.Console.WriteLine(ViewBag.Errors.Count);
            System.Console.WriteLine(ViewBag.Errors.Count);
            System.Console.WriteLine(ViewBag.Errors.Count);
            if(ViewBag.Errors.Count == 0){
                currentHamster.HamsterUpdated_At = DateTime.Now;
                _waterFeeder.SaveChanges();
                return RedirectToAction("HammiesHome", "HammiesHome");
            }
            
            return View("HammieSettings");
        }

        [HttpPost]
        [Route("hammyCC")]
        public IActionResult HammyCC(string HammyCCNumber, string HammyCCDate, string HammyCCCvn){
            ViewBag.Errors = new List<string>();
            
            var cardCheck = new Regex(@"^(1298|1267|4512|4567|8901|8933)([\-\s]?[0-9]{4}){3}$");
            var monthCheck = new Regex(@"^(0[1-9]|1[0-2])$");
            var yearCheck = new Regex(@"^20[0-9]{2}$");
            var cvvCheck = new Regex(@"^\d{3}$");
            var cardExpiry = new DateTime();
            if(String.IsNullOrEmpty(HammyCCNumber)){
                ViewBag.CC = "Credit Card cannot be empty!";
            }
            else if(!cardCheck.IsMatch(HammyCCNumber)){
                ViewBag.CC = "Credit Card needs to be 16 digits long!";
            }
            if(String.IsNullOrEmpty(HammyCCCvn)){
                ViewBag.CCCvn = "CVN cannot be empty.";
            }
            else if(!cvvCheck.IsMatch(HammyCCCvn)){
                ViewBag.CCCvn = "InvalidCVN.";
            }
            
            if(String.IsNullOrEmpty(HammyCCDate)){
                ViewBag.CCDate = "CC Date cannot be empty!";
            }
            else{
                if(HammyCCDate.Length != 7){
                    ViewBag.CCDate = "CC Expiration date format is invalid.";
                }
                else{
                    var dateParts = HammyCCDate.Split('/'); //expiry date in from MM/yyyy            
                    if(!monthCheck.IsMatch(dateParts[0]) || !yearCheck.IsMatch(dateParts[1])){ // <3 - 6>
                        ViewBag.CCDate = "CC Expiration date invalid!"; // ^ check date format is valid as "MM/yyyy"
                    }
                    var year = int.Parse(dateParts[1]);
                    var month = int.Parse(dateParts[0]);            
                    var lastDateOfExpiryMonth = DateTime.DaysInMonth(year, month); //get actual expiry date
                    cardExpiry = new DateTime(year, month, lastDateOfExpiryMonth, 23, 59, 59);
                }

            }
            
            if(ViewBag.CC == null && ViewBag.CCDate == null && ViewBag.CCCvn == null){
                PasswordHasher<HamsterCreditCard> Secret = new PasswordHasher<HamsterCreditCard>();
                HamsterCreditCard doIhasCard = _waterFeeder.HamsterCreditCard.SingleOrDefault( kushCheck => kushCheck.HamsterId == HttpContext.Session.GetString("HammyID"));
                Hamster currentHamster = _waterFeeder.Hamster.SingleOrDefault( kush => kush.HamsterId == HttpContext.Session.GetString("HammyID"));

                if(doIhasCard == null){
                    HamsterCreditCard newCC = new HamsterCreditCard{
                        CardExpired = cardExpiry,
                        CardCVN = HammyCCCvn,
                        CardCreated_At = DateTime.Now,
                        CardUpdated_At = DateTime.Now,
                        HamsterId = currentHamster.HamsterId
                    };
                    newCC.CardNumber = Secret.HashPassword(newCC, HammyCCNumber);
                    _waterFeeder.Add(newCC);
                    _waterFeeder.SaveChanges();
                }
                else{
                    doIhasCard.CardNumber = Secret.HashPassword(doIhasCard, HammyCCNumber);
                    doIhasCard.CardExpired = cardExpiry;
                    doIhasCard.CardCVN = HammyCCCvn;
                    doIhasCard.CardUpdated_At = DateTime.Now;
                    _waterFeeder.SaveChanges();
                }
            }
            else{
                return View("HammieSettings");
            }
            
            return RedirectToAction("HammiesHome", "HammiesHome");
        }
        
    }
}

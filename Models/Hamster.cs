using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ECommerce.Models
{
    public abstract class BaseEntity{}
    public class Hamster : IdentityUser
    {
        
        public string HamsterId { get; set; }
        public int HamsterSecurity { get; set; }
        public string HamsterFirstName { get; set; }
        public string HamsterLastName { get; set; }
        public string HamsterUserName { get; set; }
        public string HamsterEmail { get; set; }
        public string HamsterPassword { get; set; }
        public string HamsterAddress { get; set; }
        public int HamsterPhoneNumber { get; set; }
        public int HamsterCredits { get; set; }
        public DateTime HamsterCreated_At { get; set; }
        public DateTime HamsterUpdated_At { get; set; }
        public List<HammyBlog> HammyBlog { get; set; }
        public List<BlogLike> BlogLike { get; set; }
        public List<Comment> Comment { get; set; }
        public List<HammyWishList> HammyWishList { get; set; }
        public Hamster(){
            HamsterId = Id;
            HamsterUserName = UserName;
            HamsterEmail = Email;
            HammyBlog = new List<HammyBlog>();
            BlogLike = new List<BlogLike>();
            Comment = new List<Comment>();
            HammyWishList = new List<HammyWishList>();
        }
    }
}
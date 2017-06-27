using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class HammyBlog : BaseEntity
    {
        [Key]
        public int BlogId { get; set; }
        public string BlogContent { get; set; }
        public DateTime BlogCreated_At { get; set; }
        public DateTime BlogUpdated_At { get; set; }
        [ForeignKey("HamsterId")]
        public string HamsterId { get; set; }
        public Hamster Hamster { get; set; }
        public HammyBlog(){
            Hamster = new Hamster();
        }
        
    }
}
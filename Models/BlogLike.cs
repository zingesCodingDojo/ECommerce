using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class BlogLike : BaseEntity
    {
        [Key]
        public int BlogLikeId { get; set; }
        [ForeignKey("BlogId")]
        public int BlogId { get; set; }
        public HammyBlog HammyBlog { get; set; }
        [ForeignKey("HamsterId")]
        public string HamsterId { get; set; }
        public Hamster Hamster { get; set; }
        public DateTime LikeCreated_At { get; set; }
        public DateTime LikeUpdated_At { get; set; }
    }
}
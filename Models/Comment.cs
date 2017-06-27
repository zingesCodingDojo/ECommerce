using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Comment : BaseEntity
    {
        [Key]
        public int CommentId { get; set; }
        [ForeignKey("HamsterId")]
        public string HamsterId { get; set; }
        public Hamster Hamster { get; set; }
        [ForeignKey("GoodieId")]
        public int GoodieId { get; set; }
        public Goodie Goodie { get; set; }
        public string CommentDescription { get; set; }
        public int CommentPopularity { get; set; }
        public DateTime CommentCreated_At { get; set; }
        public DateTime CommentUpdated_At { get; set; }
        
    }
}